import React from 'react';

const userOutPut = (props)=>{
    return(
        <div>
            <h1>Expense Manager App</h1>
            <p>Username : {props.username}</p>
            <p>App tha show every expense you do...</p>
        </div>
    )
}

export default userOutPut;
