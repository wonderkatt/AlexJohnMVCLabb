import React, { Component } from 'react';

export class BuyPlayerOverview extends Component {
    static displayName = BuyPlayerOverview.name;

    constructor(props) {
        super(props);
        this.state =
        {
            playersToDisplay: [],
            loading: true,
            teamid :""
        };
        this.createPlayer = this.buyPlayer.bind(this);
    }

    componentDidMount() {

        const teamid = this.props.location.state.id;
        this.populatePlayersData(teamid);
    }

    static renderPlayersOverview(players, parent) {
        return (

            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Position</th>
                        <th>Cost</th>
                        <th>Name</th>
                    </tr>
                </thead>
                
                <tbody>
                    {players.map(player =>
                        <tr key={player.id}>
                            <td>{player.position}</td>
                            <td>{player.cost}</td>
                            <td><input type="radio" value={player.position} name="PlayerPosition"></input></td>
                        </tr>
                    )}
                    <tr><br/>
                        <input type="text" placeholder="Enter player name..." name="PlayerName"></input>
                        <input type="submit" value="Buy"></input>
                        <input type="hidden" id="teamId" name="TeamId" value={parent.state.teamid}></input>
                    </tr>
                </tbody>
                
            </table>
            
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : BuyPlayerOverview.renderPlayersOverview(this.state.playersToDisplay, this);
        return (
            <div>
                <h1 id="tabelLabel" >Buy positionals</h1>
                <form onSubmit={this.buyPlayer}>{contents}</form>
            </div>
        );
    }

    async populatePlayersData(teamid) {
        const response = await fetch('/team/players/positions?teamid=' + teamid);
        const data = await response.json();
        this.setState({ playersToDisplay: data, loading: false, teamid : teamid });
    }


    async buyPlayer(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        console.log(JSON.stringify(formData))
        let fetchConfig = {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(formData)

        }
        const response = await fetch('/team/players/create', fetchConfig);
        const data = await response.json();
        //Data gets success or fail for player creation
        //this.populateTeamData();
    }

}