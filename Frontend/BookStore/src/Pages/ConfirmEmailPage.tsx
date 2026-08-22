import { A, useSearchParams } from "@solidjs/router";
import { createResource, createSignal, Match, Show, Switch } from "solid-js";

type ConfirmEmailPayload = {
  email: string;
  token: string;
};

const ConfirmEmailPage = () => {
  const [params, setParams] = useSearchParams();
  const [error, setError] = createSignal();
  const confirmEmailRequest = async () => {
    try {
      const payload: ConfirmEmailPayload = {
        email: params.userEmail! as string,
        token: params.token! as string,
      };
      const resp = await fetch(`/api/account/confirm-email`, {
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
  const [confirm] = createResource(params, confirmEmailRequest);

  return (
    <div class="flex flex-col items-center text-everforest-fg">
      <Show when={confirm.loading}>
        <p>Confirming email...</p>
      </Show>
      <Switch>
        <Match when={confirm.error}>
          <div>
            Something broke while confirming email, would you like to try again?
            Send new confirmation-link
          </div>
        </Match>
        <Match when={!confirm.loading && !confirm.error}>
          <h1 class="text-4xl font-bold">Email confirmed!</h1>
          <p>
            You can now login:{" "}
            <A class="underline hover:cursor-pointer" href="/login">
              here
            </A>
          </p>
        </Match>
      </Switch>
    </div>
  );
};

export default ConfirmEmailPage;
