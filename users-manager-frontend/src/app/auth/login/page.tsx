import { buttonVariants } from '@/components/ui/button'
import { UserAuthForm } from '@/components/user-auth-form'
import { cn } from '@/lib/utils'
import Link from 'next/link'
import React from 'react'

export default function Login() {
  return (
    <>
      <Link
        href="/auth/register"
        className={cn(
          buttonVariants({ variant: "ghost" }),
          "absolute right-4 top-4 md:right-8 md:top-8"
        )}
      >
        Registrar
      </Link>
      <div className="lg:p-8">
        <div className="mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]">
          <div className="flex flex-col space-y-2 text-center">
            <h1 className="text-2xl font-semibold tracking-tight">
              Entre com sua conta
            </h1>
            <p className="text-sm text-muted-foreground">
              Digite seu email e senha abaixo para fazer login.
            </p>

            <UserAuthForm />
          </div>
        </div>
      </div>
    </>
  )
}
