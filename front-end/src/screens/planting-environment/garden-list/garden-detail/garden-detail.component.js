import React, {Component} from 'react';
import styles from './garden-detail.style';
import {SafeAreaView, ScrollView} from 'react-native';
import GardenDetailTile from './garden-detail-tile/garden-detail-tile.component';
import {MenuProvider} from 'react-native-popup-menu';

class GardenDetail extends Component {
  constructor(props, ctx) {
    super(props, ctx);
    this.state = {
      gardenInfos: [
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'Hu Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
        {
          image: require('../../../../assets/images/unknown-garden.png'),
          name: 'HNTA Garden',
          details: {
            size: '20 x 20 (m2)',
            temperature: 'Hot',
            light: 'Full',
            humidity: '30%',
          },
        },
      ],
    };
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
            {gardenInfos.map((info, index) => (
              <GardenDetailTile
                key={index}
                index={index}
                info={info}
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
