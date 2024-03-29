import './Header.css';

//Imports the Link component to navigate the React app
import { Link } from 'react-router-dom';

//Exports a Header component which holds the title of the website and links back to the homepage
export default function Header() {
  return (
    <header>
      <Link to="/">
        <h1>HURDAT2</h1>
        <h2>parsed by Joe Gilberto</h2>
      </Link>
    </header>
  );
}