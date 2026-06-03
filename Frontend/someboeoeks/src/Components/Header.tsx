
 function Header() {

  return (
    <header class="bg-white dark:bg-gray-900 shadow">
  <div class="mx-auto flex h-16 max-w-screen-xl items-center gap-8 px-4 sm:px-6 lg:px-8">
    <nav class="flex flex-1 items-center justify-between">
      <ul class="flex items-center gap-6 text-sm">
        <li>
          <a class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition" href="/">
            Home
          </a>      
        </li>
        <li>
          <a class="block rounded-md px-5 py-2.5 text-sm font-medium text-emerald-600 transition hover:bg-amber-600" href="/">
            Books
          </a>      
        </li>
      
        
      </ul>
    </nav>
  </div>
</header>
  );
}
  export default Header;