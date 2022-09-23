import * as types from "./actionType";

const intialState = {
  posts: [],
  loading: false,
  eror: null,
};

const postReducer = (state = intialState, action) => {
  switch (action.type) {
    case types.FETCH_POST_START:
      return {
        ...state,
        loading: true,
      };

    case types.FETCH_POST_SUCCESS:
      return {
        ...state,
        loading: false,
        posts: action.payload,
      };

    case types.FETCH_POST_FAIL:
      return {
        ...state,
        loading: false,
        error: action.payload,
      };

    default:
      return state;
  }
};

export default postReducer;
