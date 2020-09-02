import React, {Component} from 'react';
import GardenPlanting from './garden-planting/garden-planting.component';

class PlantingProcessContainer extends Component {
  render() {
    return (
      <GardenPlanting
        plantingEnvironment={
          this.props.route ? this.props.route.params.plantingEnvironment : {}
        }
      />
    );
  }
}

export default PlantingProcessContainer;
