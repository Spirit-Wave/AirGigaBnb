import Home from "./pages/Home/Home";
import { Route, Routes } from "react-router-dom";
import AdminPanel from "./pages/AdminPanel/AdminPanel";
import SignIn from "./pages/SignIn/SignIn";
import About from "./pages/About/About";
import Footer from "./components/Footer/Footer";

function App() {
  return (
    <>
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
