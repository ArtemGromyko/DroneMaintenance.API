import React, { useEffect, useState } from 'react';

const MainContext = React.createContext();

function MainContextProvider({ children }) {
    const [jwt, setJwt] = useState();
    const [user, setUser] = useState();
    useEffect(() => {
        console.log(jwt)
        if(jwt) {
            const res = JSON.parse(atob(jwt.split('.')[1]));
            setUser({id: res.Id, name: res.name, role: res.role});
        } else {
            setUser(undefined);
        }
    },[jwt]);

    return (
        <MainContext.Provider value={{ jwt, setJwt, user }}>
            {children}
        </MainContext.Provider>
    );
}

export { MainContextProvider, MainContext };