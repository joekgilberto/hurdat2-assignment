import './Loading.css';

//Exports a Loading component with an idle animation
export default function Loading() {
  return (
    <div className='Loading'>
            <h2>Loading...</h2>
            <div className="loading-container">
                <div className="loading-bar"></div>
            </div>
    </div>
  );
}