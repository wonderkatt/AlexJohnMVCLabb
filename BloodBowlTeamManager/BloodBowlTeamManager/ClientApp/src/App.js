import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { TeamOverview } from './components/TeamOverview';
import { TeamPlayersOverview } from './components/TeamPlayersOverview';



import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/team/overview' component={TeamOverview} />
        <Route path='/team/players' component={TeamPlayersOverview} />
            
      </Layout>
    );
  }
}
