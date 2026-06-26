export const DEFAULT_DURATION = 4000

export type ToastType = "info" | "success" | "error" | "warning"

export interface Toast {
  id: string
  message: string
  type: ToastType
  duration: number
}

export interface ToastOptions {
  type?: ToastType
  duration?: number
}

export interface ToastContextValue {
  toasts: () => Toast[]
  add: (message: string, options?: ToastOptions) => string
  remove: (id:string) => void
}
