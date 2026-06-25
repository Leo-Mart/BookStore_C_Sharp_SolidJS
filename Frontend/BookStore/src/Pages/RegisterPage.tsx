import { Component, createSignal } from 'solid-js';
import { useAuth } from '../Context/AuthContext';
import { useNavigate } from '@solidjs/router';
import {
  createForm,
  required,
  email,
  minLength,
  SubmitHandler,
  getValue,
} from '@modular-forms/solid';

type RegisterForm = {
  email: string;
  password: string;
  confirmPassword: string;
};

const RegisterPage: Component = () => {
  const [registerForm, { Form, Field }] = createForm<RegisterForm>();

  const nav = useNavigate();
  const auth = useAuth();

  const handleSubmit: SubmitHandler<RegisterForm> = async (values, e) => {
  
      const resp = await fetch('/api/account/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          email: values.email,
          password: values.password,
        }),
      });
      const result = await resp.json();
      await auth.login(values.email, values.password);
      nav('/', { replace: true }); // TODO: redirect back to the page the user was at

  };

  return (
    <div class="grid grid-cols-3 gap-2">
      <h2 class="text-2xl font-bold text-everforest-bg-dim md:text-3xl dark:text-everforest-fg col-start-2">
        Register new User
      </h2>
      <Form class="mt-8 col-start-2" onSubmit={handleSubmit}>
        <Field
          name="email"
          validate={[
            required('Please enter a valid email!'),
            email('Invalid email.'),
          ]}
        >
          {(field, props) => (
            <div>
              <label
                for="email"
                class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3 mb-3"
              >
                <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                  Email
                </span>
                <input
                  {...props}
                  type="email"
                  name="email"
                  class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                  placeholder="Enter email"
                  id={field.name}
                  value={field.value}
                  required
                />
              </label>
              {field.error && (
                <div class="text-everforest-red pb-1">{field.error}</div>
              )}
            </div>
          )}
        </Field>
        <Field
          name="password"
          validate={[
            required('Please enter a valid password!'),
            minLength(12, 'Password must be at least 12 characters long.'),
          ]}
        >
          {(field, props) => (
            <div>
              <label
                for="password"
                class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3 mb-3"
              >
                <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                  Password
                </span>
                <input
                  {...props}
                  type="password"
                  name="password"
                  class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                  placeholder="Enter password"
                  id={field.name}
                  value={field.value}
                  required
                />
              </label>
              {field.error && (
                <div class="text-everforest-red pb-1">{field.error}</div>
              )}
            </div>
          )}
        </Field>
        <Field
          name="confirmPassword"
          validate={[
            required('Please enter a valid password!'),
            minLength(12, 'Password must be at least 12 characters long.'),
            (value) => value !== getValue(registerForm, "password") ? "Passwords do not match" : "",
          ]}
        >
          {(field, props) => (
            <div>
              <label
                for="confirmPassword"
                class="block overflow-hidden border border-everforest-bg-dim px-3 py-2 shadow-sm focus-within:border-everforest-aqua focus-within:ring-1 dark:bg-everforest-bg-3 mb-3"
              >
                <span class="text-xs font-medium text-everforest-bg-dim dark:text-everforest-fg">
                  Confirm Password
                </span>
                <input
                  {...props}
                  type="password"
                  name="confirmPassword"
                  class="mt-1 w-full border-none bg-transparent p-0 focus:border-transparent focus:outline-none focus:ring-0 sm:text-sm dark:text-everforest-fg"
                  placeholder="Confirm password"
                  id={field.name}
                  value={field.value}
                  required
                />
              </label>
              {field.error && (
                <div class="text-everforest-red pb-1">{field.error}</div>
              )}
            </div>
          )}
        </Field>    
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
