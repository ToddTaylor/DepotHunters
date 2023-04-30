import * as React from "react";
import { loadBingApi, Microsoft } from "./BingMapLoader";

interface IMapProps {
  mapOptions?: any;
}

class BingMap extends React.Component<IMapProps, any> {

  private mapRef = React.createRef<HTMLDivElement>();

  public componentDidMount() {
    const key = this.props.mapOptions.credentials;

    loadBingApi(key).then(() => {
      this.initMap();
    });
  }

  public render() {
    return <div ref={this.mapRef} />;
  }

  private initMap() {
    const map = new Microsoft.Maps.Map(this.mapRef.current);

    if (this.props) {
      map.setView(
        {
          center: new Microsoft.Maps.Location(this.props.mapOptions.center[0], this.props.mapOptions.center[1]),
          zoom: this.props.mapOptions.zoom
        });

      for (let p of this.props.mapOptions.pushpins) {
        let location = new Microsoft.Maps.Location(p.latitude, p.longitude);
        var pushpin = new Microsoft.Maps.Pushpin(location, null);
        map.entities.push(pushpin);
      }
    }

    return map;
  }
}

export default BingMap;
