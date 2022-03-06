import React, { useState } from 'react';
import { useCartContext, useCartContextUpdate } from '../../context/CartContext'
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import { Card, CardActions, CardContent, CardHeader } from '@mui/material';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import InfoBlock from './InfoBlock';
import './styles.css'
import Alert from '../Notification/Alert';

interface ModalProps {
  vehicle: Vehicle,
  open: boolean,
  setOpen: (value: boolean) => void 
}

const DetailsModal = ({ vehicle, open, setOpen }: ModalProps) => {

  const cart = useCartContext();
  const updateCart = useCartContextUpdate();

  const [alert, setAlert] = useState(false);
  
  const handleClose = () => setOpen(false);

  const getVehicleLocation = () => {
    return <>
      {`${vehicle.location.warehouseName}, ${vehicle.location.garage}`}<br/>
      {`Lat: ${vehicle.location.warehouseLocation.lat}, Long: ${vehicle.location.warehouseLocation.long}`}
    </>
  }

  const getVehicleName = () => `${vehicle.make} ${vehicle.model}`

  const handleAddToCart = () => {
    updateCart([...cart, vehicle]);
    setAlert(true);
    handleClose();
  }

  return (
    <>
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
            <Button variant='contained' size="small" startIcon={<AddShoppingCartIcon />}
              onClick={() => handleAddToCart()}
              >
              Add to cart
            </Button>
          </CardActions>
        </Card>
      </Modal>
      <Alert message='Added to cart' open={alert} setOpen={setAlert} />
    </>
  );
}

export default DetailsModal