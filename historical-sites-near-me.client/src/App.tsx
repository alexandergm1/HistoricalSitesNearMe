"use client";

import { Component } from "react";
import Home from "./pages/Home.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import GoogleMap from "./features/GoogleMap.tsx";

export class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Routes>
          <Route path="/" Component={Home} />
          <Route path="/map/:lat/:lng" Component={GoogleMap} />
        </Routes>
      </BrowserRouter>
    );
  }
}
