import React, {Component} from 'react';
import {View} from 'react-native';
import GardenSelectBoxBar from './garden-select-box-bar/garden-select-box-bar.component';
import GardenSearchBar from './garden-search-bar/garden-search-bar.component';
import GardenDetail from './garden-detail/garden-detail.component';

class GardenList extends Component {
  render() {
    return (
      <View>
        <GardenSearchBar />
        <GardenSelectBoxBar />
        <GardenDetail />
      </View>
    );
  }
}

export default GardenList;
