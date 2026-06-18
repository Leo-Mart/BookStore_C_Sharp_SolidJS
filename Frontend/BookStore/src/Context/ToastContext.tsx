import { createContext, createSignal, ParentComponent, ParentProps, useContext } from "solid-js"
import { Portal } from "solid-js/web"
import ToastList from "../Components/ToastList"

type ToastType = "info" | "success" | "error" | "warning"

interface Toast {
  id: string
  message: string
  type: ToastType
  duration: number
}

interface ToastOptions {
  type?: ToastType
  duration?: number
}

interface ToastContextValue {
  toasts: () => Toast[]
  add: (message: string, options?: ToastOptions) => string
  remove: (id:string) => void
}

const ToastContext = createContext<ToastContextValue>();

const DEFAULT_DURATION = 4000

export const ToastProvider: ParentComponent = (props) => {
  const [toasts, setToasts] = createSignal<Toast[]>([])

  const remove = (id: string) => {
    setToasts((t) => t.filter((toast) => toast.id !== id))
  }

  const add = (message: string, options: ToastOptions = {}) => {
    const id = crypto.randomUUID();
    const duration = options.duration ?? DEFAULT_DURATION

    setToasts((t) => [
      ...t,
      {id, message, type: options.type ?? "info", duration}
    ])

    if (duration > 0) {
      setTimeout(() => remove(id), duration)
    }

    return id
  }

  const value: ToastContextValue = {toasts, add, remove}

  return (
    <ToastContext.Provider value={value}>
      {props.children}
      <Portal>
        <ToastList toasts={toasts()} onDismiss={remove} />
      </Portal>
    </ToastContext.Provider>
  )
}

export function useToast(): ToastContextValue {
  const ctx = useContext(ToastContext)
  if (!ctx) {
    throw new Error("useToast must be used within a ToastProvider")
  }
  return ctx
}