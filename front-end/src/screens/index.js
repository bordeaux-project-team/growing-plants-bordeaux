import React, {Component} from 'react';
import MainScreen from './main-screen.component';
import BackgroundScreen from './common-screens/background-screen.component';
import HomeContainer from './home';
import StartScreen from './start-screen.component';
import {NavigationContainer} from '@react-navigation/native';
import {AsyncStorage} from 'react-native';

//check login already or not here when open app
class MainScreenContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      token: '',
    };
  }

  componentDidMount() {
    this._retrieveToken();
  }

  _retrieveToken = async () => {
    let savedToken;
    try {
      savedToken = await AsyncStorage.getItem('token');
    } catch (error) {
      console.log('MainScreenContainer > error get token', error);
    }
    this.setState({token: savedToken});
  };

  render() {
    const {token} = this.state;
    console.log('MainScreenContainer > token', token);
    return token ? <MainScreen /> : <StartScreen />;
  }
}

export {MainScreenContainer};
