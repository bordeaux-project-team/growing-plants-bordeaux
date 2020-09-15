import React, {Component} from 'react';
import {
  Button,
  SafeAreaView,
  ScrollView,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';
import styles from './garden-planting.style';
import Grid from 'react-native-grid-component';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {StackActions, useNavigation} from '@react-navigation/native';
import {Avatar, ListItem} from 'react-native-elements';
import {getPlantingSpotById} from '../../../services/planting-process-service';
import {getTreeById} from '../../../services/tree-service';

class GardenPlanting extends Component {
  constructor(props) {
    super(props);
    const plantingEnvironment = props.plantingEnvironment
      ? props.plantingEnvironment
      : null;
    this.state = {
      planingProcess: undefined,
      gardenWidth: 0,
      gardenLength: 0,
      plantingEnvironment,
      plantingSpots: plantingEnvironment
        ? plantingEnvironment.plantingSpots
        : [],
      isSpotClicked: false,
      selectedTreeInSpot: {},
      selectedPlantingSpotModel: {},
    };
  }

  _renderItem = (plantingSpot, i) => (
    <TouchableOpacity
      style={
        plantingSpot && plantingSpot.amount > 0 ? styles.grownItem : styles.item
      }
      key={i}
      onPress={() => this._onSelectPlantingSpot(plantingSpot)}>
      <Text style={styles.itemText}>
        {plantingSpot && plantingSpot.amount > 0 ? plantingSpot.amount : ''}
      </Text>
    </TouchableOpacity>
  );

  _onSelectPlantingSpot = async selectedPlantingSpotModel => {
    const {navigation} = this.props;
    const {plantingSpots, plantingEnvironment} = this.state;
    if (selectedPlantingSpotModel.amount <= 0) {
      navigation.dispatch(
        StackActions.replace('TreeInformation', {
          plantingSpots,
          selectedPlantingSpotModel,
          plantingEnvironment,
        }),
      );
    } else {
      await this._createTreeInfoInSpotTile(selectedPlantingSpotModel);
    }
  };

  _createTreeInfoInSpotTile = async selectedPlantingSpotModel => {
    const plantingSpotResponse = await getPlantingSpotById(
      selectedPlantingSpotModel.id,
    );
    let selectedTreeInSpot = {};
    if (plantingSpotResponse && plantingSpotResponse.result) {
      if (plantingSpotResponse.result.tree) {
        selectedTreeInSpot = plantingSpotResponse.result.tree;
        this.setState({selectedTreeInSpot});
      } else {
        const treeId = plantingSpotResponse.result.treeId;
        const getTreeResponse = await getTreeById(treeId);
        this.setState({selectedTreeInSpot: getTreeResponse.result});
      }
    }
    this.setState({selectedPlantingSpotModel});
    this.setState({isSpotClicked: true});
  };

  _getEmptySpot = () => {
    let numberOfEmptySpot = 0;
    const {plantingSpots} = this.state;
    if (plantingSpots) {
      plantingSpots.forEach(plantingSpot => {
        if (plantingSpot.amount === 0) {
          numberOfEmptySpot++;
        }
      });
    }
    return numberOfEmptySpot;
  };

  _navigateToPlantingProcessOverview = () => {
    const {navigation} = this.props;
    const {
      selectedPlantingSpotModel,
      selectedTreeInSpot,
      plantingSpots,
      plantingEnvironment,
    } = this.state;
    navigation.dispatch(
      StackActions.replace('PlantingProcessOverview', {
        plantingSpotModel: selectedPlantingSpotModel,
        treeInfo: selectedTreeInSpot,
        plantingSpots,
        plantingEnvironment,
      }),
    );
  };

  _doBackGardenList = () => {
    const {navigation} = this.props;
    navigation.dispatch(StackActions.replace('PlantingEnvironment'));
  };

  render() {
    const {
      gardenWidth,
      plantingSpots,
      isSpotClicked,
      selectedTreeInSpot,
      selectedPlantingSpotModel,
    } = this.state;
    const pictureURL = selectedTreeInSpot.picture;
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.gridContainer}>
          <ScrollView>
            <Grid
              style={styles.list}
              renderItem={this._renderItem}
              data={plantingSpots}
              numColumns={gardenWidth}
            />
          </ScrollView>
        </SafeAreaView>

        <View>
          <Button
            onPress={this._doBackGardenList}
            title="Back to Garden List"
          />
        </View>

        <View style={styles.emptyCount}>
          <Text style={styles.emptyText}>
            {`${this._getEmptySpot()} Empty Spots`}
          </Text>
        </View>

        {isSpotClicked && (
          <TouchableOpacity
            onPress={() => this._navigateToPlantingProcessOverview()}>
            <View style={styles.treeInfo}>
              <ListItem containerStyle={styles.container}>
                <Avatar
                  rounded
                  size="small"
                  containerStyle={styles.avatarItem}
                  source={
                    pictureURL
                      ? {uri: pictureURL}
                      : require('../../../assets/images/unknown-garden.png')
                  }
                />
                <ListItem.Content>
                  <ListItem.Title style={styles.treeName}>
                    {selectedTreeInSpot.name}
                  </ListItem.Title>
                  <ListItem.Subtitle>
                    Amount: {selectedPlantingSpotModel.amount}
                  </ListItem.Subtitle>
                </ListItem.Content>
              </ListItem>
            </View>
          </TouchableOpacity>
        )}
      </BackgroundScreen>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <GardenPlanting {...props} navigation={navigation} />;
};
