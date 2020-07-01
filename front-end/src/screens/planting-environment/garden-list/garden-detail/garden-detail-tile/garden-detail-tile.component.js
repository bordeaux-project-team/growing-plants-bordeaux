import React, {Component} from 'react';
import styles from './garden-detail-tile.style';
import {ListItem, Icon} from 'react-native-elements';
import {Text, View} from 'react-native';
import Menu, {
  MenuOptions,
  MenuOption,
  MenuTrigger,
} from 'react-native-popup-menu';

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
          rightTitle={this.getMenuView(
            this.props.index,
            this.props.info.isOpen,
          )}
        />
      </View>
    );
  }

  getMenuView(index, isOpen) {
    return (
      <Menu opened={isOpen}>
        <MenuTrigger
          onBackdropPress={() => this.props.onBackdropPress(index)}
          onSelect={value => this.props.onOptionSelect(value, index)}>
          <Icon
            onPress={() => this.props.onTriggerPress(index)}
            type="material"
            name="more-vert"
          />
        </MenuTrigger>
        <MenuOptions>
          <MenuOption value={1} text="Edit" />
          <MenuOption value={3} disabled={true} text="Remove" />
        </MenuOptions>
      </Menu>
    );
  }
}

export default GardenDetailTile;
