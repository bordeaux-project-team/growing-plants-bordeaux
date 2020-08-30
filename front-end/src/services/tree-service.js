import {fetchPost} from './base-service';

export const searchTreeModel = {
  text: "",
  plantType: "",
  temperature: "",
  waterLevel: null,
  pageNumber: 1,
};

const searchTree = async searchTree => {
  return await fetchPost(
    'api/tree/search',
    searchTree,
    true,
  );
};

export {searchTree};
