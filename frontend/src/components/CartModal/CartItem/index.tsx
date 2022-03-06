import React from 'react';
import Typography from '@mui/material/Typography';
import ClearIcon from '@mui/icons-material/Clear';
import { Grid, IconButton } from '@mui/material';
import '../styles.css'

interface CartItemProps {
  vehicle: Vehicle,
  onRemove: (vehicleId: number) => void
}

const CartItem = ({ vehicle, onRemove }: CartItemProps) => {

  const getVehicleName = () => `${vehicle.make} ${vehicle.model}`

  return (
    <Grid
      container
      direction="row"
      justifyContent="space-between"
      marginBottom="15px"
    > 
      <div>
        <Typography variant="h6">{getVehicleName()}</Typography>
        <Typography>{vehicle.year_Model}</Typography>
      </div>
      <div className="price-remove">
        <Typography>{vehicle.price} $</Typography>
        <IconButton onClick={() => onRemove(vehicle._ID)}>
          <ClearIcon fontSize='small' color='error'/>
        </IconButton>
      </div>
    </Grid>
  );
}

export default CartItem