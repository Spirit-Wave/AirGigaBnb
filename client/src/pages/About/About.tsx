import { Card, Typography } from "@mui/material";
import Header from "../../components/Header/Header";
import "../../styles/App.scss";

function About() {
  return (
    <>
      <Header />
      <div>
        <Card
          style={{
            width: "30%",
            display: "flex",
            justifyContent: "center",
            marginTop: "10px",
            alignItems: "center",
          }}
        >
          {" "}
          <Typography fontSize={"50px"}>Apie mus</Typography>
        </Card>
      </div>
    </>
  );
}

export default About;
