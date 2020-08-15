import React from 'react';
import LoginContainer from './login';
import BackgroundScreen from './common-screens/background-screen.component';

const StartScreen = props => {
  return (
    <BackgroundScreen>
      <LoginContainer />
    </BackgroundScreen>
  );
};

export default StartScreen;
