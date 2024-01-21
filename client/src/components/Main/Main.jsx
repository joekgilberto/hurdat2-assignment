import './Main.css';

//Imports Routes and Route to chance main content based on the url path
import { Routes, Route } from 'react-router-dom'

import AllHuricanes from "../../pages/AllHurricanes/AllHurricanes";
import ShowHurricane from "../../pages/ShowHurricane/ShowHurricane";

//Exports a Main component with Routes to AllHuricanes and ShowHurricane with an id parameter
export default function Main() {
  return (
    <main>
      <Routes>
        <Route path="/" element={<AllHuricanes />} />
        <Route path="/:id" element={<ShowHurricane />} />
      </Routes>
    </main>
  );
}