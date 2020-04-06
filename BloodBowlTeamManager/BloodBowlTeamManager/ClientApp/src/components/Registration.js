import React, { Component } from 'react';



export class Registration extends Component {
    static displayName = Registration.name;

    constructor(props) {
        super(props);
        this.state = { CoachName: "", Email: "", Password: "", ConfirmPassword: ""};
        this.OnSubmit = this.OnSubmit.bind(this);
    }
    
    render() {
        return(
        <div>
            <h1>Register</h1>

            <h4>UserRegistrationModel</h4>
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
                            <label className="control-label">Confirm Password</label>
                            <input type="Password" onChange={this.HandleChange} name="ConfirmPassword" className="form-control" />
                            <span className="text-danger"></span>
                        </div>
                        <div className="form-group">
                            <label className="control-label">Email Address</label>
                            <input type="email" onChange={this.HandleChange} name="Email" className="form-control" />
                            <span className="text-danger"></span>
                        </div>
                        <div className="form-group">
                            <input type="submit" value="Create" className="btn btn-primary" />
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
        let fetchConfig = { method: "POST", headers: {"Content-Type": "application/json" }, body: JSON.stringify(this.state)}
        let response = await fetch("/account/registration", fetchConfig);

    }
}



