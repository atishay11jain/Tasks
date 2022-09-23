import "./box.css";

const Box = ({ post }) => {
  const fullName = post.first_name + " " + post.last_name;
  return (
    <div className="window">
      <div className="cards">
        <h4>{post.id}</h4>
        <div className="image">
          <img src={post.avatar} alt={post.first_name} />
        </div>
        <div className="title">
          <h1>{fullName}</h1>
        </div>
        <div className="email">
          <h3>{post.email}</h3>
        </div>
      </div>
    </div>
  );
};

export default Box;
