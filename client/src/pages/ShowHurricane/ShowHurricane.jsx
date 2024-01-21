import './ShowHurricane.css';

import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loadCurrentHurricane, selectCurrentHurricane, isLoading } from '../../features/currentHurricaneSlice';
import * as tools from '../../utilities/tools';

import Loading from '../../components/Loading/Loading';
import TrackEntry from '../../components/TrackEntry/TrackEntry';

export default function ShowHurricane() {

  const { id } = useParams();

  const dispatch = useDispatch();
  const hurricane = useSelector(selectCurrentHurricane);
  const loading = useSelector(isLoading);

  useEffect(() => {
    dispatch(loadCurrentHurricane(id));
    console.log(hurricane)
  }, [dispatch]);

  if (loading) {
    return <Loading />
  }

  return (
    hurricane.name ?
      <div className="ShowHurricane">
        <div className='hurricane-title'>
          <h3>{tools.named(tools.title(hurricane.name))}</h3>
          <p>{hurricane.year}</p>
        </div>
        <p className='track-title'>Track Entries</p>
        <hr />
        <div className='track-entries'>
          {hurricane.trackEntries?.map((entry, idx) => {
            return (
              <TrackEntry key={idx} entry={entry} special={idx === hurricane.landfallEntry ? true : false} />
            )
          })}
        </div>
      </div>
      :
      <Loading />
  );
}