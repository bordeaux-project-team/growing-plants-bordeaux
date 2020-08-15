import React, {Component} from 'react';
import BackgroundScreen from '../../common-screens/background-screen.component';
import InputText from '../../common-elements/input-text.component';
import styles from './garden-detail-info.style';
import {ScrollView, Switch, Text, View} from 'react-native';
import SelectBox from '../../common-elements/select-box.component';
import TouchButton from '../../common-elements/button.component';
import InputSlider from '../../common-elements/input-slider.component';
import {
  DialogComponent,
  SlideAnimation,
  DialogTitle,
} from 'react-native-dialog-component';
import AddNewLightDialog from './dialog/add-new-light-dialog.component';

class GardenDetailInfo extends Component {
  constructor() {
    super();
    this.state = {
      search: '',
      selectedCountryItems: [],
      selectedTemperatureItems: [],
      selectedHumidityItems: [],
      isOutdoorType: false,
      selectedExposureTime: [],
      selectedWidthDataItems: [],
      selectedLengthDataItems: [],
      lightRange: 0,
      wattage: 0,
      colorTemperature: 0,
      selectedLightTypeItems: [],
    };
  }

  widthDataItems = [
    {value: '0', label: 'Select Width'},
    {value: '1', label: '1ft'},
    {value: '2', label: '2ft'},
    {value: '3', label: '3ft'},
  ];
  lengthDataItems = [
    {value: '0', label: 'Select Length'},
    {value: '1', label: '1ft'},
    {value: '2', label: '2ft'},
    {value: '3', label: '3ft'},
  ];

  onValueChangeWidth = selectedWidthDataItems => {
    this.setState({selectedWidthDataItems});
  };
  onValueChangeLength = selectedLengthDataItems => {
    this.setState({selectedLengthDataItems});
  };

  countryItems = [
    {value: '0', label: 'Select Country'},
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

  temperatureItems = [
    {value: '0', label: 'Select Temperature'},
    {value: '1', label: '10C'},
    {value: '2', label: '20C'},
    {value: '3', label: '30C'},
    {value: '4', label: '40C'},
  ];

  humidityItems = [
    {value: '0', label: 'Select Humidity'},
    {value: '1', label: '10%'},
    {value: '2', label: '20%'},
    {value: '3', label: '30%'},
    {value: '4', label: '40%'},
    {value: '5', label: '50%'},
  ];

  onSelectedCountryItemsChange = selectedCountryItems => {
    this.setState({selectedCountryItems});
  };

  onSelectedTemperatureItemsChange = selectedTemperatureItems => {
    this.setState({selectedTemperatureItems});
  };

  onSelectedHumidityItemsChange = selectedHumidityItems => {
    this.setState({selectedHumidityItems});
  };

  toggleGardenTypeSwitch = isOutdoorType => {
    this.setState({isOutdoorType});
    console.log(isOutdoorType);
  };

  doAddNewLight = () => {
    this.dialogComponent.show();
  };

  onSelectedExposureTimeChange = selectedExposureTime => {
    this.setState({selectedExposureTime});
  };

  exposureTimeItems = [
    {value: '0', label: '0h'},
    {value: '1', label: '1h'},
    {value: '2', label: '2h'},
    {value: '3', label: '3h'},
    {value: '4', label: '4h'},
    {value: '5', label: '5h'},
    {value: '6', label: '6h'},
    {value: '7', label: '7h'},
    {value: '8', label: '8h'},
    {value: '9', label: '9h'},
    {value: '10', label: '10h'},
    {value: '11', label: '11h'},
    {value: '12', label: '12h'},
    {value: '13', label: '13h'},
    {value: '14', label: '14h'},
    {value: '15', label: '15h'},
    {value: '16', label: '16h'},
    {value: '17', label: '17h'},
    {value: '18', label: '18h'},
    {value: '19', label: '19h'},
    {value: '20', label: '20h'},
    {value: '21', label: '21h'},
    {value: '22', label: '22h'},
    {value: '23', label: '23h'},
    {value: '24', label: '24h'},
  ];

  onSliderChange = low => {
    this.setState({lightRange: low});
    console.log(low);
  };

  doCreate = () => {
    console.log('doCreate');
  };

  doCancel = () => {
    console.log('doCancel');
  };

  lightTypeItems = [
    {value: '0', label: 'Type'},
    {value: '1', label: 'LED'},
    {value: '2', label: 'LEC'},
    {value: '3', label: 'HPS'},
    {value: '4', label: 'CFL'},
    {value: '5', label: 'T5'},
  ];

  setSelectedLightTypeItemsState = selectedLightTypeItems => {
    this.setState({selectedLightTypeItems});
  };

  setWattageState = wattage => {
    this.setState({wattage});
  };

  setColorTemperatureState = colorTemperature => {
    this.setState({colorTemperature});
  };

  doNewLightAdd = () => {
    console.log(this.state.selectedLightTypeItems);
    console.log(this.state.wattage);
    console.log(this.state.colorTemperature);
  };

  render() {
    const {
      selectedCountryItems,
      selectedTemperatureItems,
      selectedHumidityItems,
      isOutdoorType,
      selectedExposureTime,
      selectedWidthDataItems,
      selectedLengthDataItems,
      selectedLightTypeItems,
    } = this.state;

    return (
      <BackgroundScreen>
        <DialogComponent
          title={<DialogTitle title="New Light" />}
          ref={dialogComponent => {
            this.dialogComponent = dialogComponent;
          }}
          dialogAnimation={new SlideAnimation({slideFrom: 'bottom'})}>
          <AddNewLightDialog
            lightTypeItems={this.lightTypeItems}
            selectedLightTypeItems={selectedLightTypeItems}
            setSelectedLightTypeItemsState={this.setSelectedLightTypeItemsState}
            setWattageState={this.setWattageState}
            setColorTemperatureState={this.setColorTemperatureState}
            doNewLightAdd={this.doNewLightAdd}
          />
        </DialogComponent>
        <ScrollView style={styles.gardenDetailInfoBackground}>
          <View>
            <InputText
              inputStyle={styles.gardenNameInput}
              placeholder="Garden Name"
              textInputStyle={styles.gardenNameTextInput}
            />
          </View>

          <View style={styles.gardenSize}>
            <SelectBox
              containerStyle={styles.widthAndLengthSelectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.widthDataItems}
              onValueChange={this.onValueChangeWidth}
              selectedValue={selectedWidthDataItems}
            />
            <SelectBox
              containerStyle={styles.widthAndLengthSelectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.lengthDataItems}
              onValueChange={this.onValueChangeLength}
              selectedValue={selectedLengthDataItems}
            />
          </View>

          <Text style={styles.noticeText}>
            (Garden grid lines are spaced 1ft apart)
          </Text>

          <View style={styles.gardenCondition}>
            <SelectBox
              containerStyle={styles.selectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.countryItems}
              onValueChange={this.onSelectedCountryItemsChange}
              selectedValue={selectedCountryItems}
            />
            <SelectBox
              containerStyle={styles.selectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.temperatureItems}
              onValueChange={this.onSelectedTemperatureItemsChange}
              selectedValue={selectedTemperatureItems}
            />
            <SelectBox
              containerStyle={styles.selectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.humidityItems}
              onValueChange={this.onSelectedHumidityItemsChange}
              selectedValue={selectedHumidityItems}
            />
          </View>

          <View style={styles.gardenType}>
            <Text style={styles.gardenTypeText}>Garden Type:</Text>
            <Switch
              style={styles.gardenTypeSwitch}
              onValueChange={this.toggleGardenTypeSwitch}
              value={isOutdoorType}
            />
            <Text style={styles.gardenTypeText}>
              {isOutdoorType ? 'Outdoor' : 'Indoor'}
            </Text>
          </View>

          <View style={styles.gardenLight}>
            <Text style={styles.gardenTypeText}>Light</Text>
            <TouchButton
              doPress={this.doAddNewLight}
              buttonTypeStyle={styles.addNewLightButton}
              buttonTextStyle={styles.addNewLightButtonText}
              buttonText="Add a New Light"
            />
            <View style={styles.exposureTime}>
              <Text style={styles.exposureTimeText}>Exposure Time</Text>
              <SelectBox
                containerStyle={styles.exposureSelectBoxContainer}
                selectBoxStyle={styles.exposureSelectBoxStyle}
                items={this.exposureTimeItems}
                onValueChange={this.onSelectedExposureTimeChange}
                selectedValue={selectedExposureTime}
              />
            </View>
            <InputSlider
              label="Light Range"
              isTwoPoints={false}
              sliderStyle={styles.sliderStyle}
              min={0}
              max={100}
              onValueChanged={this.onSliderChange}
            />
          </View>

          <View style={styles.buttonContainer}>
            <TouchButton
              doPress={this.doCreate}
              buttonTypeStyle={styles.createButton}
              buttonTextStyle={styles.cancelButtonText}
              buttonText="Create"
            />
            <TouchButton
              doPress={this.doCancel}
              buttonTypeStyle={styles.cancelButton}
              buttonTextStyle={styles.cancelButtonText}
              buttonText="Cancel"
            />
          </View>
        </ScrollView>
      </BackgroundScreen>
    );
  }
}

export default GardenDetailInfo;
