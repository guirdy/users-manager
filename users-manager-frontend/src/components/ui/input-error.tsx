import { cn } from '@/lib/utils'

interface InputErrorProps extends React.HTMLAttributes<HTMLSpanElement> {
  text: string
  className?: string
}

export const InputError = ({ text, className = "", ...props }: InputErrorProps) => {
  return (
    <span className={cn("text-xs text-red-400 text-start", className)} {...props}>
      {text}
    </span>
  )
}
