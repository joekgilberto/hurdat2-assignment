import './ShowHurricane.css';

import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loadCurrentHurricane, selectCurrentHurricane, isLoading } from '../../features/currentHurricaneSlice';

import Loading from '../../components/Loading/Loading';
import TrackEntry from '../../components/TrackEntry/TrackEntry';

export default function ShowHurricane() {

  const { id } = useParams();

  const dispatch = useDispatch();
  const hurricane = useSelector(selectCurrentHurricane);
  const loading = useSelector(isLoading);

  useEffect(() => {
    dispatch(loadCurrentHurricane(id));
  }, [dispatch]);

  if (loading) {
    return <Loading />
  }

  return (
    <div className="ShowHurricane">
      <p>Name: {hurricane.name}</p>
      <p>Year: {hurricane.year}</p>
      <p>Bastin {hurricane.basin}</p>
      {hurricane?.trackEntries?.map((entry,idx)=>{
        return(
          <TrackEntry key={idx} entry={entry} special={idx===hurricane.landfallEntry?true:false} />
        )
      })}
    </div>
  );
}