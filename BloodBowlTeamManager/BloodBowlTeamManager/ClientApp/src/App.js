import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Logout } from './components/Logout';
import { Counter } from './components/Counter';
import { TeamOverview } from './components/TeamOverview';
import { TeamPlayersOverview } from './components/TeamPlayersOverview';
import { Registration } from './components/Registration';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/team/overview' component={TeamOverview} />
        <Route path='/team/players' component={TeamPlayersOverview} />
        <Route path='/registration' component={Registration} />
        <Route path='/login' component={Login} />
        <Route path='/logout' component={Logout} />
      </Layout>
    );
  }
}
