import { Component, createSignal } from 'solid-js';
import { useAuth } from '../Context/AuthContext';
import { A, useNavigate } from '@solidjs/router';

const Login: Component = () => {
  const [email, setEmail] = createSignal('');
  const [password, setPassword] = createSignal('');

  const nav = useNavigate()
  const auth = useAuth()

  const handleSubmit = async (e: Event) => {
    e.preventDefault();
    await auth.login(email(), password())
    nav("/", {replace: true})   // TODO: redirect back to the page the user was at
  };

  return (
    <div class="grid grid-cols-3 gap-2">
      <h2 class="text-2xl font-bold text-everforest-bg-dim md:text-3xl dark:text-everforest-fg col-start-2">
        Login
      </h2>
      <form class="mt-8 col-start-2" onSubmit={handleSubmit}>
        <label
          for="username"
          class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3 mb-3"
        >
          <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
            Email
          </span>
          <input
            type="email"
            name="email"
            placeholder="Enter email"
            id="email"
            value={email()}
            onChange={(e) => setEmail(e.target.value)}
            class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
          />
        </label>
        <label
          for="password"
          class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3"
        >
          <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
            Password
          </span>
          <input
            type="password"
            name="password"
            placeholder="Enter password"
            id="password"
            value={password()}
            onChange={(e) => setPassword(e.target.value)}
            class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
          />
        </label>
        <button
          type="submit"
          class="bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
        >
          Login
        </button>
      </form>
      <div class='col-start-2 mt-8'>
        <h4 class='px-3 py-2 text-xl text-center font-medium text-everforest-bg-dim dark:text-everforest-fg'>No Account yet?</h4>
        <p class='text-center text-sm font-medium text-everforest-bg-dim dark:text-everforest-fg'>Register an account for faster checkout, order-tracking, and more!</p>
        <A
          href='/register'
          type="submit"
          class="mx-auto text-center bg-white mt-2 block w-1/2 rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer"
        >
          Register
        </A>
      </div>
    </div>
  );
};

export default Login;
