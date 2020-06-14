import React from 'react';
import {LoginContainer} from './src/screens';
import {logger} from 'react-native-logs';
import 'react-native-gesture-handler';
import {NavigationContainer} from '@react-navigation/native';

const log = logger.createLogger();

const App: () => React$Node = () => {
  log.debug('App.js');
  return <NavigationContainer>{<LoginContainer />}</NavigationContainer>;
};

export default App;
