import './TrackEntry.css';

import * as tools from '../../utilities/tools';

export default function TrackEntry({ entry, special }) {
  return (
    <div className={`TrackEntry ${special ? 'special' : null}`}>
      {special ? <h4>Florida Landfall</h4> : null}
      <p className='record'>Recorded a <span className='bold'>{tools.status(entry.status)}</span> positioned at <span className='bold'>{entry.latitude}{entry.latitudeHemisphere}, {entry.longitude}{entry.longitudeHemisphere}</span>  with a max wind speed of <span className='bold'>{entry.maxWind}kn</span>.</p>
      <p className='time-date'>{entry.month}/{entry.day}/{entry.year} at {entry.hour < 10 ? `0${entry.hour}` : entry.hour}:{entry.minute < 10 ? `0${entry.minute}` : entry.minute} UTC</p>
    </div>
  );
}