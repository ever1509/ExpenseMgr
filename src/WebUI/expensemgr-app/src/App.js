import React, { Component } from 'react';
import './App.css';
import UserInput from './Components/UserInput';
import UserOutPut from './Components/UserOutPut';

class App extends Component {
  state ={
    users:[
      {username:'ever1509'},
      {username:'orelle01'}    
    ]  
  } 
  
  usernameChangedHandler =(event)=>{
    this.setState(
      {
        users: [
          {username:'ever1509'},
          {username:event.target.value}          
        ]
       
      })
  }
  
  render() {


    return (
      <div className="App">   
            <h1>Expense Manager App</h1>        
       <UserInput  changed={this.usernameChangedHandler} />
         <UserOutPut users={this.state.users}/>            
      </div>
    );
  }
}

export default App;
