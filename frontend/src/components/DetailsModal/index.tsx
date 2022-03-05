import React from 'react';
import { useCartContext, useCartContextUpdate } from '../../context/CartContext'
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import { Card, CardActions, CardContent, CardHeader } from '@mui/material';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import InfoBlock from './InfoBlock';
import './styles.css'

interface ModalProps {
  vehicle: Vehicle,
  open: boolean,
  setOpen: (value: boolean) => void 
}

const DetailsModal = ({ vehicle, open, setOpen }: ModalProps) => {

  const cart = useCartContext();
  const updateCart = useCartContextUpdate();
  
  const handleClose = () => setOpen(false);

  const getVehicleLocation = () => {
    return <>
      {`${vehicle.location.warehouseName}, ${vehicle.location.garage}`}<br/>
      {`Lat: ${vehicle.location.warehouseLocation.lat}, Long: ${vehicle.location.warehouseLocation.long}`}
    </>
  }

  const getVehicleName = () => `${vehicle.make} ${vehicle.model}`

  return (
    <Modal open={open} onClose={handleClose} className="modal">
      <Card className="details-container">
        <CardHeader title={getVehicleName()}></CardHeader>
        <CardContent>
          <InfoBlock name='Location' value={getVehicleLocation()} />
          <InfoBlock name='Year' value={vehicle.year_Model} />
          <InfoBlock name='Date added' value={new Date(vehicle.date_Added).toLocaleDateString("en-US")} />
          <InfoBlock name='Price' value={`${vehicle.price} $`} />
        </CardContent>
        <CardActions>
          <Button size="small" startIcon={<AddShoppingCartIcon />}
            onClick={() => updateCart([...cart, vehicle])}
          >
            Add to cart
          </Button>
        </CardActions>
      </Card>
    </Modal>
  );
}

export default DetailsModal