import { createForm, Field, Form, SubmitHandler } from "@formisch/solid";
import { RequestResetPasswordSchema } from "../Types/validation-schemas";
import { createSignal, Match, Switch } from "solid-js";
import TextInput from "../Components/Input/TextInput";

type ResetPasswordPayload = {
  email: string;
};

const SendResetPassword = () => {
  const resetPasswordForm = createForm({ schema: RequestResetPasswordSchema });
  const [error, setError] = createSignal<string>("");

  const handleSubmit: SubmitHandler<typeof RequestResetPasswordSchema> = async (
    values,
  ) => {
    try {
      const payload: ResetPasswordPayload = {
        email: values.email,
      };
      const resp = await fetch(`/api/account/reset-password`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(payload),
      });
      if (!resp.ok) {
        throw Error(await resp.text());
      }
    } catch (error) {
      if (error instanceof Error) {
        console.log(error);
        setError(error.message);
      }
    }
  };
  return (
    <Switch>
      <Match when={resetPasswordForm.isSubmitted}>
        <div class="flex flex-col text-everforest-fg text-center">
          <h1 class="text-4xl">Email sent!</h1>
          <p>
            If your email exists in our database you should recieve an email
            with a reset link shortly.
          </p>
        </div>
      </Match>
      <Match when={!resetPasswordForm.isSubmitted}>
        <div class="flex flex-col text-everforest-fg">
          <p class="text-center">
            Forgot your password? Enter your email below and we'll send you a
            reset link.
          </p>

          <Form
            of={resetPasswordForm}
            class="mt-8 mx-2 md:mx-auto min-w-1/3"
            onSubmit={handleSubmit}
          >
            <Field of={resetPasswordForm} path={["email"]}>
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
            {error() && <div class="text-everforest-red py-1">{error()}</div>}
            <button
              type="submit"
              class={`${resetPasswordForm.isSubmitting && "disabled"}bg-white block mt-4 mx-auto w-1/2 rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
            >
              Send Reset Email
            </button>
          </Form>
        </div>
      </Match>
    </Switch>
  );
};

export default SendResetPassword;
