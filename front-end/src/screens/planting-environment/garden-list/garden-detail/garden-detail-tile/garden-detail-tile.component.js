import React, {Component} from 'react';
import styles from './garden-detail-tile.style';
import {ListItem} from 'react-native-elements';
import {Text, View} from 'react-native';
import GardenDetailShowMoreMenu from './garden-detail-show-more-menu/garden-detail-show-more-menu.component';

class GardenDetailTile extends Component {
  render() {
    return (
      <View style={styles.tileContainer}>
        <ListItem
          roundAvatar={true}
          containerStyle={styles.listItem}
          leftAvatar={{source: this.props.info.image, size: 'medium'}}
          title={this.props.info.name}
          titleStyle={styles.gardenName}
          subtitle={
            <View>
              <Text style={styles.gardenDetail}>
                Size: {this.props.info.details.size}
              </Text>
              <Text style={styles.gardenDetail}>
                Temperature: {this.props.info.details.temperature}
              </Text>
              <Text style={styles.gardenDetail}>
                Light: {this.props.info.details.light}
              </Text>
              <Text style={styles.gardenDetail}>
                Humidity: {this.props.info.details.humidity}
              </Text>
            </View>
          }
          rightTitle={
            <GardenDetailShowMoreMenu
              index={this.props.index}
              info={this.props.info}
              onTriggerPress={this.props.onTriggerPress}
              onBackdropPress={this.props.onBackdropPress}
              onOptionSelect={this.props.onOptionSelect}
            />
          }
        />
      </View>
    );
  }
}

export default GardenDetailTile;
