import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { Button, CardActions, Grid } from "@mui/material";
import { IApartment } from "../interfaces/IApartment";
import FavoriteIcon from "@mui/icons-material/Favorite";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { useState } from "react";

function ApartmentCard(props: IApartment) {
  const [favorite, setFavorite] = useState(props.favorite);
  const toggleFavorite = () => {
    setFavorite(!favorite);
    // turėtų išsiųsti requestą į backa kad uždėtų favorite useriui
  };

  return (
    <Grid item xs={6} sm={3} md={3} style={{ marginBottom: 50 }}>
      <Card sx={{ maxWidth: 345, marginLeft: 7, marginTop: 4, marginRight: 7 }}>
        <CardMedia
          component="img"
          alt="photo"
          height="140"
          image={require("../assets/Small-apartment-design.jpg")}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {props.title}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            <b>Aprašymas: </b>
            {props.description}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            <br></br>
          </Typography>
          <Typography variant="body2" color="text.secondary">
            <b>Miestas: </b>
            {props.city}
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small" onClick={toggleFavorite}>
            {favorite ? (
              <FavoriteIcon style={{ color: "red" }} />
            ) : (
              <FavoriteBorderIcon style={{ color: "red" }} />
            )}
          </Button>
          <Button size="small">Peržiūrėti</Button>
        </CardActions>
      </Card>
    </Grid>
  );
}

export default ApartmentCard;
