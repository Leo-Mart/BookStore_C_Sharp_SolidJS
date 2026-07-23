import { Component, createSignal } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import { A, useLocation, useNavigate } from "@solidjs/router";
import {
  createForm,
  required,
  email,
  minLength,
  SubmitHandler,
} from "@modular-forms/solid";
import { type LoginForm } from "../Types/auth";
import TextInput from "../Components/Input/TextInput";

const Login: Component = () => {
  const [loginForm, { Form, Field }] = createForm<LoginForm>();
  const [error, setError] = createSignal<string>("");
  const location = useLocation();
  const redirect = () => location.query.redirect as string;

  const nav = useNavigate();
  const auth = useAuth();

  const handleSubmit: SubmitHandler<LoginForm> = async (values) => {
    try {
      await auth.login(values.email, values.password);
      nav(redirect(), { replace: true });
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      }
    }
  };
  return (
    <div class="flex flex-col mx-auto gap-2">
      <h2 class="text-2xl mx-auto font-bold text-everforest-bg-dim md:text-3xl dark:text-everforest-fg col-start-2">
        Login
      </h2>
      <Form class="mt-8 mx-2 md:mx-auto min-w-1/3" onSubmit={handleSubmit}>
        <Field
          name="email"
          validate={[
            required("Please enter your email"),
            email("Invalid email."),
          ]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="email"
              label="Email"
              placeholder="Enter Email"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        <Field
          name="password"
          validate={[
            required("Please enter your password"),
            minLength(12, "Your password must have at least 12 characters."),
          ]}
        >
          {(field, props) => (
            <TextInput
              {...props}
              type="password"
              label="password"
              placeholder="Enter password"
              value={field.value}
              error={field.error}
              required
            />
          )}
        </Field>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          class={`${loginForm.submitting && "disabled"}bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
        >
          Login
        </button>
      </Form>
      <div class="flex flex-col mt-8">
        <h4 class="px-3 py-2 text-xl text-center font-medium text-everforest-bg-dim dark:text-everforest-fg">
          No Account yet?
        </h4>
        <p class="text-center text-sm font-medium text-everforest-bg-dim dark:text-everforest-fg">
          Register an account for faster checkout, order-tracking, and more!
        </p>
        <A
          href={redirect() ? `/register?redirect=${redirect()}` : `/register`}
          type="button"
          class="text-center mx-2 md:mx-auto mt-2 block min-w-1/3 rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
        >
          Register
        </A>
      </div>
    </div>
  );
};

export default Login;
