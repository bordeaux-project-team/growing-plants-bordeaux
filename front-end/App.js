import React from 'react';
import {logger} from 'react-native-logs';
import 'react-native-gesture-handler';
import {MainScreenContainer} from './src/screens';
import {createStackNavigator} from '@react-navigation/stack';
import HomeContainer from './src/screens/home';
import GardenDetailInfo from './src/screens/planting-environment/garden-detail-info/garden-detail-info.component';
import LoginContainer from './src/screens/login';
import PlantingEnvironmentContainer from './src/screens/planting-environment';
import {NavigationContainer} from '@react-navigation/native';
import PlantingProcessContainer from './src/screens/planting-process';
import MainScreen from './src/screens/main-screen.component';
import StartScreen from './src/screens/start-screen.component';

const log = logger.createLogger();

const Stack = createStackNavigator();

const App: () => React$Node = () => {
  log.debug('App.js');
  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Main"
        screenOptions={{
          headerStyle: {
            backgroundColor: 'green',
          },
          headerTintColor: '#fff',
          headerLeft: null,
        }}>
        <Stack.Screen name="Main" component={MainScreenContainer} />
        <Stack.Screen name="MainScreen" component={MainScreen} />
        <Stack.Screen name="StartScreen" component={StartScreen} />
        <Stack.Screen name="Home" component={HomeContainer} />
        <Stack.Screen name="Login" component={LoginContainer} />
        <Stack.Screen
          name="PlantingEnvironment"
          component={PlantingEnvironmentContainer}
        />
        <Stack.Screen name="GardenDetailInfo" component={GardenDetailInfo} />
        <Stack.Screen
          name="GardenPlanting"
          component={PlantingProcessContainer}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
