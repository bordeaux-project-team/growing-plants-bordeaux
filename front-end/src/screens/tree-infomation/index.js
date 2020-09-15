import React, {Component} from 'react';
import TreeSearch from './tree-search/tree-search.component';

class TreeInformationContainer extends Component {
  render() {
    const plantingSpots = this.props.route
      ? this.props.route.params.plantingSpots
      : {};
    const selectedPlantingSpotModel = this.props.route
      ? this.props.route.params.selectedPlantingSpotModel
      : {};
    const plantingEnvironment = this.props.route
      ? this.props.route.params.plantingEnvironment
      : {};
    return (
      <TreeSearch
        plantingEnvironment={plantingEnvironment}
        plantingSpots={plantingSpots}
        plantingSpotModel={selectedPlantingSpotModel}
      />
    );
  }
}

export default TreeInformationContainer;
