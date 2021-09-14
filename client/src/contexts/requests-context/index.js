import React, { useState } from 'react';

const RequestsContext = React.createContext();

function RequestsContextProvider({ children }) {
    const [request, setRequest] = useState();

    return (
        <RequestsContext.Provider value={{request, setRequest}}>
            {children}
        </RequestsContext.Provider>
    );
}

export {RequestsContext, RequestsContextProvider};