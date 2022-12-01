import {
  List,
  ListItem,
  ListItemAvatar,
  Avatar,
  ListItemText,
  IconButton,
} from "@mui/material";
import HouseIcon from "@mui/icons-material/House";
import DoNotDisturbIcon from "@mui/icons-material/DoNotDisturb";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import VisibilityIcon from "@mui/icons-material/Visibility";
import styles from "./apartmentapprovelist.module.scss";
import { IApartment } from "../../interfaces/IApartment";
import { useEffect, useState } from "react";
import axios from "axios";

function ApartmentApproveList(props: IApartment) {
  return (
    <div>
      <List>
        <ListItem>
          <ListItemAvatar>
            <Avatar>
              <HouseIcon />
            </Avatar>
          </ListItemAvatar>
          <ListItemText primary="Single-line item" />
          <IconButton
            className={styles.buttonReject}
            edge="end"
            aria-label="delete"
          >
            <VisibilityIcon className={styles.buttonView} />
          </IconButton>
          <IconButton
            className={styles.buttonApprove}
            edge="end"
            aria-label="delete"
          >
            <CheckCircleOutlineIcon />
          </IconButton>
          <IconButton
            className={styles.buttonReject}
            edge="end"
            aria-label="delete"
          >
            <DoNotDisturbIcon />
          </IconButton>
        </ListItem>
      </List>
    </div>
  );
}

export default ApartmentApproveList;
