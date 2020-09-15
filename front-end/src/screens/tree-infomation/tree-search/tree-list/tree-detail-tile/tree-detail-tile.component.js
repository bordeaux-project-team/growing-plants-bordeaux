import React, {Component} from 'react';
import styles from './tree-detail-tile.style';
import {Avatar, ListItem} from 'react-native-elements';
import {Text, TouchableOpacity, View} from 'react-native';
import {StackActions, useNavigation} from '@react-navigation/native';

class TreeDetailTile extends Component {
  constructor(props) {
    super(props);
  }

  _navigateToTreeDetail() {
    const {
      navigation,
      plantingSpots,
      plantingSpotModel,
      treeInfo,
      plantingEnvironment,
    } = this.props;
    navigation.dispatch(
      StackActions.replace('TreeDetailInfo', {
        plantingSpots,
        plantingSpotModel,
        treeInfo,
        plantingEnvironment,
      }),
    );
  }

  render() {
    const {treeInfo} = this.props;
    const pictureURL =
      treeInfo && treeInfo.picture ? treeInfo.picture.source : '';
    const treeName =
      treeInfo && treeInfo.name.length <= 10
        ? treeInfo.name
        : treeInfo.name.slice(0, 10) + '...';
    return (
      <TouchableOpacity onPress={() => this._navigateToTreeDetail()}>
        <View style={styles.tileContainer}>
          <View style={styles.listItem}>
            <Avatar
              rounded
              size="large"
              containerStyle={styles.avatarItem}
              source={
                pictureURL
                  ? {uri: pictureURL}
                  : require('../../../../../assets/images/unknown-garden.png')
              }
            />
            <Text style={styles.treeName}>{treeName}</Text>
          </View>
        </View>
      </TouchableOpacity>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <TreeDetailTile {...props} navigation={navigation} />;
};
