import React, {Component} from 'react';
import {Button, View} from 'react-native';
import styles from './tree-search.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import TreeSearchBar from './tree-search-bar/search-screen-bar.component';
import TreeSelectBoxBar from './tree-select-box-bar/tree-select-box-bar.component';
import PlantedTree from './planted-tree/planted-tree.component';
import TreeList from './tree-list/tree-list.component';
import {searchTree} from '../../../services/tree-service';
import {StackActions, useNavigation} from '@react-navigation/native';

class TreeSearch extends Component {
  constructor(props) {
    super(props);
    const searchTreeModel = {
      text: '',
      plantType: '',
      temperature: '',
      waterLevel: null,
      pageNumber: 1,
    };
    this.state = {
      searchTreeModel: searchTreeModel,
      treeList: [],
      pageNumber: 1,
      treeListResult: {},
      plantingSpots: props.plantingSpots ? props.plantingSpots : {},
      plantingSpotModel: props.plantingSpotModel ? props.plantingSpotModel : {},
      plantingEnvironment: props.plantingEnvironment
        ? props.plantingEnvironment
        : {},
    };
  }

  componentDidMount() {
    const {searchTreeModel} = this.state;
    this._setStateOfTreeSearch(searchTreeModel);
  }

  _setStateOfTreeSearch = searchTreeModel => {
    this.setState({searchTreeModel});
    this._getTreeSearchResult(searchTreeModel).then(searchResult => {
      const treeListResult = searchResult.result ? searchResult.result : {};
      this.setState({treeListResult});
      const treeList = this._getTreeList(treeListResult);
      this.setState({treeList});
    });
  };

  _getTreeSearchResult = async searchTreeModel => {
    const searchResult = await searchTree(searchTreeModel);
    return searchResult;
  };

  _getTreeList = treeListResult => {
    let treeList = [];
    if (
      treeListResult &&
      treeListResult.trees &&
      treeListResult.trees.length > 0
    ) {
      treeList = treeListResult.trees;
    }
    return treeList;
  };

  _searchByText = text => {
    const {searchTreeModel} = this.state;
    searchTreeModel.text = text;
    this._setStateOfTreeSearch(searchTreeModel);
  };

  _searchByPlantType = plantType => {
    const {searchTreeModel} = this.state;
    searchTreeModel.plantType = plantType;
    this._setStateOfTreeSearch(searchTreeModel);
  };

  _loadMorePage = () => {
    const {treeListResult, searchTreeModel} = this.state;
    let nextSearchTreeModel;
    if (treeListResult && treeListResult.nextPage) {
      nextSearchTreeModel = treeListResult.nextPage;
    } else {
      searchTreeModel.pageNumber = 1;
      nextSearchTreeModel = searchTreeModel;
    }
    this._setStateOfTreeSearch(nextSearchTreeModel);
  };

  _doBackGardenProcess = () => {
    const {navigation, plantingEnvironment} = this.props;
    navigation.dispatch(
      StackActions.replace('PlantingProcess', {
        plantingEnvironment,
      }),
    );
  };

  render() {
    const {
      treeList,
      plantingSpots,
      plantingSpotModel,
      plantingEnvironment,
    } = this.state;
    return (
      <BackgroundScreen>
        <View style={styles.treeSearchBackground}>
          <TreeSearchBar searchByText={this._searchByText} />
          <TreeSelectBoxBar searchByPlantType={this._searchByPlantType} />
          <PlantedTree />
          <TreeList
            treeList={treeList}
            plantingSpots={plantingSpots}
            plantingSpotModel={plantingSpotModel}
            plantingEnvironment={plantingEnvironment}
            loadMorePage={this._loadMorePage}
          />
        </View>
        <View>
          <Button
            onPress={this._doBackGardenProcess}
            title="Back to Garden Process"
          />
        </View>
      </BackgroundScreen>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <TreeSearch {...props} navigation={navigation} />;
};
