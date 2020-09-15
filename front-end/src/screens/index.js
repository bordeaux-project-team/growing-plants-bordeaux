import React, {Component} from 'react';
import StartScreen from './start-screen.component';
import {AsyncStorage} from 'react-native';
import PlantingEnvironmentContainer from './planting-environment';

//check login already or not here when open app
class MainScreenContainer extends Component {
  constructor(props) {
    super(props);
    this.state = {
      savedToken: '',
    };
  }

  async componentDidMount() {
    await this._retrieveToken().then(savedToken => this.setState({savedToken}));
  }

  _retrieveToken = async () => {
    let savedToken;
    try {
      savedToken = await AsyncStorage.getItem('token');
    } catch (error) {
      console.log('MainScreenContainer > error get token', error);
    }
    return savedToken;
  };

  render() {
    const {savedToken} = this.state;
    console.log('MainScreenContainer > token', savedToken);
    // return token ? <MainScreen /> : <StartScreen />;
    return savedToken ? <PlantingEnvironmentContainer /> : <StartScreen />;
  }
}

export {MainScreenContainer};
