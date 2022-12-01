import Home from "./pages/Home";
import { Route, Routes } from "react-router-dom";
import AdminPanel from "./pages/AdminPanel";
import SignIn from "./pages/SignIn";
import About from "./pages/About";
import Header from "./components/Header";
import Footer from "./components/Footer";

function App() {
  return (
    <>
      {window.location.pathname !== "/" && <Header />}
      <Routes>
        <Route path="/" element={<SignIn />} />
        <Route path="/adminpanel" element={<AdminPanel />} />
        <Route path="/home" element={<Home />} />
        <Route path="/about" element={<About />} />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
