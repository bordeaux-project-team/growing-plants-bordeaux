import React, {Component} from 'react';
import InputSearchBar from '../../../common-elements/input-search-bar.component';

class GardenSearchBar extends Component {
  state = {
    search: '',
  };

  updateSearch = search => {
    this.setState({search});
  };

  render() {
    const {search} = this.state;

    return (
      <InputSearchBar
        searchText="Garden Search..."
        textChange={this.updateSearch}
        searchValue={search}
      />
    );
  }
}

export default GardenSearchBar;
