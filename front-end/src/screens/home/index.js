import React, {Component} from 'react';
import {View} from 'react-native';
import styles from './home-container.style';
import Calendar from './calendar/calendar.component';

class HomeContainer extends Component {
  render() {
    return (
      <View style={styles.homeColumn}>
        <Calendar />
      </View>
    );
  }
}

export default HomeContainer;
