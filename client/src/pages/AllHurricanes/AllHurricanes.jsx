import './AllHurricanes.css';

//Imports useEffect from React, useDispatch and useSelector from Redux, and loadAllHurricanes, selectAllHurricanes, and isLoading from the allHurricanesSlice
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { loadAllHurricanes, selectAllHurricanes, isLoading } from '../../features/allHurricanesSlice';
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
  return (
    <div className="AllHurricanes">
      <div className='all-download'>
        <button  onClick={(e) => download(e, 'florida-landfalls', hurricanes)}>Download</button>
      </div>
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
    </div>
  );
}