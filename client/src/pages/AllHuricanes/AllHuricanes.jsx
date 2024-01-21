import './AllHuricanes.css';

import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { loadAllHuricanes, selectAllHurricanes, isLoading, hasError } from '../../features/allHurricanesSlice';
import Hurricane from '../../components/Hurricane/Hurricane';
import Loading from '../../components/Loading/Loading';

export default function AllHuricanes() {

  const dispatch = useDispatch();
  const hurricanes = useSelector(selectAllHurricanes);
  const loading = useSelector(isLoading);

  useEffect(() => {
    dispatch(loadAllHuricanes());
    console.log(hurricanes);
  }, [dispatch]);

  if(loading){
    return <Loading />
  }
  return (
    <div className="AllHuricanes">
      {hurricanes.length?
      hurricanes.map((h,idx)=>{
        return <Hurricane key={idx} hurricane={h} />
      })
      :
      null }
    </div>
  );
}