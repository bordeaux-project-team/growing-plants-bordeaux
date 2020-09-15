import React, {useState} from 'react';
import {logger} from 'react-native-logs';
import 'react-native-gesture-handler';
import {MainScreenContainer} from './src/screens';
import {createStackNavigator} from '@react-navigation/stack';
import HomeContainer from './src/screens/home';
import GardenDetailInfo from './src/screens/planting-environment/garden-detail-info/garden-detail-info.component';
import GardenDetailInfoEdit from './src/screens/planting-environment/garden-detail-info-edit/garden-detail-info-edit.component';
import LoginContainer from './src/screens/login';
import PlantingEnvironmentContainer from './src/screens/planting-environment';
import {NavigationContainer} from '@react-navigation/native';
import PlantingProcessContainer from './src/screens/planting-process';
import MainScreen from './src/screens/main-screen.component';
import StartScreen from './src/screens/start-screen.component';
import TreeInformationContainer from './src/screens/tree-infomation';
import TreeDetailInfo from './src/screens/tree-infomation/tree-detail-info/tree-detail-info.component';
import PlantNewTree from './src/screens/planting-process/plant-new-tree/plant-new-tree.component';
import PlantingProcessOverview from './src/screens/planting-process/planting-process-overview/planting-process-overview.component';
import NewAction from './src/screens/planting-process/new-action/new-action.component';
import {Button} from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';

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
        <Stack.Screen name="Login" component={LoginContainer} />
        <Stack.Screen name="Main" component={MainScreenContainer} />
        <Stack.Screen name="MainScreen" component={MainScreen} />
        <Stack.Screen name="StartScreen" component={StartScreen} />
        <Stack.Screen name="Home" component={HomeContainer} />
        <Stack.Screen
          name="PlantingEnvironment"
          component={PlantingEnvironmentContainer}
        />
        <Stack.Screen name="GardenDetailInfo" component={GardenDetailInfo} />
        <Stack.Screen
          name="GardenDetailInfoEdit"
          component={GardenDetailInfoEdit}
        />
        <Stack.Screen
          name="PlantingProcess"
          component={PlantingProcessContainer}
        />
        <Stack.Screen
          name="TreeInformation"
          component={TreeInformationContainer}
        />
        <Stack.Screen name="TreeDetailInfo" component={TreeDetailInfo} />
        <Stack.Screen name="PlantNewTree" component={PlantNewTree} />
        <Stack.Screen
          name="PlantingProcessOverview"
          component={PlantingProcessOverview}
        />
        <Stack.Screen name="NewAction" component={NewAction} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;
