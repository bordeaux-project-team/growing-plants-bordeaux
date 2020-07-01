import React, {Component} from 'react';
import {View} from 'react-native';
import styles from './planting-environment-container.style';
import GardenList from './garden-list/garden-list.component';

class PlantingEnvironmentContainer extends Component {
  render() {
    return (
      <View style={styles.plantingEnvironmentColumn}>
        <GardenList />
      </View>
    );
  }
}

export default PlantingEnvironmentContainer;
