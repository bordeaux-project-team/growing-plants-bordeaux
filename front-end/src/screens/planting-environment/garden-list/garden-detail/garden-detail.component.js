import React, {Component} from 'react';
import styles from './garden-detail.style';
import {SafeAreaView, ScrollView} from 'react-native';
import GardenDetailTile from './garden-detail-tile/garden-detail-tile.component';
import {MenuProvider} from 'react-native-popup-menu';
import {getPlantingEnvironmentByUser} from '../../../../services/planting-environments-service';

class GardenDetail extends Component {
  constructor(props, ctx) {
    super(props, ctx);
    this.state = {
      gardenInfos: [],
    };
    this.onTriggerPress = this.onTriggerPress.bind(this);
    this.onBackdropPress = this.onBackdropPress.bind(this);
    this.onOptionSelect = this.onOptionSelect.bind(this);
  }

  componentDidMount() {
    this.getGardens().then(gardens => {
      const gardenInfos = gardens.result
        ? gardens.result.map(garden => {
            const light = JSON.parse(garden.light);
            return {
              id: garden.id,
              country: garden.country,
              createdAt: garden.createdAt,
              image: require('../../../../assets/images/unknown-garden.png'),
              name: garden.name,
              width: garden.width,
              length: garden.length,
              size: `${garden.width} x ${garden.length} (m2)`,
              temperature: garden.temperature,
              light: light,
              lightType: light.lightType,
              humidity: garden.humidity,
              environmentType: garden.environmentType,
              exposureTime: garden.exposureTime,
              plantingSpots: garden.plantingSpots,
              updatedAt: garden.updatedAt,
              user: garden.user,
              userId: garden.userId,
            };
          })
        : [];
      this.setState({gardenInfos});
    });
  }

  async getGardens() {
    return await getPlantingEnvironmentByUser();
  }

  onTriggerPress(index) {
    const gardenInfos = [...this.state.gardenInfos];
    gardenInfos[index].isOpen = true;
    this.setState({gardenInfos});
  }

  onBackdropPress(index) {
    const gardenInfos = [...this.state.gardenInfos];
    gardenInfos[index].isOpen = false;
    this.setState({gardenInfos});
  }

  onOptionSelect(value, index) {
    const gardenInfos = [...this.state.gardenInfos];
    gardenInfos[index].isOpen = false;
    this.setState({gardenInfos});
  }

  render() {
    const {gardenInfos} = this.state;
    return (
      <SafeAreaView style={styles.detailContainer}>
        <ScrollView>
          <MenuProvider>
            {gardenInfos.map((gardenInfo, index) => (
              <GardenDetailTile
                key={index}
                index={index}
                gardenInfo={gardenInfo}
                onTriggerPress={this.onTriggerPress}
                onBackdropPress={this.onBackdropPress}
                onOptionSelect={this.onOptionSelect}
              />
            ))}
          </MenuProvider>
        </ScrollView>
      </SafeAreaView>
    );
  }
}

export default GardenDetail;
