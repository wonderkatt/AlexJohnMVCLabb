import React, { Component } from 'react';
import Cookies from 'js-cookie';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Logout } from './components/Logout';
import { TeamOverview } from './components/TeamOverview';
import { TeamPlayersOverview } from './components/TeamPlayersOverview';
import { BuyPlayerOverview } from './components/BuyPlayerOverview';
import { Registration } from './components/Registration';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' exact component={Home} />
        <Route exact path='/team/overview' component={TeamOverview} />
        <Route exact path='/team/players' component={TeamPlayersOverview} />
        <Route exact path='/team/players/positions' component={BuyPlayerOverview} />
        <Route exact path='/registration' component={Registration} />
        <Route exact path='/login' component={Login} />
        <Route exact path='/logout' component={Logout} />
      </Layout>
    );
  }
}
