import { Component, createSignal } from "solid-js";
import { useAuth } from "../Context/AuthContext";
import { A, useLocation, useNavigate } from "@solidjs/router";
import TextInput from "../Components/Input/TextInput";
import { createForm, Field, Form, SubmitHandler } from "@formisch/solid";
import { LoginFormSchema } from "../Types/validation-schemas";

const Login: Component = () => {
  const loginForm = createForm({ schema: LoginFormSchema });
  const [error, setError] = createSignal<string>("");
  const location = useLocation();
  const redirect = () => location.query.redirect as string;

  const nav = useNavigate();
  const auth = useAuth();

  const handleSubmit: SubmitHandler<typeof LoginFormSchema> = async (
    values,
  ) => {
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
      <Form
        of={loginForm}
        class="mt-8 mx-2 md:mx-auto min-w-1/3"
        onSubmit={handleSubmit}
      >
        <Field of={loginForm} path={["email"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="email"
              label="Email"
              placeholder="Enter Email"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={loginForm} path={["password"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="Password"
              placeholder="Enter Email"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          class={`${loginForm.isSubmitting && "disabled"}bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
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
