import React, {Component} from 'react';
import {View} from 'react-native';
import SelectBox from '../../../common-elements/select-box.component';
import styles from './garden-select-box-bar.style';

class GardenSelectBoxBar extends Component {
  state = {
    search: '',
    selectedItems: [],
  };

  items = [
    {value: '1', label: 'America'},
    {value: '2', label: 'Argentina'},
    {value: '3', label: 'Armenia'},
    {value: '4', label: 'Australia'},
    {value: '5', label: 'Austria'},
    {value: '6', label: 'Azerbaijan'},
    {value: '7', label: 'Argentina'},
    {value: '8', label: 'Belarus'},
    {value: '9', label: 'Belgium'},
    {value: '10', label: 'Brazil'},
  ];

  onSelectedItemsChange = selectedItems => {
    this.setState({selectedItems});
  };

  render() {
    const {selectedItems} = this.state;

    return (
      <View style={styles.conditionContainer}>
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.items}
          onValueChange={this.onSelectedItemsChange}
          selectedValue={selectedItems}
        />
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.items}
          onValueChange={this.onSelectedItemsChange}
          selectedValue={selectedItems}
        />
        <SelectBox
          containerStyle={styles.selectBoxContainer}
          selectBoxStyle={styles.selectBoxStyle}
          items={this.items}
          onValueChange={this.onSelectedItemsChange}
          selectedValue={selectedItems}
        />
      </View>
    );
  }
}

export default GardenSelectBoxBar;
