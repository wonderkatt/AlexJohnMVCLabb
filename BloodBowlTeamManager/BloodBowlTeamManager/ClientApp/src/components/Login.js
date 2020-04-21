import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';


export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state =
        {
            CoachName: "",
            Password: "",
            redirect: null
        };
        this.OnSubmit = this.OnSubmit.bind(this);
    }

    render() {

        if (this.state.redirect) {
            return <Redirect to={{
                pathname: this.state.redirect
            }} />
        }
        return (
            <div>
                <h1>Login</h1>
                <hr />
                <div className="row">
                    <div className="col-md-4">
                        <form onSubmit={this.OnSubmit}>
                            <div className="text-danger"></div>
                            <div className="form-group">
                                <label className="control-label"> Coach Name</label>
                                <input onChange={this.HandleChange} name="CoachName" className="form-control" />
                                <span className="text-danger"></span>
                            </div>
                            <div className="form-group">
                                <label className="control-label">Password</label>
                                <input type="Password" onChange={this.HandleChange} name="Password" className="form-control" />
                                <span className="text-danger"></span>
                            </div>
                            <div className="form-group">
                                <input type="submit" value="Login" className="btn btn-primary" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
    HandleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value })

    }


    async OnSubmit(e) {
        e.preventDefault();
        let fetchConfig = { method: "POST", headers: { "Content-Type": "application/json" }, body: JSON.stringify(this.state) }
        let response = await fetch("/account/login", fetchConfig);
        let data = await response.json();
        if (data.success === true) {
            this.setState({redirect:'/'});
        }
        else {
            alert("log in failed, should implement proper error message!")
            //errormessage.wrongusernamensokdalsdk
        }
    }
}



