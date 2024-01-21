import './index.css';

//Imports React from react, ReactDom from react-dom/client, BrowserRouter as Router from react-router-dom, Provider from Redux, and the configureStore
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router } from "react-router-dom";
import { Provider } from 'react-redux';
import store from './App/store';

import App from './App/App';

//Returns App wrapped in a Provider component with the store as a property, a React.StrictMode component, and a Router component
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Router>
    <React.StrictMode>
      <Provider store={store}>
        <App />
      </Provider>
    </React.StrictMode>
  </Router>
);
