import React, { Component } from 'react';
import BingMap from '../components/BingMap';

interface IProps {
}

interface IState {
    pushpins: any[];
    loading: boolean;
}

export default class Index extends Component<IProps, IState> {
    static displayName = Index.name;

    constructor(props: IProps) {
        super(props);
        this.state = { pushpins: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(pushpins: any[]) {
        return (
            <>
                <BingMap
                    mapOptions={{
                        center: [43.280636, -88.207390],
                        credentials: "AqXItIhuGD_I83veM74qLeuCezizV04sXqWrSG5atKCkQV2KPgWeefqioW7XfLm4",
                        pushpins: pushpins,
                        zoom: 15
                    }}
                    />
            </>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : Index.renderForecastsTable(this.state.pushpins);

        return (
            <>
                {contents}
            </>
        );
    }

    async populateWeatherData() {
        const response = await fetch('pushpins');
        const data = await response.json();
        console.log(data);
        this.setState({ pushpins: data, loading: false });
    }
}
