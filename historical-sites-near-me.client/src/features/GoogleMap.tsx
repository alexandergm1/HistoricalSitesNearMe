import {
  APIProvider,
  Map,
  AdvancedMarker,
  Pin,
  InfoWindow,
} from "@vis.gl/react-google-maps";
import { useParams } from "react-router-dom";
import { mapStyles } from "../mapStyles";
import { useState } from "react";

export default function GoogleMap() {
  const { lat, lng } = useParams();
  console.log(lat, lng);
  const position = { lat: parseFloat(lat!), lng: parseFloat(lng!) };
  const [open, setOpen] = useState(false);

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
            <AdvancedMarker position={position} onClick={() => setOpen(true)}>
              <Pin
                background={"red"}
                borderColor={"grey"}
                glyphColor={"purple"}
              ></Pin>
            </AdvancedMarker>
            {open && <InfoWindow position={position}></InfoWindow>}
          </Map>
        </div>
      </APIProvider>
    </>
  );
}
