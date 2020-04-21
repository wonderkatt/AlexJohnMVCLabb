import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { Logout } from './components/Logout';
import { TeamOverview } from './components/TeamOverview';
import { TeamPlayersOverview } from './components/TeamPlayersOverview';
import { BuyPlayerOverview } from './components/BuyPlayerOverview';
import { CreateTeamOverview } from './components/CreateTeamOverview';
import { Registration } from './components/Registration';
import PrivateRoute from './PrivateRoute'




import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/login' component={Login} />
        <Route exact path='/registration' component={Registration} />
        <Route exact path='/' exact component={Home} />
        <PrivateRoute exact path='/team/overview' component={TeamOverview} />
        <PrivateRoute exact path='/team/players' component={TeamPlayersOverview} />
        <PrivateRoute exact path='/team/players/positions' component={BuyPlayerOverview} />
        <PrivateRoute exact path='/team/create' component={CreateTeamOverview} />
        <PrivateRoute exact path='/logout' component={Logout} />


      </Layout>
    );
  }
}
