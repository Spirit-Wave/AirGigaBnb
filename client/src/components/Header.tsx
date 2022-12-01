import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import { useNavigate } from "react-router-dom";
import { Avatar } from "@mui/material";
import AdbIcon from "@mui/icons-material/HolidayVillage";

export default function Header() {
  const navigate = useNavigate();
  document.body.style.backgroundColor = "#E6E6E6";

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" style={{ backgroundColor: "#1B1B3A" }}>
        <Toolbar>
          <AdbIcon
            sx={{
              display: { xs: "none", md: "flex", fontSize: "70px" },
              mr: 1,
            }}
          />
          <Typography variant="h2" component="div" sx={{ flexGrow: 1 }}>
            <span style={{ fontFamily: "Impact" }}>GIGABNB</span>
          </Typography>
          <Button
            onClick={() => navigate("/about")}
            color="inherit"
            style={{ marginRight: 25 }}
          >
            About
          </Button>
          <Avatar></Avatar>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
