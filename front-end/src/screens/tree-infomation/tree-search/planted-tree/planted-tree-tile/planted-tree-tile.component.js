import React, {Component} from 'react';
import styles from './planted-tree-tile.style';
import {Avatar, ListItem} from 'react-native-elements';
import {TouchableOpacity, View} from 'react-native';
import {StackActions, useNavigation} from '@react-navigation/native';

class PlantedTreeTile extends Component {
  constructor(props) {
    super(props);
  }

  _navigateToTreeDetail() {
    const {navigation, plantedTreeInfo} = this.props;
    navigation.dispatch(
      StackActions.replace('TreeDetailInfo', {
        treeInfo: plantedTreeInfo,
      }),
    );
  }

  render() {
    const {plantedTreeInfo} = this.props;
    const pictureURL =
      plantedTreeInfo && plantedTreeInfo.picture
        ? plantedTreeInfo.picture.source
        : '';
    return (
      <TouchableOpacity onPress={() => this._navigateToTreeDetail()}>
        <View style={styles.tileContainer}>
          <ListItem containerStyle={styles.listItem}>
            <Avatar
              rounded
              size="small"
              containerStyle={styles.avatarItem}
              source={
                pictureURL
                  ? {uri: pictureURL}
                  : require('../../../../../assets/images/unknown-garden.png')
              }
            />
            <ListItem.Content>
              <ListItem.Title style={styles.treeName}>
                {plantedTreeInfo.name}
              </ListItem.Title>
            </ListItem.Content>
          </ListItem>
        </View>
      </TouchableOpacity>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <PlantedTreeTile {...props} navigation={navigation} />;
};
