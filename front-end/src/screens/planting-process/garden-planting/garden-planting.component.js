import React, {Component} from 'react';
import {Text, View} from 'react-native';
import styles from './garden-planting.style';
import Grid from 'react-native-grid-component';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {getPlantingEnvironmentByUser} from '../../../services/planting-environments-service';

class GardenPlanting extends Component {
  constructor(props) {
    super(props);
    this.state = {
      planingProcess: undefined,
      gardenWidth: 5,
      gardenLength: 10,
      numberOfPlants: Array(20),
    };
  }

  componentDidMount() {
    getPlantingEnvironmentByUser().then(data =>
      console.log('aaaaaaaaaaaaa', data),
    );
  }

  _renderItem = (data, i) => (
    <View style={styles.item} key={i}>
      <Text style={styles.itemText}>{i + 1}</Text>
    </View>
  );

  render() {
    const {gardenWidth, numberOfPlants} = this.state;

    return (
      <BackgroundScreen>
        <Grid
          style={styles.list}
          renderItem={this._renderItem}
          data={numberOfPlants}
          numColumns={gardenWidth}
        />
      </BackgroundScreen>
    );
  }
}

export default GardenPlanting;
