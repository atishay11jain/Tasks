import "./App.css";
import { useSelector, useDispatch } from "react-redux";
import { fetchPosts } from "./redux/action";
import React from "react";
import Box from "./box";

function App() {
  const { posts, loading } = useSelector((state) => ({ ...state.data }));
  const dispatch = useDispatch();

  return (
    <div className="App">
      {posts.length === 0 ? (
        <div>
          <h1> Users</h1>
          <button onClick={() => dispatch(fetchPosts())}>Get Users</button>
        </div>
      ) : (
        <h2></h2>
      )}
      {posts.map((post) => (
        <Box post={post} />
      ))}
    </div>
  );
}

export default App;
