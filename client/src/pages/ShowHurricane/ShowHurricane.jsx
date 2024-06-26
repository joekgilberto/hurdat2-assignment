import './ShowHurricane.css';

//Imports useEffect and useRef from React, useParams from react-router-dom, useDispatch and useSelector from Redux, loadCurrentHurricane, selectCurrentHurricane, and isLoading from the allHurricanesSlice, and custom utility functions
import { useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loadCurrentHurricane, selectCurrentHurricane, isLoading } from '../../slices/currentHurricaneSlice';
import { downloadHurricane as download } from '../../utilities/download/download';
import * as tools from '../../utilities/tools';

import Loading from '../../components/Loading/Loading';
import TrackEntry from '../../components/TrackEntry/TrackEntry';

//Exports ShowHurricane page component
export default function ShowHurricane() {

  //Destructures id from useParams
  const { id } = useParams();

  //Assigns useDispatch() function to dispatch
  const dispatch = useDispatch();

  //Assigns hurricanes to selectCurrentHurricane state
  const hurricane = useSelector(selectCurrentHurricane);

  //Assigns loading to isLoading boolean
  const loading = useSelector(isLoading);

  //Assigns trackRef to useRef(null)
  const trackRef = useRef(null);

  //Upon disptach, dispatches loadCurrentHurricane() with the id passed as an argument to update the hurricanes state
  useEffect(() => {
    dispatch(loadCurrentHurricane(id));
  }, [dispatch]);

  //Creates scroll function that queries for all TrackEntries and returns the node that corresponds with the .landfallEntry index, then scrolls to it using smooth behavior
  function scroll() {
    const trackNodes = trackRef.current;
    const landingNode = trackNodes.querySelectorAll('.TrackEntry')[hurricane.landfallEntry];
    landingNode.scrollIntoView({
      behavior: 'smooth'
    })
  }

  console.log(hurricane)

  //If loading is true, returns the Loading components
  if (loading) {
    return <Loading />
  }

  //Otherwise it displaces the hurricane name and year, maps over the hurricanes trackEntries returning TrackEntry components (with special argument being true if the index matches the .landfallsEntry), and adds a button to scroll down to the Florida Landfall entry
  //In the case there is no hurricane to display, an error is shown
  return (
    hurricane.name ?
      <div className="ShowHurricane">
        <div className='hurricane-title'>
          <h3>{tools.named(tools.title(hurricane.name))}</h3>
          <p>{hurricane.year}</p>
        </div>
        <div className='track-header'>
          <p className='track-count'>{hurricane.trackEntryCount} {hurricane.trackEntryCount === 1 ? `Track Entry` : `Track Entries`}</p>
          <div className='track-buttons'>
            <button className='track-download' onClick={(e) => download(e, hurricane.atcfCode, hurricane)}>Download</button>
            <button className='track-scroll' onClick={scroll}>Scroll To Landfall</button>
          </div>
        </div>
        <hr />
        <div className='track-entries' ref={trackRef}>
          {hurricane.trackEntries?.map((entry, idx) => {
            return (
              <TrackEntry key={idx} entry={entry} special={idx === hurricane.landfallEntry ? true : false} />
            )
          })}
        </div>
      </div>
      :
      <div className='show-hurricane-error'>
        <h3>No hurricane found, check your backend connection.</h3>
        <hr />
      </div>
  );
}