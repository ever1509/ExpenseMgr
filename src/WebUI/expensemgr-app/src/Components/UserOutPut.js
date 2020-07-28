import React from 'react';

const userOutPut = ( props )=>{
    return(
        <div className="UserOutPut">           
            <p onChange={props.changed}>Username : {props.users[0].username}</p> 
            <p>Username : {props.users[1].username}</p>            
        </div>
    )
}

export default userOutPut;
