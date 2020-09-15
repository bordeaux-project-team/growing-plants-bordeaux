import React from 'react';
import {
  AsyncStorage,
  Button,
  SafeAreaView,
  ScrollView,
  Text,
  View,
} from 'react-native';
import GardenSelectBoxBar from './garden-select-box-bar/garden-select-box-bar.component';
import GardenSearchBar from './garden-search-bar/garden-search-bar.component';
import GardenDetail from './garden-detail/garden-detail.component';
import ButtonAction from '../../common-elements/button-action.component';
import styles from './garden-list.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {StackActions, useNavigation} from '@react-navigation/native';

function GardenList() {
  const navigation = useNavigation();
  const doLogout = async () => {
    await AsyncStorage.clear();
    navigation.dispatch(StackActions.replace('Main'));
  };
  return (
    <BackgroundScreen>
      <SafeAreaView style={styles.gardenListBackground}>
        <ScrollView>
          <View style={styles.detailContainer}>
            {/*<GardenSearchBar />*/}
            {/*<GardenSelectBoxBar />*/}
            <Text style={styles.gardenTitle}>Gardens</Text>
            <GardenDetail />
            <View style={styles.logOutButtonContainer}>
              <Button
                onPress={doLogout}
                title="Log Out"
                style={styles.logOutButton}
              />
            </View>
          </View>
        </ScrollView>
        <ButtonAction
          doPress={() =>
            navigation.dispatch(StackActions.replace('GardenDetailInfo'))
          }
        />
      </SafeAreaView>
    </BackgroundScreen>
  );
}

export default GardenList;
