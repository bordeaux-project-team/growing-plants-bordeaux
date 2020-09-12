import React from 'react';
import styles from './tree-wallpaper.style';
import {Avatar, ListItem} from 'react-native-elements';

const TreeWallpaper = props => {
  const {treeInfo} = props;
  const pictureURL =
    treeInfo && treeInfo.picture ? treeInfo.picture.source : '';
  return (
    <ListItem containerStyle={styles.container}>
      <Avatar
        rounded
        size="xlarge"
        containerStyle={styles.avatarItem}
        source={
          pictureURL
            ? {uri: pictureURL}
            : require('../../../../assets/images/unknown-garden.png')
        }
      />
      <ListItem.Content>
        <ListItem.Title style={styles.treeName}>{treeInfo.name}</ListItem.Title>
      </ListItem.Content>
    </ListItem>
  );
};

export default TreeWallpaper;
