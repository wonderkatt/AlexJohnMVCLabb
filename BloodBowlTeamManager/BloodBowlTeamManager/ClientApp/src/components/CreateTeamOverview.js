import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class CreateTeamOverview extends Component {
    static displayName = CreateTeamOverview.name;

    constructor(props) {
        super(props);
        this.state =
        {
            racesToDisplay: [],
            loading: true,
            TeamName: "",
            Race: "",
            redirect: null

        };
        this.createTeam = this.createTeam.bind(this);

    }

    componentDidMount() {

        this.getRacesData();
    }

    static renderCreateTeam(races, parent) {
        return (
            <form onSubmit={parent.createTeam}>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Race</th>
                        </tr>
                    </thead>

                    <tbody>
                        {races.map(race =>
                            <tr>
                                <td>{race.race}</td>
                                <td><input type="radio" onChange={parent.handleChange} value={race.race} name="Race" className="form-control"></input></td>
                            </tr>
                        )}
                        <tr>
                            <td><input onChange={parent.handleChange} placeholder="Enter team name..." name="TeamName" className="form-control"></input></td>
                            <td><input type="submit" value="Create" className="form-control"></input></td>
                        </tr>
                    </tbody>

                </table>
            </form>
        );
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value })
        console.log(this.state)
    }

    render() {
        if (this.state.redirect) {
            return <Redirect to={{
                pathname: this.state.redirect
            }} />
        }
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CreateTeamOverview.renderCreateTeam(this.state.racesToDisplay, this);
        return (
            <div>
                <h1 id="tabelLabel" >Create Team</h1>
                {contents}
            </div>
        );
    }

    async getRacesData() {
        const response = await fetch('/team/races');
        const data = await response.json();
        this.setState({ racesToDisplay: data, loading: false});
    }


    async createTeam(e) {
        e.preventDefault();
        let fetchConfig = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(this.state)
        }
        const response = await fetch('/team/create', fetchConfig);
        const data = await response.json();
        //Data gets success or fail for team creation
        this.setState({ redirect: "/team/overview" })
    }

}