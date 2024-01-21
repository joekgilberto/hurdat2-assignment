import './Header.css';

import { Link } from 'react-router-dom';

export default function Header() {
  return (
    <header>
      <Link to="/">
        <h1>HURDAT2 Parsed</h1>
        <h2>Hurricanes that made landfall in Florida from 1900 onward</h2>
      </Link>
    </header>
  );
}