import React, { Component } from 'react';
import { Link } from 'react-router-dom';


export class TeamOverview extends Component {
    static displayName = TeamOverview.name;

    constructor(props) {
        super(props);
        this.state = { teamToDisplay: [], loading: true };
    }

    componentDidMount() {
        this.populateTeamData();
    }

    static renderTeamOverview(teams) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Team Name</th>
                        <th>Coach</th>
                        <th>Race</th>
                        <th>Team Value</th>
                    </tr>
                </thead>
                <tbody> 
                    {teams.map(team=>
                        <tr key={team.id}> 
                            <td>{team.id}</td>
                            <td>{team.teamName}</td>
                            <td>{team.coach}</td>
                            <td>{team.race}</td>
                            <td>{team.teamvalue}</td>
                            <td><Link to={{
                                pathname: '/team/players',
                                state: {
                                    id: team.id
                                }
                            }}> Team </Link></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }
    //
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TeamOverview.renderTeamOverview(this.state.teamToDisplay);

        return (
            <div>
                <h1 id="tabelLabel" >Team Overview</h1>
                {contents}
            </div>
        );
    }

    async populateTeamData() {
        const response = await fetch('/team/overview'); 
        const data = await response.json();
        this.setState({ teamToDisplay: data, loading: false });
    }
}