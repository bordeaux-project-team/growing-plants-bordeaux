import React, {Component} from 'react';
import {View} from 'react-native';
import SelectBox from '../../../common-elements/select-box.component';
import styles from './tree-select-box-bar.style';

class TreeSelectBoxBar extends Component {
  state = {
    search: '',
    plantTypeItems: [],
    temperatureItems: [],
    waterLevelItems: [],
  };

  plantTypeItems = [
    {value: null, label: 'Plant Type'},
    {value: 'Herbs', label: 'Herbs'},
    {value: 'Shrubs', label: 'Shrubs'},
    {value: 'Trees', label: 'Trees'},
    {value: 'Climbers', label: 'Climbers'},
    {value: 'Creepers', label: 'Creepers'},
    {value: 'Fruit', label: 'Fruit'},
  ];

  temperatureItems = [
    {value: null, label: 'Temperature'},
    {value: 'hot', label: 'Hot'},
    {value: 'cold', label: 'Cold'},
  ];

  waterLevelItems = [
    {value: null, label: 'Water Level'},
    {value: 'low', label: 'Low'},
    {value: 'medium', label: 'Medium'},
    {value: 'high', label: 'High'},
  ];

  onSelectedPlantTypeItemsChange = plantTypeItems => {
    this.setState({plantTypeItems});
    const {searchByPlantType} = this.props;
    searchByPlantType(plantTypeItems);
  };

  onSelectedTemperatureItemsChange = temperatureItems => {
    this.setState({temperatureItems});
  };

  onSelectedWaterLevelItemsChange = waterLevelItems => {
    this.setState({waterLevelItems});
  };

  render() {
    const {plantTypeItems, temperatureItems, waterLevelItems} = this.state;

    return (
      <View style={styles.conditionContainer}>
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.plantTypeItems}
          onValueChange={this.onSelectedPlantTypeItemsChange}
          selectedValue={plantTypeItems}
        />
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.temperatureItems}
          onValueChange={this.onSelectedTemperatureItemsChange}
          selectedValue={temperatureItems}
        />
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.waterLevelItems}
          onValueChange={this.onSelectedWaterLevelItemsChange}
          selectedValue={waterLevelItems}
        />
      </View>
    );
  }
}

export default TreeSelectBoxBar;
