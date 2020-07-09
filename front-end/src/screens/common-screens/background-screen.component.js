import React from 'react';
import {ImageBackground, StatusBar, View} from 'react-native';
import styles from './background-screen.style';

const BackgroundScreen = props => {
  return (
    <View style={styles.root}>
      <StatusBar barStyle="light-content" backgroundColor="rgba(0,0,0,0)" />
      <View style={styles.background}>
        <ImageBackground
          style={styles.rect}
          imageStyle={styles.rect_imageStyle}
          source={require('../../assets/images/background-image.jpg')}>
          {props.children}
        </ImageBackground>
      </View>
    </View>
  );
};

export default BackgroundScreen;
