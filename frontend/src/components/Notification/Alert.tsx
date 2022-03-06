import * as React from 'react';
import Snackbar from '@mui/material/Snackbar';
import MuiAlert, { AlertProps } from '@mui/material/Alert';

interface MessageProps {
  message: string,
  open: boolean,
  setOpen: (open: boolean) => void
}

const Message = React.forwardRef<HTMLDivElement, AlertProps>(function Message(props, ref) {
  return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const Alert = ({ message, open, setOpen }: MessageProps) => {

  const handleClose = (event?: React.SyntheticEvent | Event, reason?: string) => {
    if (reason === 'clickaway') {
      return;
    }

    setOpen(false);
  };

  return (
    <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
      <Message onClose={handleClose} severity="success" sx={{ width: '100%' }}>
          {message}
      </Message>
    </Snackbar>
  );
}

export default Alert