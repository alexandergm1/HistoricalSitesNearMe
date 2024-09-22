import MapIcon from "@mui/icons-material/Map";
import ForwardIcon from "@mui/icons-material/Forward";
import { Container, CssBaseline, Box, Avatar, Button } from "@mui/material";
import { useState } from "react";
import MyLocationIcon from "@mui/icons-material/MyLocation";
import { Link } from "react-router-dom";

const Home = () => {
  type Coordinates = {
    lat: number;
    lng: number;
  };
  const [coords, setCoords] = useState<Coordinates>();

  const handleContinue = () => {
    console.log(`Lat: ${coords?.lat}, Long: ${coords?.lng}`);
  };

  const handleGetLocation = () => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(success, error);
    } else {
      console.log("Geolocation not supported");
    }

    function success(position: {
      coords: {
        latitude: number;
        longitude: number;
      };
    }) {
      setCoords({
        lat: position.coords.latitude,
        lng: position.coords.longitude,
      });
    }

    function error() {
      console.log("Unable to retrieve your location");
    }
  };
  return (
    <>
      <Container maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            mt: 20,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "primary.light" }}>
            <MapIcon />
          </Avatar>
          <Button
            variant="contained"
            sx={{ mt: 3, mb: 2 }}
            onClick={handleGetLocation}
            endIcon={<MyLocationIcon />}
          >
            Get My Location
          </Button>
          <Link
            to={`/map/${coords?.lat}/${coords?.lng}`}
            state={{ from: "occupation" }}
          >
            <Button
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              onClick={handleContinue}
              endIcon={<ForwardIcon />}
            >
              Continue
            </Button>
          </Link>
        </Box>
      </Container>
    </>
  );
};

export default Home;
