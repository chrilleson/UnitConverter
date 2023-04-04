import MuiAlert, { AlertProps } from '@mui/material/Alert';

import Snackbar from "@mui/material/Snackbar"
import { forwardRef } from "react";
import { useUiContext } from "../../contexts/ui-context";

export const ErrorSnackbar = (props: {openDialog: boolean, message: string}) => {
  const { openDialog, message } = props;
  const uiContext = useUiContext();

  const Alert = forwardRef<HTMLDivElement, AlertProps>(function Alert(
    props,
    ref,
  ) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
  });

  const handleOnClose = () => {
    uiContext.dispatch({
      type:'CLEAR_ERROR'
    });
  }

  return (
    <Snackbar
        open={openDialog}
        autoHideDuration={6000}
        onClose={handleOnClose}     
      >
        <Alert severity="error">{message}</Alert>
      </Snackbar>
  )
}