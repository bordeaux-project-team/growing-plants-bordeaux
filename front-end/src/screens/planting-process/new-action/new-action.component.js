import React, {Component} from 'react';
import {SafeAreaView, ScrollView, Text, View} from 'react-native';
import styles from './new-action.style';
import TreeWallpaper from '../planting-process-overview/tree-wallpaper/tree-wallpaper.component';
import BackgroundScreen from '../../common-screens/background-screen.component';
import SelectBox from '../../common-elements/select-box.component';
import InputDate from '../../common-elements/input-date.component';
import InputText from '../../common-elements/input-text.component';
import {Icon} from 'react-native-elements';
import TouchButton from '../../common-elements/button.component';

class NewAction extends Component {
  constructor(props) {
    super(props);
    const currentDate = this._getCurrentDate();
    this.state = {
      selectedAction: null,
      startDate: currentDate,
      description: '',
      selectedAmountOptions: null,
    };
  }

  actionTypeData = [
    {value: null, label: 'Choose an action'},
    {value: 'Water', label: 'Water'},
    {value: 'Nutrients', label: 'Nutrients'},
    {value: 'Repellent', label: 'Repellent'},
    {value: 'Transplant', label: 'Transplant'},
    {value: 'Trim', label: 'Trim'},
    {value: 'Harvest', label: 'Harvest'},
    {value: 'Declare Death', label: 'Declare Death'},
  ];

  amountOptionsData = {
    Water: [{value: 'mL', label: 'mL'}, {value: 'L', label: 'L'}],
    Nutrients: [{value: 'gr', label: 'gr'}, {value: 'kg', label: 'kg'}],
    Repellent: [{value: 'mL', label: 'mL'}, {value: 'L', label: 'L'}],
    Transplant: [{value: 'times', label: 'times'}],
    Trim: [{value: 'times', label: 'times'}],
    Harvest: [{value: 'times', label: 'times'}],
    DeclareDeath: [{value: 'times', label: 'times'}],
  };

  amountOptionsNumber = {
    Water: 50,
    Nutrients: 20,
    Repellent: 10,
    Transplant: 15,
    Trim: 2,
    Harvest: 1,
    DeclareDeath: 2,
  };

  onValueChangeAction = selectedAction => {
    console.log('action', selectedAction);
    this.setState({selectedAction});
  };

  onDateChange = date => {
    console.log('date', date);
    this.setState({startDate: date});
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

  setDescription = description => {
    console.log('description', description);
    this.setState({description});
  };

  onValueChangeAmountOptions = selectedAmountOptions => {
    console.log('selectedAmountOptions', selectedAmountOptions);
    this.setState({selectedAmountOptions});
  };

  _doAddAction = () => {
    // add action
  };

  _doCancel = () => {
    const {navigation} = this.props;
    navigation.goBack();
  };

  render() {
    const {
      selectedAction,
      startDate,
      description,
      selectedAmountOptions,
    } = this.state;
    const treeInfo = this.props.route ? this.props.route.params.treeInfo : {};
    const removedSpaceAmountNumber =
      selectedAction && selectedAction.replace(/ /g, '');
    const amountNumber = removedSpaceAmountNumber
      ? this.amountOptionsNumber[removedSpaceAmountNumber]
      : '';
    const amountUnit = removedSpaceAmountNumber
      ? this.amountOptionsData[removedSpaceAmountNumber]
      : [];
    return (
      <BackgroundScreen>
        <SafeAreaView style={styles.componentContainer}>
          <ScrollView>
            <TreeWallpaper treeInfo={treeInfo} />

            <SelectBox
              containerStyle={styles.selectBoxContainer}
              selectBoxStyle={styles.selectBoxStyle}
              items={this.actionTypeData}
              onValueChange={this.onValueChangeAction}
              selectedValue={selectedAction}
            />

            <View style={styles.inputDateContainer}>
              <InputDate
                placeholder={'Start Date: ' + startDate}
                style={styles.changeStartDateButtonText}
                onDateChange={this.onDateChange}
              />
            </View>

            <InputText
              onChangeText={description => this.setDescription(description)}
              inputStyle={styles.descriptionInput}
              placeholder="Description"
              textInputStyle={styles.descriptionInputText}
              value={description}
            />

            <View style={styles.boxContainer}>
              <Text style={styles.boxTitle}>{selectedAction} Options</Text>
              <View style={styles.amountOptions}>
                <View style={styles.amountNumber}>
                  <Text style={styles.amountNumberText}>
                    Amount {amountNumber}
                  </Text>
                  <SelectBox
                    containerStyle={styles.selectAmountOptionsBoxContainer}
                    selectBoxStyle={styles.selectAmountOptionsBoxStyle}
                    items={amountUnit}
                    onValueChange={this.onValueChangeAmountOptions}
                    selectedValue={selectedAmountOptions}
                  />
                </View>
              </View>
            </View>

            <View style={styles.boxContainer}>
              <Text style={styles.boxTitle}>Recurrence</Text>
              <View style={styles.notificationContainer}>
                <View style={styles.attributeContainer}>
                  <Icon
                    color="#c68020"
                    type="fontisto"
                    name="spinner-rotate-forward"
                  />
                  <Text> Repeat every 3 days</Text>
                </View>
                <View style={styles.attributeContainer}>
                  <Icon color="#c68020" type="fontisto" name="bell" />
                  <Text> Add Notification</Text>
                </View>
              </View>
            </View>

            <View style={styles.buttonContainer}>
              <TouchButton
                doPress={this._doAddAction}
                buttonTypeStyle={styles.leftButton}
                buttonTextStyle={styles.leftButtonText}
                buttonText="Add"
              />
              <TouchButton
                doPress={this._doCancel}
                buttonTypeStyle={styles.rightButton}
                buttonTextStyle={styles.rightButtonText}
                buttonText="Cancel"
              />
            </View>
          </ScrollView>
        </SafeAreaView>
      </BackgroundScreen>
    );
  }
}

export default NewAction;
