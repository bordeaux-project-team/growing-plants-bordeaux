import React, {Component} from 'react';
import styles from './tree-list.style';
import {useNavigation} from '@react-navigation/native';
import {List} from 'native-base';
import TreeDetailTile from './tree-detail-tile/tree-detail-tile.component';
import {Text, View} from 'react-native';

class TreeList extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    const {
      treeList,
      loadMorePage,
      plantingSpots,
      plantingSpotModel,
      plantingEnvironment,
    } = this.props;
    return (
      <View>
        <List
          style={styles.listContainer}
          horizontal={true}
          dataArray={treeList}
          renderRow={treeInfo => (
            <TreeDetailTile
              treeInfo={treeInfo}
              plantingSpots={plantingSpots}
              plantingSpotModel={plantingSpotModel}
              plantingEnvironment={plantingEnvironment}
            />
          )}
        />
        <Text style={styles.loadMore} onPress={loadMorePage}>
          {treeList.length > 0 ? 'Load more...' : 'No more tree... Turn back!'}
        </Text>
      </View>
    );
  }
}

TreeList.defaultProps = {
  searchTreeModel: {
    text: '',
    plantType: '',
    temperature: '',
    waterLevel: null,
    pageNumber: 1,
  },
};

export default props => {
  const navigation = useNavigation();
  return <TreeList {...props} navigation={navigation} />;
};
