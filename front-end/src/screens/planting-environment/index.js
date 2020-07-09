import React, {Component} from 'react';
import {View} from 'react-native';
import styles from './planting-environment-container.style';
import GardenList from './garden-list/garden-list.component';
import BackgroundScreen from '../common-screens/background-screen.component';

class PlantingEnvironmentContainer extends Component {
  render() {
    return (
      <BackgroundScreen>
        <View style={styles.plantingEnvironmentColumn}>
          <GardenList />
        </View>
      </BackgroundScreen>
    );
  }
}

export default PlantingEnvironmentContainer;
