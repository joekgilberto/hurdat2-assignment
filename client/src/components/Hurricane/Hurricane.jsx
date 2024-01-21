import './Hurricane.css';

//Imports the Link component to naviate the React app and custom utility functions from tools.js
import { Link } from 'react-router-dom';
import * as tools from '../../utilities/tools';

//Exports a Hurricane component to display a hurricane's name, date, and max wind speed while linking to a ShowHurricane page based on the hurricane's ATCF Code
export default function Hurricane({ hurricane }) {
  return (
    <div className='Hurricane'>
      <Link to={`/${hurricane.atcfCode}`}>
        <h3 className='hurricane-name'>{tools.named(tools.title(hurricane.name))}</h3>
        <hr />
        <div className='date-and-wind'>
          <p>Landed on <span className='bold'>{tools.month(hurricane.month)} {hurricane.day}, {hurricane.year}</span></p>
          <p>Max Wind Speed: <span className='bold'>{hurricane.maxWind}kn</span></p>
        </div>
      </Link>
    </div>
  );
}