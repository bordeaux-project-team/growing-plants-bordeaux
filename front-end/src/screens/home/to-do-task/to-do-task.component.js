import React from 'react';
import HomeContainer from '../../home';
import PlantingEnvironmentContainer from '../../planting-environment';
import {createDrawerNavigator} from '@react-navigation/drawer';
import {NavigationContainer} from '@react-navigation/native';

const Drawer = createDrawerNavigator();

const ToDoTask = props => {
  return (
    <NavigationContainer>
      <Drawer.Navigator initialRouteName="Home">
        <Drawer.Screen name="Home" component={HomeContainer} />
        <Drawer.Screen
          name="Notifications"
          component={PlantingEnvironmentContainer}
        />
      </Drawer.Navigator>
    </NavigationContainer>
  );
};

export default ToDoTask;
