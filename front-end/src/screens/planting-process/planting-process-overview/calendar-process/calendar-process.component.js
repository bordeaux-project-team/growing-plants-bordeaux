import React, {Component} from 'react';
import {Text, View, TouchableOpacity, Image} from 'react-native';
import moment from 'moment';
import PropTypes from 'prop-types';
import styles from './calendar-process.style';
import COLORS from '../../../styles/color.style';

const days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

class CalendarProcess extends Component {
  constructor(props) {
    super(props);
    this.state = {
      weekObject: [],
      selectedDate: {
        day: null,
        date: null,
      },
      currentDate: 0,
    };
    this.dateCreator = this.dateCreator.bind(this);
    this.handlePress = this.handlePress.bind(this);
    this.handleMonthYearComponent = this.handleMonthYearComponent.bind(this);
    this.handleDateComponentDisplay = this.handleDateComponentDisplay.bind(
      this,
    );
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
    weekObject[0] = [];
    let todaysDateIndex = daysArray.indexOf(moment().format('ddd'));
    for (let day in daysArray) {
      let selectedWeekDaySet = day - todaysDateIndex;
      let calenderDay = daysArray[day];
      // day: Sun, Mon, Tue,...
      // date: 1, 2, 3,...
      let dateObject = {
        day: calenderDay,
        date: moment()
          .add(selectedWeekDaySet, 'day')
          .format(this.props.dateFormat),
        month: moment()
          .add(selectedWeekDaySet, 'day')
          .format('M'),
        monthYear: moment()
          .add(selectedWeekDaySet, 'day')
          .format('MMMM YYYY'),
        isCurrentDate: false,
      };
      const currentDate = moment()
        .toDate()
        .getDate();
      const currentMonth =
        moment()
          .toDate()
          .getMonth() + 1;
      if (
        Number(dateObject.date) === currentDate &&
        Number(dateObject.month) === currentMonth
      ) {
        dateObject.isCurrentDate = true;
      }
      weekObject[0][day] = dateObject;
    }
    this.setState({weekObject});
  };

  handlePress = dateData => {
    if (
      this.state.selectedDate.day == dateData.day &&
      this.state.selectedDate.date == dateData.date
    ) {
      this.setState({selectedDate: {day: null, date: null}});
    } else {
      this.setState({
        selectedDate: {
          day: dateData.day,
          date: dateData.date,
        },
      });
    }
    this.props.onPressDate(dateData);
  };

  handleMonthYearComponent = () => {
    if (this.state.weekObject.length > 0) {
      return (
        <Text style={styles.dateComponentYearText}>
          {this.state.weekObject[0][3].monthYear}
        </Text>
      );
    }
  };

  handleDateComponentDisplay = () => {
    let currentDate = 0;
    return this.state.weekObject[0].map((date, index) => {
      let isPressed =
        this.state.selectedDate.day == date.day &&
        this.state.selectedDate.date == date.date;
      const setDateColor = date => {
        if (date.isCurrentDate) {
          currentDate = date.date;
          this.setState({currentDate});
          if (isPressed) {
            return this.props.pressedColor;
          } else {
            return 'green';
          }
        } else {
          if (isPressed) {
            return this.props.pressedColor;
          } else {
            if (date.date < currentDate) {
              return 'gray';
            } else {
              return this.props.depressedColor;
            }
          }
        }
      };
      return (
        <TouchableOpacity
          key={index}
          onPress={() => this.handlePress(date)}
          style={styles.dateComponentDateTouchable}>
          <Text
            style={{
              color: setDateColor(date),
            }}>
            {date.day}
          </Text>
          <Text
            style={{
              color: setDateColor(date),
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
          {this.state.weekObject.length != 0 &&
            this.handleDateComponentDisplay()}
        </View>
      </View>
    );
  }
}

CalendarProcess.defaultProps = {
  iconSize: 30,
  dateFormat: 'D',
  pressedColor: 'blue',
  depressedColor: COLORS.commonText,
};

CalendarProcess.propTypes = {
  iconSize: PropTypes.number,
  dateFormat: PropTypes.string,
  pressedColor: PropTypes.string,
  depressedColor: PropTypes.string,
};

export default CalendarProcess;
