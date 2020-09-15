import React, {Component} from 'react';
import GardenPlanting from './garden-planting/garden-planting.component';

class PlantingProcessContainer extends Component {
  render() {
    const plantingEnvironment =
      this.props.route && this.props.route.params
        ? this.props.route.params.plantingEnvironment
        : {};
    return <GardenPlanting plantingEnvironment={plantingEnvironment} />;
  }
}

export default PlantingProcessContainer;
