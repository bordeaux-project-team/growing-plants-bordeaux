import React, {Component} from 'react';
import BackgroundScreen from '../../common-screens/background-screen.component';
import InputText from '../../common-elements/input-text.component';
import styles from './garden-detail-info-edit.style';
import {Alert, ScrollView, Switch, Text, View} from 'react-native';
import SelectBox from '../../common-elements/select-box.component';
import TouchButton from '../../common-elements/button.component';
import InputSlider from '../../common-elements/input-slider.component';
import {
  DialogComponent,
  SlideAnimation,
  DialogTitle,
} from 'react-native-dialog-component';
import AddNewLightDialog from './dialog-edit/add-new-light-dialog-edit.component';
import {updatePlantingEnvironment} from '../../../services/planting-environments-service';
import {StackActions, useNavigation} from '@react-navigation/native';

class GardenDetailInfoEdit extends Component {
  constructor(props) {
    super(props);
    const gardenInfo = props.route ? props.route.params.gardenInfo : {};
    const light = gardenInfo ? gardenInfo.light : null;
    this.state = {
      id: gardenInfo ? gardenInfo.id : null,
      name: gardenInfo ? gardenInfo.name : '',
      search: '',
      selectedCountryItems: gardenInfo ? gardenInfo.country : null,
      selectedTemperatureItems: gardenInfo ? gardenInfo.temperature : null,
      selectedHumidityItems: gardenInfo ? gardenInfo.humidity : null,
      isOutdoorType: gardenInfo
        ? gardenInfo.environmentType === 'outdoor'
          ? true
          : false
        : false,
      selectedExposureTime: gardenInfo ? gardenInfo.exposureTime : null,
      selectedWidthDataItems: gardenInfo ? gardenInfo.width : null,
      selectedLengthDataItems: gardenInfo ? gardenInfo.length : null,
      lightRange: light ? light.lightRange : 0,
      wattage: light ? light.wattage : 0,
      colorTemperature: light ? light.colorTemperature : 0,
      selectedLightTypeItems: light ? light.lightType : null,
      plantingSpots: gardenInfo ? gardenInfo.plantingSpots : [],
      light: light,
      lightText: 'Edit light',
    };
    this.doEdit = this.doEdit.bind(this);
    this.doCancel = this.doCancel.bind(this);
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
    {value: '10', label: '10C'},
    {value: '20', label: '20C'},
    {value: '30', label: '30C'},
    {value: '40', label: '40C'},
    {value: '40', label: '40C'},
    {value: '50', label: '50C'},
    {value: '60', label: '60C'},
    {value: '70', label: '70C'},
    {value: '80', label: '80C'},
    {value: '90', label: '90C'},
  ];

  humidityItems = [
    {value: null, label: 'Select Humidity'},
    {value: '10', label: '10%'},
    {value: '20', label: '20%'},
    {value: '30', label: '30%'},
    {value: '40', label: '40%'},
    {value: '50', label: '50%'},
    {value: '60', label: '60%'},
    {value: '70', label: '70%'},
    {value: '80', label: '80%'},
    {value: '90', label: '90%'},
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
  };

  doEdit = async () => {
    const {navigation} = this.props;
    const plantingEnvironmentId = this.state.id;
    const plantingEnvironmentModel = {
      name: this.state.name,
      width: this.state.selectedWidthDataItems,
      length: this.state.selectedLengthDataItems,
      country: this.state.selectedCountryItems,
      light: JSON.stringify(this.state.light),
      temperature: this.state.selectedTemperatureItems,
      humidity: this.state.selectedHumidityItems,
      exposureTime: this.state.selectedExposureTime,
      environmentType: this.state.isOutdoorType ? 'outdoor' : 'indoor',
      plantingSpots: this.state.plantingSpots,
    };
    const updateResult = await updatePlantingEnvironment(
      plantingEnvironmentId,
      plantingEnvironmentModel,
    );
    if (updateResult.status === 200) {
      navigation.dispatch(StackActions.replace('PlantingEnvironment'));
    } else {
      Alert.alert('There was an error!', 'Please try again', [
        {
          text: 'OK',
          onPress: () => console.log('Cancel Pressed'),
          style: 'cancel',
        },
      ]);
    }
  };

  doCancel = () => {
    const {navigation} = this.props;
    navigation.dispatch(StackActions.replace('PlantingEnvironment'));
  };

  lightTypeItems = [
    {value: null, label: 'Type'},
    {value: 'LED', label: 'LED'},
    {value: 'LEC', label: 'LEC'},
    {value: 'HPS', label: 'HPS'},
    {value: 'CFL', label: 'CFL'},
    {value: 'T5', label: 'T5'},
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
      lightRange: this.state.lightRange,
    };
    this.setState({
      light: JSON.stringify(light),
      lightText: 'Added',
    });
  };

  render() {
    const {
      name,
      selectedCountryItems,
      selectedTemperatureItems,
      selectedHumidityItems,
      isOutdoorType,
      selectedExposureTime,
      selectedWidthDataItems,
      selectedLengthDataItems,
      selectedLightTypeItems,
      lightText,
      wattage,
      colorTemperature,
      lightRange,
    } = this.state;

    return (
      <BackgroundScreen>
        <DialogComponent
          title={<DialogTitle title="Edit Light" />}
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
            wattage={wattage}
            colorTemperature={colorTemperature}
          />
        </DialogComponent>
        <ScrollView style={styles.gardenDetailInfoBackground}>
          <View>
            <InputText
              onChangeText={name => this.setNameState(name)}
              inputStyle={styles.gardenNameInput}
              placeholder="Garden Name"
              textInputStyle={styles.gardenNameTextInput}
              value={name}
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
              initialLowValue={lightRange}
            />
          </View>

          <View style={styles.buttonContainer}>
            <TouchButton
              doPress={this.doEdit}
              buttonTypeStyle={styles.createButton}
              buttonTextStyle={styles.cancelButtonText}
              buttonText="Edit"
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

export default props => {
  const navigation = useNavigation();
  return <GardenDetailInfoEdit {...props} navigation={navigation} />;
};
