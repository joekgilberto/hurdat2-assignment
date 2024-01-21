import './Main.css';

import { Routes, Route } from 'react-router-dom'

import AllHuricanes from "../../pages/AllHuricanes/AllHuricanes";
import ShowHurricane from "../../pages/ShowHuricane/ShowHuricane";
import Error from "../../pages/Error/Error";

export default function Main() {
  return (
    <main>
      <Routes>
        <Route path="/" element={<AllHuricanes />} />
        <Route path="/" element={<ShowHurricane />} />
        <Route path={"/*"} element={<Error />} />
      </Routes>
    </main>
  );
}