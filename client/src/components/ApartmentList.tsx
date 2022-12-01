import { useState, useEffect } from "react";
import ApartmentCard from "./ApartmentCard";
import { Grid } from "@mui/material";
import { IApartment } from "../interfaces/IApartment";

const dummyApartments: IApartment[] = [
  {
    id: 1,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: true,
  },
  {
    id: 2,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 3,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: true,
  },
  {
    id: 4,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 5,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 6,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
  {
    id: 7,
    title: "Trakai",
    description: "Hello",
    city: "Vilnius",
    favorite: false,
  },
];

const ApartmentList = (props: any) => {
  const [apartments, setApartments] = useState<IApartment[]>([]);

  useEffect(() => {
    setApartments(dummyApartments);
  }, []);

  return (
    <Grid container>
      {apartments.map((apartment) => {
        return (
          <ApartmentCard
            key={apartment.id}
            id={apartment.id}
            title={apartment.title}
            description={apartment.description}
            city={apartment.city}
            favorite={apartment.favorite}
          />
        );
      })}
    </Grid>
  );
};

export default ApartmentList;
