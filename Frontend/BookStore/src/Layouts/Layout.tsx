import { ParentComponent } from "solid-js";
import Header from "../Components/Header";
import Footer from "../Components/Footer";

const Layout: ParentComponent = (props) => {
  
  return (
    <>
      <Header />
      <main class="min-h-screen bg-everforest-bg-dim">

        {props.children}

      </main>
      <Footer />
    </>
  )
};

export default Layout;