import { useState, useEffect } from "react";
import ApartmentCard from "../ApartmentCard/ApartmentCard";
import { Grid } from "@mui/material";
import { IApartment } from "../../interfaces/IApartment";
import axios from "axios";

const ApartmentList = (props: any) => {
  const [apartments, setApartments] = useState<IApartment[]>([]);

  useEffect(() => {
    axios.get<IApartment[]>("https://localhost:7244/listing/all", {}).then(
      (response) => {
        console.log(response);
        setApartments(response.data);
      },
      (error) => {
        console.log(error);
      }
    );
  }, []);

  return (
    <Grid container>
      {apartments.map((apartment) => {
        return (
          <ApartmentCard
            key={apartment.id}
            id={apartment.id}
            title={apartment.title}
            summary={apartment.summary}
            city={apartment.city}
          />
        );
      })}
    </Grid>
  );
};

export default ApartmentList;
