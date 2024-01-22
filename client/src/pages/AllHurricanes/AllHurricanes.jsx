import './AllHurricanes.css';

//Imports useEffect from React, useDispatch and useSelector from Redux, as well as loadAllHurricanes, selectAllHurricanes, and isLoading from the allHurricanesSlice, and downloadLandfalls as download from utilities
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { loadAllHurricanes, selectAllHurricanes, isLoading } from '../../slices/allHurricanesSlice';
import { downloadLandfalls as download } from '../../utilities/download/download';

import Hurricane from '../../components/Hurricane/Hurricane';
import Loading from '../../components/Loading/Loading';

//Exports AllHurricanes page component
export default function AllHurricanes() {

  //Assigns useDispatch() function to dispatch
  const dispatch = useDispatch();

  //Assigns hurricanes to selectAllHurricanes state
  const hurricanes = useSelector(selectAllHurricanes);

  //Assigns loading to isLoading boolean
  const loading = useSelector(isLoading);

  //Upon disptach, dispatches loadAllHurricanes() to update the hurricanes state
  useEffect(() => {
    dispatch(loadAllHurricanes());
  }, [dispatch]);

  //If loading is true, returns the Loading components
  if (loading) {
    return <Loading />
  }

  //Otherwise maps over the hurricanes state (if it has a length) and renders a Hurricane component for each hurricane
  //In the case there are no hurricanes to iterate through, an error is shown
  return (
    <div className="AllHurricanes">
      {hurricanes.length ?
        <>
          <div className='list-header'>
            <h4>All {hurricanes.length} Hurricanes that landed in Florida, 1900 onward</h4>
            <button onClick={(e) => download(e, 'florida-landfalls', hurricanes)}>Download</button>
          </div>
          <hr />
          <div className='hurricane-list'>
            {hurricanes.length ?
              hurricanes.map((h, idx) => {
                return (
                  <Hurricane key={idx} hurricane={h} />
                )
              })
              :
              null}
      </div>
        </>
        :
        <>
        <h3 className='all-hurricanes-error'>No hurricanes found, check your backend connection.</h3>
        <hr />
        </>}
    </div>
  );
}