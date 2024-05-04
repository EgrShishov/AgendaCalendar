import {BrowserRouter as Router, Navigate, Route, Routes, useNavigate} from 'react-router-dom';
import Home from "./pages/home.tsx";
import MainCalendar from "./pages/mainCalendar.tsx";
import Auth from "./pages/auth.tsx";
import Account from "./pages/account.tsx";
import Settings from "./pages/settings.tsx";
import NotFound from "./pages/notFound.tsx";
import EditEvent from "./pages/editEvent.tsx";
import EditCalendar from "./pages/editCalendar.tsx";
import PrivateRoute from "./components/privateRoute.tsx";
import {useContext} from "react";
import GlobalContext from "./context/globalContext.ts";

function App() {
    const {isAuthenticated, setIsAuthenticated} = useContext(GlobalContext);

    return(
        <Router>
            <Routes>
                <Route path="/" Component={Home} />
                <Route path="/u" element={<PrivateRoute Component={MainCalendar} isAuthenticated={isAuthenticated}/>} />
                <Route path="/auth" Component={Auth} />
                <Route path="/u/account" Component={Account} />
                <Route path="/u/settings" Component={Settings} />
                <Route path="/event/:id/edit" Component={EditEvent} />
                <Route path="/calendar/:id/edit" Component={EditCalendar} />
                <Route path="*" Component={NotFound} />
            </Routes>
        </Router>
    )
}

export default App
