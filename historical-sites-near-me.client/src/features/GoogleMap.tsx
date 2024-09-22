import { APIProvider, Map } from "@vis.gl/react-google-maps";
import { useParams } from "react-router-dom";

export default function GoogleMap() {
  const { lat, lng } = useParams();
  console.log(lat, lng);
  const position = { lat: parseFloat(lat!), lng: parseFloat(lng!) };

  return (
    <>
      <h1>Test</h1>
      <APIProvider apiKey={import.meta.env.VITE_GOOGLE_MAPS_API_KEY!}>
        <div style={{ height: "100vh", width: "100%" }}>
          <Map zoom={9} center={position}></Map>
        </div>
      </APIProvider>
    </>
  );
}
