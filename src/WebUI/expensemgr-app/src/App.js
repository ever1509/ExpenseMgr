import React, { Component } from 'react';
import './App.css';
import UserInput from './Components/UserInput';
import UserOutPut from './Components/UserOutPut';

class App extends Component {
  state ={
    user:[
      {username:'ever1509'}     
    ]
  } 
  
  updateUserNameHandler =(newUserName)=>{
    this.setState(
      {
        user:[
          {username:newUserName}
        ]
      }
    )
  }
  
  render() {
    return (
      <div>
       <UserOutPut 
       username={this.state.user.username} 
      //  changed={this.updateUserNameHandler('orelle01')}
       />       
      </div>
    );
  }
}

export default App;
