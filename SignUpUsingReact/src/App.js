import "./App.css";
import React, { useState, useEffect } from "react";
import Signed from "./Signed";
function App() {
  const initialValues = {
    username: "",
    email: "",
    password: "",
    confirmPassword: "",
  };

  const [formValues, setFormValues] = React.useState(initialValues);
  const [formErrors, setFormErrors] = useState({});
  const [isSubmit, setIsSubmit] = useState(false);
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormValues({ ...formValues, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setFormErrors(validate(formValues));
    setIsSubmit(true);
  };

  const validate = (values) => {
    const errors = {};
    const ereg = /[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,}/g;
    if (values.username.length === 0) {
      errors.username = "Username cannot be blank";
      return errors;
    }
    if (values.username.length < 3 || values.username.length > 25) {
      errors.username = "Username must be between 3 and 25 characters ";
      return errors;
    }
    if (!isNaN(values.username)) {
      errors.username = "Username can't be a number";
      return errors;
    }

    if (values.email.length === 0) {
      errors.email = "Email Id cannot be blank";
      return errors;
    }

    let val = values.email.length - values.email.indexOf(".") - 1;
    if (values.email.indexOf("@") === 0 || val < 2 || val > 3) {
      errors.email = "Invalid Email Id";
      return errors;
    }

    if (values.password.length === 0) {
      errors.password = "Password cannot be blank";
      return errors;
    }

    if (values.password.length < 8 || missing(values.password)) {
      errors.password =
        " Password must contain 8 characters that include at least 1 lowercase character,1 uppercase character,1 number and 1 special character(!@#$%^&*)";
      return errors;
    }

    if (values.confirmPassword.length === 0) {
      errors.confirmPassword = "Confirm password cannot be blank";
      return errors;
    }
    if (values.confirmPassword != values.password) {
      errors.confirmPassword = "Confirm Password must be same as Password";
      return errors;
    }
    return errors;
  };

  function missing(pass) {
    let lowercase = /[a-z]/g;
    let uppercase = /[A-Z]/g;
    let numbers = /[0-9]/g;
    let specialChar = /[!@#$%^&*]/g;

    if (!lowercase.test(pass)) return true;
    if (!uppercase.test(pass)) return true;
    if (!numbers.test(pass)) return true;
    if (!specialChar.test(pass)) return true;

    return false;
  }

  // useEffect(() => {
  //   if (Object.keys(formErrors).length === 0 && isSubmit) {
  //     console.log("jkdjjkddlskls");
  //     <Signed />;
  //   }
  // }, [formErrors]);

  return (
    <div className="container">
      {Object.keys(formErrors).length === 0 && isSubmit ? (
        <Signed />
      ) : (
        <div></div>
      )}
      ;
      <form onSubmit={handleSubmit}>
        <h1 className="heading">Sign Up</h1>
        <div className="ui_divider"></div>
        <div className="ui_form">
          <div className="field">
            <label>UserName</label>
            <br />
            <input
              type="text"
              name="username"
              placeholder="username"
              value={formValues.username}
              onChange={handleChange}
            />
            <br />
            <p>{formErrors.username}</p>
          </div>
          <div className="field">
            <label>Email Id</label>
            <br />
            <input
              type="text"
              name="email"
              placeholder="Email"
              value={formValues.email}
              onChange={handleChange}
            />
            <br />
            <p>{formErrors.email}</p>
          </div>
          <div className="field">
            <label>Password</label>
            <br />
            <input
              type="Password"
              name="password"
              placeholder="Password"
              value={formValues.password}
              onChange={handleChange}
            />
            <br />
            <p>{formErrors.password}</p>
          </div>
          <div className="field">
            <label>Confirm Password</label>
            <br />
            <input
              type="Password"
              name="confirmPassword"
              placeholder="Confirm Password"
              value={formValues.confirmPassword}
              onChange={handleChange}
            />
            <br />
            <p>{formErrors.confirmPassword}</p>
          </div>
          <button className="fluid ui button">Register</button>
        </div>
      </form>
    </div>
  );
}

export default App;
