import './Hurricane.css';

import * as tools from '../../utilities/tools';

export default function Hurricane({ hurricane }) {
  return (
    <div className='Hurricane'>
      <h3 className='hurricane-name'>{tools.title(hurricane.name) == 'Unnamed' ? `${tools.title(hurricane.name)} Hurricane` : `Hurricane ${tools.title(hurricane.name)}`}</h3>
      <hr/>
      <div className='date-and-wind'>
        <p>Landed on <span className='bold'>{tools.month(hurricane.month)} {hurricane.day}, {hurricane.year}</span></p>
        <p>Max Wind Speed: <span className='bold'>{hurricane.maxWind}kn</span></p>
      </div>
    </div>
  );
}