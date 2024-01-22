import './TrackEntry.css';

//Imports custom utility functions
import * as tools from '../../utilities/tools';

//Exports TrackEntry component with entry and special props that displays entry details and, if special is true, marks the TrackEntry class as special and displays the header "Florida Landfall"
export default function TrackEntry({ entry, special }) {
  return (
    <div className={`TrackEntry ${special ? 'special' : null}`}>
      {special ? <h4>Florida Landfall</h4> : null}
      <p className='record'>Recorded a <span className='bold'>{tools.status(entry.status)}</span> positioned at <span className='bold'>{entry.latitude}{entry.latitudeHemisphere}, {entry.longitude}{entry.longitudeHemisphere}</span>  with a max wind speed of <span className='bold'>{entry.maxWind}kn</span>.</p>
      <p className='time-date'>{entry.month}/{entry.day}/{entry.year} at {entry.hour < 10 ? `0${entry.hour}` : entry.hour}:{entry.minute < 10 ? `0${entry.minute}` : entry.minute} UTC</p>
    </div>
  );
}