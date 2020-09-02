import React from 'react';
import RangeSlider from 'rn-range-slider';

const InputSlider = props => {
  return (
    <RangeSlider
      rangeEnabled={props.isTwoPoints}
      style={props.sliderStyle}
      min={props.min}
      max={props.max}
      textFormat={props.label + ': %d'}
      step={10}
      selectionColor="#3df"
      blankColor="#f618"
      onValueChanged={props.onValueChanged}
      initialLowValue={props.initialLowValue}
    />
  );
};

InputSlider.defaultProps = {
  initialLowValue: 0,
};

export default InputSlider;
