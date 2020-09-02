import React, {Component} from 'react';
import {
  SafeAreaView,
  ScrollView,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';
import styles from './garden-planting.style';
import Grid from 'react-native-grid-component';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {getPlantingSpotsByPlantingEnvironmentId} from '../../../services/planting-environments-service';

class GardenPlanting extends Component {
  constructor(props) {
    super(props);
    this.state = {
      planingProcess: undefined,
      gardenWidth: 0,
      gardenLength: 0,
      plantingEnvironment: props.plantingEnvironment,
      plantingSpots: [],
      exitedPlatingSpots: [],
    };
  }

  componentDidMount() {
    this._getPlantingSpots();
  }

  _getPlantingSpots = () => {
    const {plantingEnvironment} = this.state;
    const gardenWidth = plantingEnvironment ? plantingEnvironment.width : 0;
    const gardenLength = plantingEnvironment ? plantingEnvironment.length : 0;
    const gardenId = plantingEnvironment ? plantingEnvironment.id : null;
    const numberOfSpots = gardenWidth * gardenLength;
    let initialSpots = new Array(numberOfSpots);
    let exitedPlatingSpots = [];
    getPlantingSpotsByPlantingEnvironmentId(gardenId).then(
      plantingSpotsData => {
        exitedPlatingSpots = plantingSpotsData.result
          ? plantingSpotsData.result
          : [];
      },
    );
    for (let i = 0; i < numberOfSpots; i++) {
      const plantingSpotModel = {
        treeId: null, // required
        position: i, // index of spots
        amount: 0,
        plantingEnvironmentId: gardenId, // required
      };
      initialSpots[i] = plantingSpotModel;
    }
    for (let j = 0; j < exitedPlatingSpots.length; j++) {
      const exitedPlatingSpot = exitedPlatingSpots[j];
      const position = exitedPlatingSpot.position;
      const plantingSpotModel = {
        treeId: exitedPlatingSpot.treeId, // required
        position: position, // index of spots
        amount: exitedPlatingSpot.amount,
        plantingEnvironmentId: gardenId, // required
      };
      initialSpots[position] = exitedPlatingSpot;
    }
    this.setState({plantingSpots: initialSpots});
    this.setState({exitedPlatingSpots});
  };

  _renderItem = (plantingSpot, i) => (
    <TouchableOpacity
      style={styles.item}
      key={i}
      onPress={() => this._onSelectPlantingSpot(plantingSpot)}>
      <Text style={styles.itemText}>
        {plantingSpot ? plantingSpot.amount : 0}
      </Text>
    </TouchableOpacity>
  );

  _onSelectPlantingSpot = plantingSpot => {
    console.log('aaaaaaaaaaaaaa work', plantingSpot);
  };

  render() {
    const {gardenWidth, plantingSpots, exitedPlatingSpots} = this.state;
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
        <View style={styles.emptyCount}>
          <Text style={styles.emptyText}>
            {`${plantingSpots.length - exitedPlatingSpots.length} Empty Spots`}
          </Text>
        </View>
        <View style={styles.treeInfo}>
          <Text style={styles.emptyText}>hello</Text>
        </View>
      </BackgroundScreen>
    );
  }
}

export default GardenPlanting;
