import './AllHurricanes.css';

import { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loadAllHurricanes, selectAllHurricanes, isLoading } from '../../features/allHurricanesSlice';

import Hurricane from '../../components/Hurricane/Hurricane';
import Loading from '../../components/Loading/Loading';

export default function AllHurricanes() {

  const dispatch = useDispatch();
  const hurricanes = useSelector(selectAllHurricanes);
  const loading = useSelector(isLoading);

  useEffect(() => {
    dispatch(loadAllHurricanes());
  }, [dispatch]);

  if (loading) {
    return <Loading />
  }

  return (
    <div className="AllHurricanes">
      {hurricanes.length ?
        hurricanes.map((h, idx) => {
          return (
              <Hurricane key={idx} hurricane={h} />
          )
        })
        :
        null}
    </div>
  );
}