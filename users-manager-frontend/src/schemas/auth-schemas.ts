import * as z from 'zod'

export const loginInFormSchema = z.object({
  email: z
    .string()
    .email({ message: 'E-mail inválido' })
    .transform((value) => value.trim().toLowerCase()),
  password: z.string().min(1, 'Senha obrigatória'),
});
