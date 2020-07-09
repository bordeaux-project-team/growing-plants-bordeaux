import React, {Component} from 'react';
import {View} from 'react-native';
import styles from './home-container.style';
import Calendar from './calendar/calendar.component';
import BackgroundScreen from '../common-screens/background-screen.component';

class HomeContainer extends Component {
  render() {
    return (
      <BackgroundScreen>
        <View style={styles.homeColumn}>
          <Calendar />
        </View>
      </BackgroundScreen>
    );
  }
}

export default HomeContainer;
