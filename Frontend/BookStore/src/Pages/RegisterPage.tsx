import { Component, createSignal } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import { useLocation, useNavigate } from "@solidjs/router";
import { type RegisterForm } from "../Types/auth";
import TextInput from "../Components/Input/TextInput";
import { ErrorResponse } from "../Types/error";
import { createForm, Field, Form, SubmitHandler } from "@formisch/solid";
import { RegisterFormSchema } from "../Types/validation-schemas";

const RegisterPage: Component = () => {
  const registerForm = createForm({ schema: RegisterFormSchema });
  const [error, setError] = createSignal<string>("");

  const location = useLocation();
  const redirect = () => location.query.redirect as string;

  const nav = useNavigate();
  const auth = useAuth();

  const handleSubmit: SubmitHandler<typeof RegisterFormSchema> = async (
    values,
  ) => {
    try {
      const resp = await fetch("/api/account/register", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          email: values.email,
          password: values.password,
          firstName: values.firstName,
          lastName: values.lastName,
        }),
      });

      if (resp.status === 400) {
        const error: ErrorResponse = await resp.json();
        throw new Error(error.message);
      }
      if (resp.ok) {
        await auth.login(values.email, values.password);
        nav(redirect(), { replace: true });
      }
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      }
    }
  };

  return (
    <div class="flex flex-col mx-auto gap-2">
      <h2 class="text-2xl mx-auto font-bold text-everforest-bg-dim md:mx-auto md:text-3xl dark:text-everforest-fg col-start-2">
        Register new User
      </h2>
      <Form
        of={registerForm}
        class="mt-8 mx-2 md:mx-auto min-w-1/3"
        onSubmit={handleSubmit}
      >
        <Field of={registerForm} path={["email"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="email"
              label="Email"
              placeholder="Email"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={registerForm} path={["firstName"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="text"
              label="First Name"
              placeholder="John"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>

        <Field of={registerForm} path={["lastName"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="text"
              label="Last Name"
              placeholder="Doe"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={registerForm} path={["password"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="Password"
              placeholder="Password"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={registerForm} path={["confirmPassword"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="Confirm Password"
              placeholder="Confim Password"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          class={` ${registerForm.isSubmitting && "disabled"}block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
        >
          Register
        </button>
      </Form>
    </div>
  );
};

export default RegisterPage;
