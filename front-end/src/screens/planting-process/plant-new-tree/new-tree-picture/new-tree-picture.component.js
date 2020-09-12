import React from 'react';
import styles from './new-tree-picture.style';
import {Avatar, ListItem} from 'react-native-elements';

const NewTreePicture = props => {
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

export default NewTreePicture;
