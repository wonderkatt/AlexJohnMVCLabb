import React, { Component } from 'react';

export class TeamOverview extends Component {
    static displayName = TeamOverview.name;

    constructor(props) {
        super(props);
        this.state = { teamToDisplay: [], loading: true };
    }

    componentDidMount() {
        this.populateTeamData();
    }

    static renderTeamOverview(team) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
            </table>
        );
    }

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