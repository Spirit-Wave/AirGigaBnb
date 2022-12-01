import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
} from "@mui/material";
import { useState } from "react";
import ApartmentList from "../../components/ApartmentList/ApartmentList";
import Header from "../../components/Header/Header";
import styles from "./home.module.scss";

function Home() {
  const [filterValue, setFilterValue] = useState("Vilnius");

  const handleChange = (event: SelectChangeEvent) => {
    setFilterValue(event.target.value);
  };

  return (
    <>
      <Header />
      <div className={styles.bg}>
        <div className={styles.searchField}>
          <TextField
            id="outlined-basic"
            label="Apartamentų paieška"
            variant="outlined"
            className={styles.searchBox}
          />
        </div>
        <div className={styles.formControl}>
          <FormControl>
            <InputLabel id="demo-simple-select-label">Miestas</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={filterValue}
              label="Miestas"
              onChange={handleChange}
            >
              <MenuItem value={"Vilnius"}>Vilnius</MenuItem>
              <MenuItem value={"Kaunas"}>Kaunas</MenuItem>
              <MenuItem value={"Klaipėda"}>Klaipėda</MenuItem>
            </Select>
          </FormControl>
        </div>
        <ApartmentList filterValue={filterValue} />
      </div>
    </>
  );
}

export default Home;
