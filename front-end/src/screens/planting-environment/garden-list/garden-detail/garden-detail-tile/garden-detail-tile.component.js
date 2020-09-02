import React, {Component} from 'react';
import styles from './garden-detail-tile.style';
import {ListItem} from 'react-native-elements';
import {Text, TouchableOpacity, View} from 'react-native';
import GardenDetailShowMoreMenu from './garden-detail-show-more-menu/garden-detail-show-more-menu.component';
import {useNavigation} from '@react-navigation/native';

class GardenDetailTile extends Component {
  constructor(props) {
    super(props);
  }

  _navigateToPlantingProcess() {
    const {navigation, gardenInfo} = this.props;
    navigation.navigate('PlantingProcess', {
      plantingEnvironment: gardenInfo,
    });
  }

  render() {
    return (
      <TouchableOpacity onPress={() => this._navigateToPlantingProcess()}>
        <View style={styles.tileContainer}>
          <ListItem
            roundAvatar={true}
            containerStyle={styles.listItem}
            leftAvatar={{source: this.props.gardenInfo.image, size: 'medium'}}
            title={this.props.gardenInfo.name}
            titleStyle={styles.gardenName}
            subtitle={
              <View>
                <Text style={styles.gardenDetail}>
                  Size: {this.props.gardenInfo.size}
                </Text>
                <Text style={styles.gardenDetail}>
                  Temperature: {this.props.gardenInfo.temperature}C
                </Text>
                <Text style={styles.gardenDetail}>
                  Light: {this.props.gardenInfo.lightType}
                </Text>
                <Text style={styles.gardenDetail}>
                  Humidity: {this.props.gardenInfo.humidity}%
                </Text>
              </View>
            }
            rightTitle={
              <GardenDetailShowMoreMenu
                index={this.props.index}
                gardenInfo={this.props.gardenInfo}
                onTriggerPress={this.props.onTriggerPress}
                onBackdropPress={this.props.onBackdropPress}
                onOptionSelect={this.props.onOptionSelect}
              />
            }
          />
        </View>
      </TouchableOpacity>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <GardenDetailTile {...props} navigation={navigation} />;
};
