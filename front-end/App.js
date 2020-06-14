import React from 'react';
import {LoginScreen, SignUpScreen} from './src/screens';
import {logger} from 'react-native-logs';
import 'react-native-gesture-handler';
import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';

const log = logger.createLogger();
const Stack = createStackNavigator();

const App: () => React$Node = () => {
  log.debug('App.js');
  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Login">
        <Stack.Screen name="Login" component={LoginScreen} />
        <Stack.Screen name="SignUp" component={SignUpScreen} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
