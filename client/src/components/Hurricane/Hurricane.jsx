import './Hurricane.css';

export default function Hurricane({hurricane}) {
  return (
    <div className='Hurricane'>
        <p>Name: {hurricane.name}</p>
        <p>Date of Landfall: {hurricane.trackEntries[hurricane.floridaLandingIndex].month}/{hurricane.trackEntries[hurricane.floridaLandingIndex].day}/{hurricane.trackEntries[hurricane.floridaLandingIndex].year}</p>
        <p>Maximum Wind Speed: {hurricane.trackEntries[hurricane.floridaLandingIndex].maxWind}kn</p>
      <hr/>
    </div>
  );
}