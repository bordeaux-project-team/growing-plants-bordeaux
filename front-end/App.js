import React from 'react';
import {logger} from 'react-native-logs';
import 'react-native-gesture-handler';
import {NavigationContainer} from '@react-navigation/native';
import {MainScreenContainer} from './src/screens';

const log = logger.createLogger();

const App: () => React$Node = () => {
  log.debug('App.js');
  return <NavigationContainer>{<MainScreenContainer />}</NavigationContainer>;
};

export default App;
