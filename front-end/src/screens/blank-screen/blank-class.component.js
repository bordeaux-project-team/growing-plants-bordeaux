import React, {Component} from 'react';
import {Text, View} from 'react-native';
import styles from './blank.style';

class BlankClass extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    const {} = this.state;

    return (
      <View style={styles.blankStyle}>
        <Text>This blank class is a form use to create others</Text>
      </View>
    );
  }
}

export default BlankClass;
