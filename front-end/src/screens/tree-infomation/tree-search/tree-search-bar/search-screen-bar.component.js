import React, {Component} from 'react';
import InputSearchBar from '../../../common-elements/input-search-bar.component';

class TreeSearchBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      searchText: '',
    };
  }

  updateSearch = searchText => {
    this.setState({searchText});
    const {searchByText} = this.props;
    searchByText(searchText);
  };

  render() {
    const {searchText} = this.state;

    return (
      <InputSearchBar
        searchText="Tree Search..."
        textChange={this.updateSearch}
        searchValue={searchText}
      />
    );
  }
}

export default TreeSearchBar;
