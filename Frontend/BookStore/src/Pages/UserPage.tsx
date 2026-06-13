import { Component } from 'solid-js';
import { useAuth } from '../Context/AuthContext';

const UserPage: Component<{}> = (props) => {
  const auth = useAuth();

  return (
    <div>
      <button onclick={auth.logout} class='bg-white block mt-4 w-full rounded-md px-5 py-2.5 text-sm font-medium text-everforest-bg-dim transition dark:bg-everforest-aqua dark:hover:bg-everforest-fg hover:cursor-pointer'>Logout</button>
    </div>
  );
};

export default UserPage;
