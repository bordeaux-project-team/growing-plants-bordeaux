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
import {insertPlantingEnvironment} from '../../../services/planting-environments-service';

class GardenDetailInfo extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: '',
      search: '',
      selectedCountryItems: null,
      selectedTemperatureItems: null,
      selectedHumidityItems: null,
      isOutdoorType: false,
      selectedExposureTime: null,
      selectedWidthDataItems: null,
      selectedLengthDataItems: null,
      lightRange: 0,
      wattage: 0,
      colorTemperature: 0,
      selectedLightTypeItems: null,
      light: null,
      lightText: 'Add a new light',
    };
  }

  widthDataItems = [
    {value: null, label: 'Select Width'},
    {value: 1, label: '1ft'},
    {value: 2, label: '2ft'},
    {value: 3, label: '3ft'},
    {value: 4, label: '4ft'},
    {value: 5, label: '5ft'},
    {value: 6, label: '6ft'},
  ];
  lengthDataItems = [
    {value: null, label: 'Select Length'},
    {value: 1, label: '1ft'},
    {value: 2, label: '2ft'},
    {value: 3, label: '3ft'},
    {value: 4, label: '4ft'},
    {value: 5, label: '5ft'},
    {value: 6, label: '6ft'},
  ];

  setNameState = name => {
    this.setState({name: name});
  };

  onValueChangeWidth = selectedWidthDataItems => {
    this.setState({selectedWidthDataItems});
  };
  onValueChangeLength = selectedLengthDataItems => {
    this.setState({selectedLengthDataItems});
  };

  countryItems = [
    {value: null, label: 'Select Country'},
    {value: 'america', label: 'America'},
    {value: 'argentina', label: 'Argentina'},
    {value: 'australia', label: 'Australia'},
    {value: 'england', label: 'England'},
    {value: 'france', label: 'France'},
    {value: 'vietnam', label: 'Vietnam'},
  ];

  temperatureItems = [
    {value: null, label: 'Select Temperature'},
    {value: 10, label: '10C'},
    {value: 20, label: '20C'},
    {value: 30, label: '30C'},
    {value: 40, label: '40C'},
  ];

  humidityItems = [
    {value: null, label: 'Select Humidity'},
    {value: 10, label: '10%'},
    {value: 20, label: '20%'},
    {value: 30, label: '30%'},
    {value: 40, label: '40%'},
    {value: 50, label: '50%'},
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
    {value: 0, label: '0h'},
    {value: 1, label: '1h'},
    {value: 2, label: '2h'},
    {value: 3, label: '3h'},
    {value: 4, label: '4h'},
    {value: 5, label: '5h'},
    {value: 6, label: '6h'},
    {value: 7, label: '7h'},
    {value: 8, label: '8h'},
    {value: 9, label: '9h'},
    {value: 10, label: '10h'},
    {value: 11, label: '11h'},
    {value: 12, label: '12h'},
    {value: 13, label: '13h'},
    {value: 14, label: '14h'},
    {value: 15, label: '15h'},
    {value: 16, label: '16h'},
    {value: 17, label: '17h'},
    {value: 18, label: '18h'},
    {value: 19, label: '19h'},
    {value: 20, label: '20h'},
    {value: 21, label: '21h'},
    {value: 22, label: '22h'},
    {value: 23, label: '23h'},
    {value: 24, label: '24h'},
  ];

  onSliderChange = low => {
    this.setState({lightRange: low});
    console.log(low);
  };

  doCreate = async () => {
    console.log('doCreate');
    const plantingEnvironment = {
      name: this.state.name,
      width: this.state.selectedWidthDataItems,
      length: this.state.selectedLengthDataItems,
      countryId: this.state.selectedCountryItems,
      lightId: this.state.light,
      temperatureId: this.state.selectedTemperatureItems,
      humidityId: this.state.selectedHumidityItems,
      exposureTime: this.state.selectedExposureTime,
      environmentType: this.state.isOutdoorType ? 'outdoor' : 'indoor',
    };
    console.log(plantingEnvironment);
    const insertResult = await insertPlantingEnvironment(plantingEnvironment);
    console.log(insertResult);
  };

  doCancel = () => {
    console.log('doCancel');
  };

  lightTypeItems = [
    {value: null, label: 'Type'},
    {value: 'led', label: 'LED'},
    {value: 'lec', label: 'LEC'},
    {value: 'hps', label: 'HPS'},
    {value: 'cfl', label: 'CFL'},
    {value: 't5', label: 'T5'},
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
    const light = {
      lightType: this.state.selectedLightTypeItems,
      wattage: this.state.wattage,
      colorTemperature: this.state.colorTemperature,
    };
    this.setState({
      light: JSON.stringify(light),
      lightText: 'Added',
    });
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
      lightText,
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
            lightText={lightText}
          />
        </DialogComponent>
        <ScrollView style={styles.gardenDetailInfoBackground}>
          <View>
            <InputText
              onChangeText={name => this.setNameState(name)}
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
              buttonText={lightText}
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
