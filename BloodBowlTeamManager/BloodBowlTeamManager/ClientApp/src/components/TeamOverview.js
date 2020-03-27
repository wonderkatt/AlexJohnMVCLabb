import React, { Component } from 'react';

export class TeamOverview extends Component {
    static displayName = TeamOverview.name;

    constructor(props) {
        super(props);
        this.state = { teamToDisplay: '', loading: true };
    }

    componentDidMount() {
        this.populateTeamData();
    }

    static renderTeamOverview(team) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Coach</th>
                        <th>Race</th>
                        <th>Team Value</th>
                    </tr>
                </thead>
                <tbody> 
                    {
                        <tr key={teamToDisplay.Id}> 
                            <td>teamToDisplay.Id</td>
                            <td>teamToDisplay.Coach</td>
                            <td>teamToDisplay.Race</td>
                            <td>teamToDisplay.Teamvalue</td>
                        </tr>
                    }
                </tbody>
            </table>
        );//Dessa propsen kanske ska vara skrivna med gemener både här och i backend? Se tutorial.
    }// Vet inte heller om Key behövs, kanske inte behövs när man endast renderar ett objekt
    
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

    async populateWeatherData() {
        const response = await fetch('team/overview'); //Är denna rätt?
        const data = await response.json();
        this.setState({ teamToDisplay: data, loading: false });
    }
}