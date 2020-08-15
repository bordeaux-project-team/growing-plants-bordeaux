import React from 'react';
import HomeContainer from './home';
import PlantingEnvironmentContainer from './planting-environment';
import MaterialCommunityIcons from 'react-native-vector-icons/MaterialCommunityIcons';
import {createBottomTabNavigator} from '@react-navigation/bottom-tabs';
import COLORS from './styles/color.style';

const Tab = createBottomTabNavigator();

const textColor = COLORS.commonText;
const textSize = 26;
const activeBackgroundColor = COLORS.commonBackground;
const inActiveBackgroundColor = COLORS.commonBorder;

const MainScreen = props => {
  return (
    <Tab.Navigator
      initialRouteName="Footer"
      tabBarOptions={{
        activeTintColor: textColor,
        activeBackgroundColor: activeBackgroundColor,
        inActiveBackground: inActiveBackgroundColor,
      }}>
      <Tab.Screen
        name="Home"
        component={HomeContainer}
        options={{
          tabBarLabel: 'Home',
          tabBarIcon: ({color, size}) => (
            <MaterialCommunityIcons name="home" color={color} size={size} />
          ),
        }}
      />
      <Tab.Screen
        name="PlantingEnvironment"
        component={PlantingEnvironmentContainer}
        options={{
          tabBarLabel: 'Planting Environment',
          tabBarIcon: ({color, size}) => (
            <MaterialCommunityIcons name="home" color={color} size={size} />
          ),
        }}
      />
    </Tab.Navigator>
  );
};

export default MainScreen;
