import { LockOutlined } from "@mui/icons-material";
import {
  Container,
  CssBaseline,
  Box,
  Avatar,
  Typography,
  TextField,
  Button,
} from "@mui/material";
import { SetStateAction, useState } from "react";
import MyLocationIcon from "@mui/icons-material/MyLocation";

const Home = () => {
  const [postcode, setPostcode] = useState("");
  const [lat, setLat] = useState<number>();
  const [lng, setLng] = useState<number>();

  const handleContinue = () => {
    console.log(`Lat: ${lat}, Long: ${lng}`);
  };

  const handleGetLocation = () => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(success, error);
    } else {
      console.log("Geolocation not supported");
    }

    function success(position: {
      coords: {
        latitude: SetStateAction<number | undefined>;
        longitude: SetStateAction<number | undefined>;
      };
    }) {
      setLat(position.coords.latitude);
      setLng(position.coords.longitude);
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
            <LockOutlined />
          </Avatar>
          <Typography variant="h5">Postcode</Typography>
          <Box sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="postcode"
              label="Postcode"
              name="postcode"
              autoFocus
              value={postcode}
              onChange={(e) => setPostcode(e.target.value)}
            />
            <Button
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2, alignItems: "center" }}
              onClick={handleGetLocation}
              endIcon={<MyLocationIcon />}
            >
              Get My Location
            </Button>
            <Button
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              onClick={handleContinue}
            >
              Continue
            </Button>
          </Box>
        </Box>
      </Container>
    </>
  );
};

export default Home;
