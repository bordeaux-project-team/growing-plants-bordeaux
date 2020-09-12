import React, {Component} from 'react';
import {Alert, SafeAreaView, ScrollView, View} from 'react-native';
import styles from './plant-new-tree.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import NewTreePicture from './new-tree-picture/new-tree-picture.component';
import InputText from '../../common-elements/input-text.component';
import Timeline from 'react-native-timeline-flatlist';
import InputDate from '../../common-elements/input-date.component';
import TouchButton from '../../common-elements/button.component';
import {useNavigation} from '@react-navigation/native';
import {insertPlantingProcess} from '../../../services/planting-process-service';

class PlantNewTree extends Component {
  constructor(props) {
    super(props);
    const currentDate = this._getCurrentDate();
    this.state = {
      amountOfTree: 0,
      startDate: currentDate,
    };
  }

  setAmountOfTreeState = amountOfTree => {
    this.setState({amountOfTree});
  };

  _getPlantingProcessModel = startDate => {
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const convertedStartDate = new Date(startDate);
    const germinationDate = this._getAddedDate(
      convertedStartDate,
      treeInfo.germinationTime,
    );
    const vegetativeDate = this._getAddedDate(
      convertedStartDate,
      treeInfo.vegetativeTime,
    );
    const floweringDate = this._getAddedDate(
      convertedStartDate,
      treeInfo.floweringTime,
    );
    const harvestDate = this._getAddedDate(
      convertedStartDate,
      treeInfo.harvestTime,
    );
    const plantingProcessModel = {
      treeId: treeInfo.id,
      startDate: startDate,
      germinationDate: this._dateToString(germinationDate),
      vegetativeDate: this._dateToString(vegetativeDate),
      floweringDate: this._dateToString(floweringDate),
      harvestDate: this._dateToString(harvestDate),
    };
    return plantingProcessModel;
  };

  _getTimelineData = startDate => {
    const plantingProcessModel = this._getPlantingProcessModel(startDate);
    let timelineData = [];
    if (plantingProcessModel) {
      timelineData = [
        {time: plantingProcessModel.startDate, title: 'Start Date'},
        {time: plantingProcessModel.germinationDate, title: 'Germination'},
        {time: plantingProcessModel.vegetativeDate, title: 'Vegetative'},
        {time: plantingProcessModel.floweringDate, title: 'Flowering'},
        {time: plantingProcessModel.harvestDate, title: 'Harvest'},
      ];
    }
    return timelineData;
  };

  _getCurrentDate = () => {
    const today = new Date();
    return this._dateToString(today);
  };

  _dateToString = date => {
    const dd = date.getDate() < 10 ? `0${date.getDate()}` : date.getDate();
    // January is month 0 in javascript => +1
    const mm =
      date.getMonth() + 1 < 10
        ? `0${date.getMonth() + 1}`
        : date.getMonth() + 1;
    const yyyy = date.getFullYear();
    return `${yyyy}-${mm}-${dd}`;
  };

  _getAddedDate = (date, addDays) => {
    let tzOff = date.getTimezoneOffset() * 60 * 1000,
      t = date.getTime(),
      d = new Date(),
      tzOff2;

    t += 1000 * 60 * 60 * 24 * addDays;
    d.setTime(t);

    tzOff2 = d.getTimezoneOffset() * 60 * 1000;
    if (tzOff != tzOff2) {
      let diff = tzOff2 - tzOff;
      t += diff;
      d.setTime(t);
    }

    return d;
  };

  _onDateChange = date => {
    this.setState({startDate: date});
  };

  _doPlant = async () => {
    const {navigation} = this.props;
    const {amountOfTree, startDate} = this.state;
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const plantingProcessModel = this._getPlantingProcessModel(startDate);
    const insertResult = await insertPlantingProcess(plantingProcessModel);
    if (insertResult.status === 200) {
      navigation.navigate('PlantingProcessOverview', {
        amountOfTree,
        treeInfo,
      });
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

  _doCancel = () => {
    const {navigation} = this.props;
    navigation.goBack();
  };

  render() {
    const {amountOfTree, startDate} = this.state;
    const timelineData = this._getTimelineData(startDate);
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.componentContainer}>
          <ScrollView>
            <NewTreePicture treeInfo={treeInfo} />

            <InputText
              onChangeText={amountOfTree =>
                this.setAmountOfTreeState(amountOfTree)
              }
              inputStyle={styles.numberOfTreeInput}
              placeholder="Number of trees"
              textInputStyle={styles.numberOfTreeTextInput}
              value={amountOfTree}
            />

            <View style={styles.boxContainer}>
              <Timeline
                data={timelineData}
                circleSize={20}
                circleColor="rgb(45,156,219)"
                lineColor="rgb(45,156,219)"
                timeStyle={styles.timeline}
                options={{
                  style: styles.optionTimeline,
                }}
              />
              <View style={styles.changeStartDateButton}>
                <InputDate
                  placeholder={'CHANGE START DATE'}
                  style={styles.changeStartDateButtonText}
                  onDateChange={this._onDateChange}
                />
              </View>
            </View>

            <View style={styles.buttonContainer}>
              <TouchButton
                doPress={this._doPlant}
                buttonTypeStyle={styles.leftButton}
                buttonTextStyle={styles.leftButtonText}
                buttonText="Plant this tree"
              />
              <TouchButton
                doPress={this._doCancel}
                buttonTypeStyle={styles.rightButton}
                buttonTextStyle={styles.rightButtonText}
                buttonText="Back"
              />
            </View>
          </ScrollView>
        </SafeAreaView>
      </BackgroundScreen>
    );
  }
}

export default props => {
  const navigation = useNavigation();
  return <PlantNewTree {...props} navigation={navigation} />;
};
