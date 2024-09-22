import { APIProvider, Map, AdvancedMarker } from "@vis.gl/react-google-maps";
import { useParams } from "react-router-dom";
import { mapStyles } from "../mapStyles";

export default function GoogleMap() {
  const { lat, lng } = useParams();
  console.log(lat, lng);
  const position = { lat: parseFloat(lat!), lng: parseFloat(lng!) };

  return (
    <>
      <h1>Test</h1>
      <APIProvider apiKey={import.meta.env.VITE_GOOGLE_MAPS_API_KEY!}>
        <div style={{ height: "100vh", width: "100%" }}>
          <Map
            defaultZoom={12}
            defaultCenter={position}
            gestureHandling={"greedy"}
            mapId={import.meta.env.VITE_GOOGLE_MAPS_UNIQUE_ID!}
            styles={mapStyles}
          >
            <AdvancedMarker position={position}></AdvancedMarker>
          </Map>
        </div>
      </APIProvider>
    </>
  );
}
