import './Main.css';

import { Routes, Route } from 'react-router-dom'

import AllHuricanes from "../../pages/AllHurricanes/AllHurricanes";
import ShowHurricane from "../../pages/ShowHurricane/ShowHurricane";
import Error from "../../pages/Error/Error";

export default function Main() {
  return (
    <main>
      <Routes>
        <Route path="/" element={<AllHuricanes />} />
        <Route path="/:id" element={<ShowHurricane />} />
        <Route path={"/*"} element={<Error />} />
      </Routes>
    </main>
  );
}