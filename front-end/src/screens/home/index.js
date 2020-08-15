import React, {Component} from 'react';
import {View} from 'react-native';
import styles from './home-container.style';
import BackgroundScreen from '../common-screens/background-screen.component';
import Calendar from './calendar/calendar.component';
import ToDoTask from './to-do-task/to-do-task.component';

class HomeContainer extends Component {
  render() {
    return (
      <BackgroundScreen>
        <View style={styles.homeColumn}>
          <Calendar />
          {/*<ToDoTask />*/}
        </View>
      </BackgroundScreen>
    );
  }
}

export default HomeContainer;
