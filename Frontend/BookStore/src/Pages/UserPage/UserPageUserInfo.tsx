import { createForm, Field, Form, SubmitHandler } from "@formisch/solid";
import { Component, createSignal } from "solid-js";
import { ChangePasswordSchema } from "../../Types/validation-schemas";
import TextInput from "../../Components/Input/TextInput";
import { ErrorResponse } from "../../Types/error";
import { useNavigate } from "@solidjs/router";
import { useAuth } from "../../Context/AuthContext";

const UserPageUserInfo: Component = () => {
  const changePasswordForm = createForm({ schema: ChangePasswordSchema });
  const [error, setError] = createSignal<string>("");

  const nav = useNavigate();
  const auth = useAuth();

  const changePasswordHandler: SubmitHandler<
    typeof ChangePasswordSchema
  > = async (values) => {
    try {
      const resp = await auth.authenticatedRequest(
        "/api/account/change-password",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            oldPassword: values.oldPassword,
            newPassword: values.newPassword,
          }),
        },
      );

      if (resp.status === 400) {
        const error: ErrorResponse = await resp.json();
        throw new Error(error.message);
      }

      if (!resp.ok) {
        //TODO: this should throw something else, of the 500 variety
        const error: ErrorResponse = await resp.json();
        throw new Error(error.message);
      }

      if (resp.ok) {
        auth.logout();
        nav("/login", { replace: true });
      }
    } catch (error) {
      if (error instanceof Error) {
        setError(error.message);
      }
    }
  };

  return (
    <div class="grid grid-cols-12 gap-3">
      <div class="hidden lg:flex lg:col-span-2"></div>
      <div class="col-span-12 lg:col-span-8 text-everforest-fg">
        <h1 class="text-2xl font-bold">User Info</h1>
        <p>
          Here you can see all your account information, as well as change
          password, email and manage addresses.
        </p>
      </div>
      <div class="lg:col-start-3 col-span-12 lg:col-span-8 text-everforest-fg">
        <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>
              First name
            </dt>
            <dd class="inline-block">Herr</dd>
          </div>
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>
              Last name
            </dt>
            <dd class="inline-block">Test</dd>
          </div>
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>Address</dt>
            <dd class="inline-block">A Street</dd>
          </div>
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>
              Postal code
            </dt>
            <dd class="inline-block">123 45</dd>
          </div>
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>City</dt>
            <dd class="inline-block">A City</dd>
          </div>
        </dl>
      </div>
      <div class="lg:col-start-3 col-span-12 lg:col-span-8 text-everforest-fg">
        <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>Email</dt>
            <dd class="inline-block">test@test.com</dd>
          </div>
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>
              Confirm email
            </dt>
            <dd class="inline-block">test@test.com</dd>
          </div>
        </dl>
      </div>
      <div class="lg:col-start-3 col-span-12 lg:col-span-8 text-everforest-fg">
        <dl class="columns-1 gap-8 space-y-4 lg:columns-2">
          <div>
            <dt class='inline-block after:mr-2 after:content-[":"]'>Phone</dt>
            <dd class="inline-block">0768-791461</dd>
          </div>
        </dl>
      </div>
      <Form
        of={changePasswordForm}
        onSubmit={changePasswordHandler}
        class="lg:col-start-3 col-span-12 lg:col-span-8 flex flex-col w-full   text-everforest-fg"
      >
        <Field of={changePasswordForm} path={["oldPassword"]}>
          {(field) => (
            <TextInput
              {...field.props}
              type="password"
              label="Old Password"
              placeholder="Old password"
              input={field.input}
              errors={field.errors}
              required
            />
          )}
        </Field>
        <div class="flex gap-3">
          <Field of={changePasswordForm} path={["newPassword"]}>
            {(field) => (
              <TextInput
                class="max-w-1/2 grow"
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
          <Field of={changePasswordForm} path={["confirmNewPassword"]}>
            {(field) => (
              <TextInput
                {...field.props}
                class="max-w-1/2 grow"
                type="password"
                label="Confirm New Password"
                placeholder="New password"
                input={field.input}
                errors={field.errors}
                required
              />
            )}
          </Field>
        </div>
        {error() && <div class="text-everforest-red py-1">{error()}</div>}
        <button
          type="submit"
          aria-label="change-password-button"
          class={` ${changePasswordForm.isSubmitting && "disabled"}block mt-4 w-1/2 max-w-1/2 self-center rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer`}
        >
          Change Password
        </button>
      </Form>
      <div class="hidden lg:flex lg:col-span-2"></div>
    </div>
  );
};

export default UserPageUserInfo;
