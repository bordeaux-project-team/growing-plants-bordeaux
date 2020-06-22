import React, {Component} from 'react';
import {Text, View, TouchableOpacity, StyleSheet, Image} from 'react-native';
import moment from 'moment';
import PropTypes from 'prop-types';
import styles from './calendar.style';

const days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

export default class Calendar extends Component {
  constructor() {
    super();
    this.state = {
      arrowCount: 0,
      weekObject: [],
      selectedDate: {
        day: null,
        date: null,
      },
    };
  }
  componentDidMount() {
    this.dateCreator();
  }
  shouldComponentUpdate(nextProps, nextState) {
    return (
      this.state.weekObject != nextState.weekObject ||
      this.state.selectedDate != nextState.selectedDate
    );
  }

  dateCreator = () => {
    const daysArray = days;
    let weekObject = [...this.state.weekObject];
    weekObject[this.state.arrowCount] = [];
    let todaysDateIndex = daysArray.indexOf(moment().format('ddd'));
    for (let day in daysArray) {
      let selectedWeekDaySet =
        day - todaysDateIndex + this.state.arrowCount * 7;
      let calenderDay = daysArray[day];
      let dateObject = {
        day: calenderDay,
        date: moment()
          .add(selectedWeekDaySet, 'day')
          .format(this.props.dateFormat),
        monthYear: moment()
          .add(selectedWeekDaySet, 'day')
          .format('MMMM YYYY'),
      };
      weekObject[this.state.arrowCount][day] = dateObject;
    }
    this.setState({weekObject});
  };

  handlePress = date => {
    if (
      this.state.selectedDate.day == date.day &&
      this.state.selectedDate.date == date.date
    ) {
      this.setState({selectedDate: {day: null, date: null}});
    } else {
      let dates = {
        day: date.day,
        date: date.date,
      };
      this.setState(
        {
          selectedDate: {
            day: date.day,
            date: date.date,
          },
        },
        this.props.selected(dates),
      );
    }
  };

  handleArrowChange = time => {
    this.setState({arrowCount: this.state.arrowCount - time}, () => {
      this.dateCreator();
    });
  };

  handleMonthYearComponent = () => {
    if (this.state.weekObject.length > 0) {
      return (
        <Text style={styles.dateComponentYearText}>
          {this.state.weekObject[this.state.arrowCount][3].monthYear}
        </Text>
      );
    }
  };

  handleDateComponentDisplay = () => {
    return this.state.weekObject[this.state.arrowCount].map((date, index) => {
      let isPressed =
        this.state.selectedDate.day == date.day &&
        this.state.selectedDate.date == date.date;
      return (
        <TouchableOpacity
          key={index}
          onPress={() => this.handlePress(date)}
          style={styles.dateComponentDateTouchable}>
          <Text
            style={{
              color: isPressed
                ? this.props.pressedColor
                : this.props.depressedColor,
            }}>
            {date.day}
          </Text>
          <Text
            style={{
              color: isPressed
                ? this.props.pressedColor
                : this.props.depressedColor,
            }}>
            {date.date}
          </Text>
        </TouchableOpacity>
      );
    });
  };

  render() {
    return (
      <View style={styles.dateComponentView}>
        {this.handleMonthYearComponent()}
        <View style={styles.dateComponentDateView}>
          <Text />
          <TouchableOpacity onPress={() => this.handleArrowChange(1)}>
            <Image
              style={{width: this.props.iconSize, height: this.props.iconSize}}
              source={require('../../../assets/images/left-arrow.png')}
            />
          </TouchableOpacity>
          {this.state.weekObject.length != 0 &&
            this.handleDateComponentDisplay()}
          <TouchableOpacity onPress={() => this.handleArrowChange(-1)}>
            <Image
              style={{width: this.props.iconSize, height: this.props.iconSize}}
              source={require('../../../assets/images/right-arrow.png')}
            />
          </TouchableOpacity>
        </View>
      </View>
    );
  }
}
Calendar.defaultProps = {
  iconSize: 30,
  dateFormat: 'D',
  pressedColor: '#fff',
  depressedColor: '#7d7c7b',
};

Calendar.propTypes = {
  iconSize: PropTypes.number,
  dateFormat: PropTypes.string,
  pressedColor: PropTypes.string,
  depressedColor: PropTypes.string,
  selected: PropTypes.func,
};
