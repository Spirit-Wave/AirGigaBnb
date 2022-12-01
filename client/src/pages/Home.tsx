import {
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  SelectChangeEvent,
  TextField,
} from "@mui/material";
import React from "react";
import ApartmentList from "../components/ApartmentList";
import "../styles/Home.css";

function Home() {
  const [filterValue, setFilter] = React.useState("10");

  const handleChange = (event: SelectChangeEvent) => {
    setFilter(event.target.value);
  };

  return (
    <div className="bg">
      <div className="search-field">
        <TextField
          id="outlined-basic"
          label="Apartamentų paieška"
          variant="outlined"
          style={{ width: 500 }}
        />
      </div>
      <div className="form-control">
        <FormControl>
          <InputLabel id="demo-simple-select-label">Miestas</InputLabel>
          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={filterValue}
            label="Miestas"
            onChange={handleChange}
          >
            <MenuItem value={10}>Vilnius</MenuItem>
            <MenuItem value={20}>Kaunas</MenuItem>
            <MenuItem value={30}>Klaipėda</MenuItem>
          </Select>
        </FormControl>
      </div>
      <ApartmentList filterValue={filterValue} />
    </div>
  );
}

export default Home;
