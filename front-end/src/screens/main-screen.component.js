import React from 'react';
import {ImageBackground, StatusBar, View} from 'react-native';
import styles from './main-screen.style';
import LoginContainer from './login';

const MainScreen = props => {
  return (
    <View style={styles.root}>
      <StatusBar barStyle="light-content" backgroundColor="rgba(0,0,0,0)" />
      <View style={styles.background}>
        <ImageBackground
          style={styles.rect}
          imageStyle={styles.rect_imageStyle}
          source={require('../../src/assets/images/background-image.jpg')}>
          <LoginContainer />
        </ImageBackground>
      </View>
    </View>
  );
};

export default MainScreen;
