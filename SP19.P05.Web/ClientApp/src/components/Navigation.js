import React from 'react';
import { Route, Link, BrowserRouter as Router } from 'react-router-dom';
import Home from './Home';
import Menu from './Menu';

const NavItem = props => {
    const pageURI = window.location.pathname + window.location.search
    const liClassName = (props.path === pageURI) ? "nav-item active" : "nav-item";
    const aClassName = props.disabled ? "nav-link disabled" : "nav-link"
    return (
        <li className={liClassName}>
            <a href={props.path} className={aClassName}>
                {props.name}
                {(props.path === pageURI) ? (<span className="sr-only">(current)</span>) : ''}
            </a>
        </li>
    );
}

class Navigation extends React.Component {
    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <a className="navbar-brand" href="/">Navbar</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li>
                            <Link className="nav-link" to="/2">Page1</Link>
                        </li>
                        <li>
                            <Link className="nav-link" to="/2">Page2</Link>
                        </li>
                        <li>
                            <Link className="nav-link" to="/2">Page3</Link>
                        </li>
                    </ul>
                    <form action="login.html">
                        <button type="submit">Login</button>
                    </form>
                </div>
            </nav>
        )
    }
}

export default Navigation;