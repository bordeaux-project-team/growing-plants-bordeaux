import React, {Component} from 'react';
import {SafeAreaView, ScrollView, Text, View} from 'react-native';
import styles from './planting-process-overview.style';
import BackgroundScreen from '../../common-screens/background-screen.component';
import {useNavigation, StackActions} from '@react-navigation/native';
import TreeWallpaper from './tree-wallpaper/tree-wallpaper.component';
import CalendarProcess from './calendar-process/calendar-process.component';
import TouchButton from '../../common-elements/button.component';
import {ListItem} from 'react-native-elements';
import {getPlantingSpotById} from '../../../services/planting-process-service';

class PlantingProcessOverview extends Component {
  constructor(props) {
    super(props);
    this.state = {
      plantingSpotConcernData: {},
      selectedDate: null,
      isOutOfDate: false,
      selectedProcessStep: null,
    };
  }

  async componentDidMount() {
    await this._getPlantingSpotConcernData();
  }

  _getPlantingSpotConcernData = async () => {
    const currentDate = new Date();
    const plantingSpotModel = this.props.route
      ? this.props.route.params.plantingSpotModel
      : {};
    const getPlantingSpotByIdResponse =
      plantingSpotModel.id && (await getPlantingSpotById(plantingSpotModel.id));
    const plantingSpotConcernData =
      getPlantingSpotByIdResponse && getPlantingSpotByIdResponse.result;
    const processSteps =
      plantingSpotConcernData && plantingSpotConcernData.processSteps;
    let selectedProcessStep = null;
    processSteps.forEach(processStep => {
      const processStepStartDate = new Date(processStep.startDate);
      if (
        processStepStartDate.getDate() === Number(currentDate.getDate()) &&
        processStepStartDate.getMonth() + 1 ===
          Number(currentDate.getMonth() + 1)
      ) {
        selectedProcessStep = processStep;
      }
    });
    this.setState({plantingSpotConcernData});
    this.setState({selectedProcessStep});
  };

  _addAction = () => {
    const {navigation} = this.props;
    const plantingSpotModel = this.props.route
      ? this.props.route.params.plantingSpotModel
      : {};
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const plantingEnvironment = this.props.route
      ? this.props.route.params.plantingEnvironment
      : {};
    const {selectedProcessStep} = this.state;
    navigation.dispatch(
      StackActions.replace('NewAction', {
        plantingSpotModel,
        treeInfo,
        processStep: selectedProcessStep,
        plantingEnvironment,
      }),
    );
  };

  onPressDate = dateData => {
    this.setState({selectedDate: dateData});
    const currentDate = new Date();
    const todayDate = currentDate.getDate();
    if (dateData.date < todayDate) {
      this.setState({isOutOfDate: true});
    } else {
      this.setState({isOutOfDate: false});
      const selectedProcessStep = this._getProcessStepByDate(dateData);
      this.setState({selectedProcessStep});
    }
  };

  _getProcessStepByDate = dateData => {
    let selectedProcessStep = null;
    const {plantingSpotConcernData} = this.state;
    const processSteps =
      plantingSpotConcernData && plantingSpotConcernData.processSteps;
    processSteps.forEach(processStep => {
      const processStepStartDate = new Date(processStep.startDate);
      if (
        processStepStartDate.getDate() === Number(dateData.date) &&
        processStepStartDate.getMonth() + 1 === Number(dateData.month)
      ) {
        selectedProcessStep = processStep;
      }
    });
    return selectedProcessStep;
  };

  _navigateToGarden = () => {
    const {navigation} = this.props;
    const plantingSpotModel = this.props.route
      ? this.props.route.params.plantingSpotModel
      : {};
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const plantingSpots = this.props.route
      ? this.props.route.params.plantingSpots
      : {};
    const plantingEnvironment = this.props.route
      ? this.props.route.params.plantingEnvironment
      : {};
    navigation.dispatch(
      StackActions.replace('PlantingProcess', {
        plantingSpots,
        plantingSpotModel,
        treeInfo,
        plantingEnvironment,
      }),
    );
  };

  render() {
    const {selectedProcessStep, selectedDate, isOutOfDate} = this.state;
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const actions = selectedProcessStep
      ? selectedProcessStep.plantingActions
      : [];
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.componentContainer}>
          <ScrollView>
            <TreeWallpaper treeInfo={treeInfo} />

            <View style={styles.boxContainer}>
              <CalendarProcess onPressDate={this.onPressDate} />
              <View style={styles.addActionContainer}>
                {isOutOfDate ? (
                  <Text style={styles.canNotAddActionMessage}>
                    Can not add action for the past
                  </Text>
                ) : (
                  <TouchButton
                    doPress={this._addAction}
                    buttonTypeStyle={styles.addActionButton}
                    buttonTextStyle={styles.addActionButtonText}
                    buttonText="Add New Action"
                  />
                )}
              </View>
            </View>

            <View style={styles.boxContainer}>
              <Text>
                Actions for{' '}
                {selectedDate
                  ? selectedDate.isCurrentDate
                    ? 'Today'
                    : `${selectedDate.date}/${selectedDate.month}`
                  : 'Today'}
              </Text>
              {isOutOfDate ? (
                <Text style={styles.canNotAddActionMessage}>
                  The day is over
                </Text>
              ) : actions && actions.length > 0 ? (
                actions.map(action => (
                  <ListItem
                    roundAvatar={true}
                    containerStyle={styles.listItem}
                    leftAvatar={{
                      source: require('../../../assets/images/task-icon.jpg'),
                      size: 'medium',
                    }}
                    title={action.name}
                    titleStyle={styles.actionName}
                    subtitle={
                      <View>
                        <Text style={styles.actionDetail}>
                          {action.description}
                        </Text>
                        <Text style={styles.actionDetail}>
                          Amount {action.amount} {action.measurementUnit}
                        </Text>
                        <Text style={styles.actionDetail}>
                          {action.status === 0 ? 'Not Done' : 'Done'}
                        </Text>
                      </View>
                    }
                  />
                ))
              ) : (
                <Text style={styles.canNotAddActionMessage}>
                  There is no action
                </Text>
              )}
            </View>

            <View style={styles.gardenButtonContainer}>
              <TouchButton
                doPress={this._navigateToGarden}
                buttonTypeStyle={styles.gardenButton}
                buttonTextStyle={styles.gardenButtonText}
                buttonText="Back to Garden"
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
  return <PlantingProcessOverview {...props} navigation={navigation} />;
};
