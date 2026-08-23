import { createForm, Field, Form, SubmitHandler } from "@formisch/solid";
import { useNavigate, useSearchParams } from "@solidjs/router";
import { NewPasswordSchema } from "../Types/validation-schemas";
import TextInput from "../Components/Input/TextInput";
import { createSignal } from "solid-js";
import { ResetPasswordPayload } from "../Types/auth";
import { useToast } from "../Context/ToastContext";

const ResetPassword = () => {
  const newPasswordForm = createForm({ schema: NewPasswordSchema });
  const [params, setParams] = useSearchParams();
  const [error, setError] = createSignal("");

  const nav = useNavigate();
  const toast = useToast();

  const handleSubmit: SubmitHandler<typeof NewPasswordSchema> = async (
    values,
  ) => {
    try {
      const payload: ResetPasswordPayload = {
        email: params.userEmail! as string,
        token: params.token! as string,
        newPassword: values.newPassword,
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
      toast.add("Password changed, please log in again!", { type: "success" });
      nav("/login", { replace: true });
    } catch (error) {
      if (error instanceof Error) {
        console.log(error);
        setError(error.message);
      }
    }
  };
  return (
    <div class="flex flex-col items-center text-everforest-fg">
      <h1 class="text-4xl font-bold">Password reset</h1>
      <p>Enter a new password below</p>
      <Form
        of={newPasswordForm}
        onSubmit={handleSubmit}
        class="flex flex-col w-1/2 mt-2 mx-auto text-everforest-fg"
      >
        <Field of={newPasswordForm} path={["newPassword"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="New Password"
              placeholder="New password"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <Field of={newPasswordForm} path={["confirmNewPassword"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="Confirm New Password"
              placeholder="New password"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          aria-label="change-password-button"
          class={` ${newPasswordForm.isSubmitting && "disabled"}block mt-4 w-1/2 max-w-1/2 self-center rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
        >
          Reset Password
        </button>
      </Form>
    </div>
  );
};

export default ResetPassword;
