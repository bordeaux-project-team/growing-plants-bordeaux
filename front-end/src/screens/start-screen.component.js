import React from 'react';
import LoginContainer from './login';
import BackgroundScreen from './common-screens/background-screen.component';
import LOGIN_SCREEN from './login/login-screen.const';

const StartScreen = props => {
  return (
    <BackgroundScreen>
      <LoginContainer
        screenType={props.route ? props.route.params.screenType : undefined}
      />
    </BackgroundScreen>
  );
};

StartScreen.defaultProps = {
  screenType: LOGIN_SCREEN.login,
};

export default StartScreen;
