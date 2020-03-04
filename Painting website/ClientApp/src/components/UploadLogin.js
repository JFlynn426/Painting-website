import React, { Component } from 'react'
import axios from 'axios'

class UploadLogin extends Component {
    doLogin = () => {
        this.props.auth.login()
    }
    render() {
        return (
            <div className="App">
                <h1>Upload Photo Page</h1>
                <button className="btn btn-info" onClick={this.doLogin}>
                    Log In
        </button>
            </div>
        )
    }
}

export default UploadLogin
