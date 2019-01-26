import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import Pressure from './components/Pressure';
import Temperature from './components/Temperature';
import ActionCreator from './data/ActionCreator';

export default class App extends Component {
  static displayName = App.name;

  componentDidMount() {
    fetch("/api/temperature").then(response => { 
      if(response.headers.get('Content-Type').indexOf('text/plain') === -1) {
        return "failed...";
      }
      
      return response.text();
    }).then(data => ActionCreator.updateCurrentTemperature(data));
    
    fetch("/api/pressure").then(response => { 
      if(response.headers.get('Content-Type').indexOf('text/plain') === -1) {
        return "failed...";
      }
      
      return response.text();
    }).then(data => ActionCreator.updateCurrentPressure(data));
  }

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/temperature' component={Temperature} />
        <Route path='/pressure' component={Pressure} />
      </Layout>
    );
  }
}