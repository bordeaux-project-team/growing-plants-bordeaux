import React, {Component} from 'react';
import MainScreen from './main-screen.component';
import BackgroundScreen from './common-screens/background-screen.component';
import HomeContainer from './home';
import StartScreen from './start-screen.component';

//check login already or not here when open app
class MainScreenContainer extends Component {
  render() {
    return <MainScreen />;
  }
}

export {MainScreenContainer};
