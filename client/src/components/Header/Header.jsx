import './Header.css';

import { Link } from 'react-router-dom';

export default function Header() {
  return (
    <header>
      <Link to="/">
        <h1>HURDAT2 | Hurricanes in Florida</h1>
      </Link>
    </header>
  );
}