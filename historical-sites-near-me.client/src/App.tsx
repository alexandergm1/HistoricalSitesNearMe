"use client";
//import { useState } from "react";
import {
  APIProvider,
  Map,
  // AdvancedMarker,
  // Pin,
  // InfoWindow,
} from "@vis.gl/react-google-maps";

export default function Intro() {
  const position = { lat: 53.54, lng: 10 };

  return (
    <>
      <h1>Test</h1>
      <APIProvider apiKey={process.env.VITE_GOOGLE_MAPS_API_KEY!}>
        <div style={{ height: "100vh", width: "100%" }}>
          <Map zoom={9} center={position}></Map>
        </div>
      </APIProvider>
    </>
  );
}
