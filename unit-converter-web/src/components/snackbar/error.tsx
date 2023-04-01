import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar"
import { useAppContext } from "../../contexts/app-context";

export const ErrorSnackbar = (props: {openDialog: boolean, message: string}) => {
  const { openDialog, message } = props;
  const appContext = useAppContext();

  return (
    <Snackbar
        open={openDialog}
        autoHideDuration={6000}
        onClose={appContext.dispatch({type: 'CLEAR_ERROR'})}        
      >
        <Alert severity="error">{message}</Alert>
      </Snackbar>
  )
}