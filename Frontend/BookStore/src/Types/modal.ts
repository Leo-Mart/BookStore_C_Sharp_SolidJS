import { JSX } from "solid-js"

export interface ModalProps {
  open: boolean
  onClose: () => void
  title?: string
  children: JSX.Element
  footer?: JSX.Element
}

export interface DiscountCodeModalProps {
  open: boolean;
  onClose: () => void;
}

export interface GiftCardModalProps {
  open: boolean;
  onClose: () => void;
}
