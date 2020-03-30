import React, { Component } from 'react';

export class TeamPlayersOverview extends Component {
    static displayName = TeamPlayersOverview.name;

    constructor(props) {
        super(props);
        this.state = { playersToDisplay: [], loading: true };
        
    }

    componentDidMount() {
        
        const teamid = this.props.location.state.id;
     
        console.log(teamid);
        this.populatePlayersData(teamid);
    }

    static renderPlayersOverview(players) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Number</th>
                        <th>Player Name</th>
                        <th>Position</th>
                    </tr>
                </thead>
                <tbody>
                    {players.map(player =>
                        <tr key={player.id}>
                            <td>{player.id}</td>
                            <td>{player.number}</td>
                            <td>{player.playername}</td>
                            <td>{player.position}</td>
                            
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : TeamPlayersOverview.renderPlayersOverview(this.state.playersToDisplay);

        return (
            <div>
                <h1 id="tabelLabel" >Players Overview</h1>
                {contents}
            </div>
        );
    }

    async populatePlayersData(teamid) {
        const response = await fetch('/team/players?teamid=' +  teamid );
        const data = await response.json();
        this.setState({ playersToDisplay: data, loading: false });
    }
}