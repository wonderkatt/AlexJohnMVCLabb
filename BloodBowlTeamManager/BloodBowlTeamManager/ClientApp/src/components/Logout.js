import React, { Component } from 'react';

export class Logout extends Component {
    static displayName = Logout.name;

    constructor(props) {
        super(props);
        this.OnSubmit = this.OnSubmit.bind(this);
    }

    render() {
        return (
            <div>
                <h1>Login</h1>
                <hr />
                <div className="row">
                    <div className="col-md-4">
                        <form onSubmit={this.OnSubmit}>
                            <div className="text-danger"></div>
                            <div className="form-group">
                                <input type="submit" value="Logout" className="btn btn-primary" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }


    async OnSubmit(e) {
        e.preventDefault();
        let fetchConfig = {
            method: "POST",
            headers: { "Content-Type": "application/json" }
        }
        let response = await fetch("/account/logout", fetchConfig);
        alert(response.status);
    }
}



