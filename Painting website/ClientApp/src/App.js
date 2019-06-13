import React, { Component } from 'react'
import { Route } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './components/Home'
import PageView from './components/PageView'
import PhotoView from './components/PhotoView'
import PhotoUpload from './components/PhotoUpload'
import Categories from './components/Category'
import UploadLogin from './components/UploadLogin'
import Callback from './components/Callback'
export default class App extends Component {
    static displayName = App.name

    render() {
        return (
            <Layout>
                <script type="text/javascript" src="node_modules/auth0-js/build/auth0.js"></script>
                <Route exact path="/" component={Home} />
                <Route path="/PageView" component={PageView} />
                <Route path="/Categories" component={Categories} />
                <Route path="/PhotoView/:photoID" component={PhotoView} />
                <Route exact path="/PhotoUpload" component={UploadLogin} />
                <Route exact path="/Callback" component={Callback} />
                <Route path="/PhotoUpload/John" component={PhotoUpload} />
            </Layout>
        )
    }
}
