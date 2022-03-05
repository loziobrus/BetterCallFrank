import React from 'react';
import Typography from '@mui/material/Typography';
import ClearIcon from '@mui/icons-material/Clear';
import { Button, Grid } from '@mui/material';
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
    >
      
      <div>
        <Typography variant="h6">{getVehicleName()}</Typography>
        <Typography>{vehicle.year_Model}</Typography>
      </div>
      <div>
        <Button size="small" startIcon={<ClearIcon color='error'/>} onClick={() => onRemove(vehicle._ID)} />
      </div>
    </Grid>
  );
}

export default CartItem