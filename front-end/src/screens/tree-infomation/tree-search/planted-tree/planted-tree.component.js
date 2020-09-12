import React, {Component} from 'react';
import {Text, View} from 'react-native';
import styles from './planted-tree.style';
import PlantedTreeTile from './planted-tree-tile/planted-tree-tile.component';
import {useNavigation} from '@react-navigation/native';
import {getPlantedTrees} from '../../../../services/tree-service';
import {List} from 'native-base';

class PlantedTree extends Component {
  constructor(props) {
    super(props);
    this.state = {
      limitNumberOfShownTree: 2,
      plantedTrees: [],
    };
  }

  componentDidMount() {
    this._getPlantedTrees();
  }

  _getPlantedTrees = () => {
    const {limitNumberOfShownTree} = this.state;
    let plantedTrees = [];
    getPlantedTrees(limitNumberOfShownTree).then(plantedTreesData => {
      plantedTrees = plantedTreesData.result ? plantedTreesData.result : [];
    });
    this.setState({plantedTrees});
  };

  render() {
    const {plantedTrees} = this.state;
    return (
      <View style={styles.gridContainer}>
        <Text style={styles.titleText}>Planted Trees</Text>
        {plantedTrees.length ? (
          <List
            style={styles.listContainer}
            horizontal={true}
            dataArray={plantedTrees}
            renderRow={plantedTreeInfo => (
              <PlantedTreeTile plantedTreeInfo={plantedTreeInfo} />
            )}
          />
        ) : (
          <Text>No planted trees yet! Get start now!</Text>
        )}
      </View>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <PlantedTree {...props} navigation={navigation} />;
};
