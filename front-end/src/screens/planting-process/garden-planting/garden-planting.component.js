import React, {Component} from 'react';
import {Text, View} from 'react-native';
import styles from './garden-planting.style';
import Grid from 'react-native-grid-component';
import BackgroundScreen from '../../common-screens/background-screen.component';

class GardenPlanting extends Component {
  constructor(props) {
    super(props);
    this.state = {
      gardenWidth: 6,
      numberOfPlants: [
        '10',
        '20',
        '30',
        '10',
        '20',
        '10',
        '20',
        '30',
        '10',
        '20',
        '10',
        '20',
        '30',
        '10',
        '20',
        '10',
        '20',
        '30',
        '10',
        '20',
      ],
    };
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
