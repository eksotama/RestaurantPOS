import React from 'react';
import { Switch, Route, Link } from 'react-router-dom'; // import the react-router-dom components
import { Home, Menu, MyOrder, Reservations, Login } from './Navigator' // import our pages

const Main = () => (
    <main>
        <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/menu' component={Menu} />
            <Route exact path='/myorder' component={MyOrder} />
            <Route exact path='/reservations' component={Reservations} />
            <Route exact path='/login' component={Login} />
        </Switch>
    </main>
)

const Header = () => (
    <div>
        <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
            <a className="navbar-brand" href="/">React App</a>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav mr-auto">
                    <li>
                        <Link className="nav-link" to="/menu">Menu</Link>
                    </li>
                    <li>
                        <Link className="nav-link" to="/myorder">My Order</Link>
                    </li>
                    <li>
                        <Link className="nav-link" to="/reservations">Reservations</Link>
                    </li>
                </ul>

                <Link className="nav-link" to="/login">Login</Link>

            </div>
        </nav>
    </div>
)

const App = () => (
    <div>
        <Header />
        <Main />
    </div>
)

export default App;