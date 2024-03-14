import * as z from 'zod'
import { loginInFormSchema } from "@/schemas/auth-schemas";

export type LoginInFormData = z.infer<typeof loginInFormSchema>;
