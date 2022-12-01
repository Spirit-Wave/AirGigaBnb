import { Box, Paper, Container, Typography } from "@mui/material";
import styles from "./footer.module.scss";

function Footer() {
  return (
    <Paper
      sx={{
        marginTop: "0px",
        width: "100%",
        position: "fixed",
        bottom: 0,
        height: 30,
      }}
      component="footer"
      square
      variant="outlined"
    >
      <Container maxWidth="lg">
        <Box
          sx={{
            flexGrow: 1,
            justifyContent: "center",
            display: "flex",
            my: 1,
          }}
        ></Box>

        <Box
          sx={{
            flexGrow: 1,
            justifyContent: "center",
            display: "flex",
            mb: 2,
          }}
        >
          <Typography
            variant="caption"
            color="initial"
            className={styles.copyright}
          >
            Copyright © 2022 GIGABNB
          </Typography>
        </Box>
      </Container>
    </Paper>
  );
}

export default Footer;
