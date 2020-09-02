import React from 'react';
import {View} from 'react-native';
import GardenSelectBoxBar from './garden-select-box-bar/garden-select-box-bar.component';
import GardenSearchBar from './garden-search-bar/garden-search-bar.component';
import GardenDetail from './garden-detail/garden-detail.component';
import ButtonAction from '../../common-elements/button-action.component';
import styles from './garden-list.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {useNavigation} from '@react-navigation/native';

function GardenList() {
  const navigation = useNavigation();
  return (
    <BackgroundScreen>
      <View style={styles.gardenListBackground}>
        <GardenSearchBar />
        <GardenSelectBoxBar />
        <GardenDetail />
        <ButtonAction doPress={() => navigation.navigate('GardenDetailInfo')} />
      </View>
    </BackgroundScreen>
  );
}

export default GardenList;
