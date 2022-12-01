import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import { Button, CardActions, Grid } from "@mui/material";
import { IApartment } from "../../interfaces/IApartment";
import FavoriteIcon from "@mui/icons-material/Favorite";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { useState } from "react";
import styles from "./apartmentcard.module.scss";
import axios from "axios";

function ApartmentCard(props: IApartment) {
  const [favorite, setFavorite] = useState(false);
  const toggleFavorite = () => {
    axios
      .post<IApartment[]>("https://localhost:7244/favorite/toggle-favorite", {
        userId: sessionStorage.getItem("userID"),
        listingId: props.id,
      })
      .then(
        (response) => {
          console.log(response);
          setFavorite(!favorite);
        },
        (error) => {
          console.log(error);
        }
      );
  };

  return (
    <Grid item xs={6} sm={3} md={3} className={styles.grid}>
      <Card
        sx={{
          maxWidth: 345,
          marginLeft: 7,
          marginTop: 4,
          marginRight: 7,
          marginBottom: 5,
        }}
      >
        <CardMedia
          component="img"
          alt="photo"
          height="140"
          image={require("../../assets/Small-apartment-design.jpg")}
        />
        <CardContent>
          <Typography
            gutterBottom
            variant="h5"
            component="div"
            style={{
              textOverflow: "ellipsis",
              whiteSpace: "nowrap",
              overflow: "hidden",
            }}
          >
            {props.title}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            <b>Aprašymas: </b>
            {props.summary}
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
          <Button size="small">Peržiūrėti</Button>
          <Button
            size="small"
            onClick={toggleFavorite}
            className={styles.perziuretiButton}
          >
            {favorite ? (
              <FavoriteIcon className={styles.favourite} />
            ) : (
              <FavoriteBorderIcon className={styles.favourite} />
            )}
          </Button>
        </CardActions>
      </Card>
    </Grid>
  );
}

export default ApartmentCard;
