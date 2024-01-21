import './TrackEntry.css';

import * as tools from '../../utilities/tools';

export default function TrackEntry({entry,special}) {
  return (
    <div className='TrackEntry'>
        <p>{special?"*":null}</p>
        <p>{tools.status(entry.status)} tracked on {entry.month}/{entry.day}/{entry.year} at {entry.hour<10?`0${entry.hour}`:entry.hour}:{entry.minute<10?`0${entry.minute}`:entry.minute} UTC</p>
        <p>Position: {entry.latitude}{entry.latitudeHemisphere}, {entry.longitude}{entry.longitudeHemisphere}</p>
        <p>Maximum Wind: {entry.maxWind}kn</p>
        <hr/>
    </div>
  );
}