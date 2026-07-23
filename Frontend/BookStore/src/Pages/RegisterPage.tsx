import { Component, createSignal } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import { useLocation, useNavigate } from "@solidjs/router";
import {
  createForm,
  required,
  email,
  minLength,
  SubmitHandler,
  getValue,
} from "@modular-forms/solid";
import { type RegisterForm } from "../Types/auth";
import TextInput from "../Components/Input/TextInput";
import { ErrorResponse } from "../Types/error";

const RegisterPage: Component = () => {
  const [registerForm, { Form, Field }] = createForm<RegisterForm>();
  const [error, setError] = createSignal<string>("");

  const location = useLocation();
  const redirect = () => location.query.redirect as string;

  const nav = useNavigate();
  const auth = useAuth();

  const handleSubmit: SubmitHandler<RegisterForm> = async (values) => {
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
      <Form class="mt-8 mx-2 md:mx-auto min-w-1/3" onSubmit={handleSubmit}>
        <Field
          name="email"
          validate={[
            required("Please enter a valid email!"),
            email("Invalid email."),
          ]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="email"
              label="Email"
              placeholder="Email"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        <Field
          name="firstName"
          validate={[required("Please fill out this field")]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="text"
              label="First Name"
              placeholder="First name"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>

        <Field
          name="lastName"
          validate={[required("Please fill out this field")]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="text"
              label="Last Name"
              placeholder="Last name"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        <Field
          name="password"
          validate={[
            required("Please enter a valid password!"),
            minLength(12, "Password must be at least 12 characters long."),
          ]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="password"
              label="Password"
              placeholder="Password"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        <Field
          name="confirmPassword"
          validate={[
            required("Please enter a valid password!"),
            minLength(12, "Password must be at least 12 characters long."),
            (value) =>
              value !== getValue(registerForm, "password")
                ? "Passwords do not match"
                : "",
          ]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="password"
              label="Confirm Password"
              placeholder="Confirm Password"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          class="bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
        >
          Register
        </button>
      </Form>
    </div>
  );
};

export default RegisterPage;
