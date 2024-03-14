import { buttonVariants } from '@/components/ui/button'
import { cn } from '@/lib/utils'
import Link from 'next/link'
import React from 'react'

export default function Register() {
  return (
    <>
      <Link
        href="/auth/login"
        className={cn(
          buttonVariants({ variant: "ghost" }),
          "absolute right-4 top-4 md:right-8 md:top-8"
        )}
      >
        Entrar
      </Link>
      <div className="lg:p-8">
        <div className="mx-auto flex w-full flex-col justify-center space-y-6 sm:w-[350px]">
          <div className="flex flex-col space-y-2 text-center">
            <h1 className="text-2xl font-semibold tracking-tight">
              Registrar sua conta
            </h1>
            <p className="text-sm text-muted-foreground">
              Preencha o formulário de cadastro abaixo para criar sua conta.
            </p>

            <h1>Registrar...</h1>
          </div>
        </div>
      </div>
    </>
  )
}
