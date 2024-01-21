import './Hurricane.css';

import * as tools from '../../utilities/tools';

export default function Hurricane({hurricane}) {
  return (
    <div className='Hurricane'>
        <p>{hurricane.name}</p>
        <p>Landed {tools.month(hurricane.month)} {hurricane.day}, {hurricane.year}</p>
        <p>Maximum Wind Speed: {hurricane.maxWind}kn</p>
      <hr/>
    </div>
  );
}