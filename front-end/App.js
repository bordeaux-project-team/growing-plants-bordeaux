import React from 'react';
import {LoginContainer} from './src/screens';
import {logger} from 'react-native-logs';

const log = logger.createLogger();

const App: () => React$Node = () => {
  log.debug('App.js');
  return (
    <>
      <LoginContainer />
    </>
  );
};

export default App;
