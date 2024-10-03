# HistoricalSitesNearMe

## Description
Vite React web app with an ASP.NET Core backend.

This app is designed to query Google's Place API with the user's current GPS coordinates. The data retrieved from Google will contain a list of historical sites and landmarks near to the user, and then render these, along with the hser's location, on a Google Map.

## Running Instructions
1. Clone the repository from GitHub
2. Open the folder containing both HistoricalSitesNearMe.Server and HistoricalSitesNearMe.client using Visual Studio Code.
3. In the terminal, navigate to the client folder and enter "npm i".
4. Open a second terminal tab, and navogate to the Server folder. Once there, enter "dotnet run".
5. In the first terminal tab, enter the command: "npm run dev".

NOTE: This application makes use of Google API. To run this locally, a Google API key is needed and has to be inserted into the local environment variables in both the frontend (process.env.local) and the backend (appsettings.Development.json).