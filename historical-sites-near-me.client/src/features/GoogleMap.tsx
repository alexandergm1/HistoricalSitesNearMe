import { APIProvider, Map } from "@vis.gl/react-google-maps";

export default function GoogleMap(props: Props) {
  const position = { lat: props.lat, lng: props.lng };

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
