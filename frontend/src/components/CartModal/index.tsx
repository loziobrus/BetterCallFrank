import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { Card, CardActions, CardContent, CardHeader, Grid } from '@mui/material';
import './styles.css'
import { useCartContext, useCartContextUpdate } from '../../context/CartContext';
import CartItem from './CartItem';
import Alert from '../Notification/Alert';

interface ModalProps {
  open: boolean,
  setOpen: (value: boolean) => void 
}

const CartModal = ({ open, setOpen }: ModalProps) => {

  const cart = useCartContext();
  const updateCart = useCartContextUpdate();

  const [alert, setAlert] = useState(false);

  const handleClose = () => setOpen(false);

  const handleRemove = (vehicleId: number) => {
    updateCart(cart.filter(i => i._ID !== vehicleId))
  }

  const getCartTotal = () => {
    let total = cart.map(i => i.price).reduce((partialSum, a) => partialSum + a, 0);
    total = Math.round((total + Number.EPSILON) * 100) / 100
    return `Total: ${total} $`;
  }

  const handleCheckout = () => {
    setAlert(true);
    updateCart([]);
  }

  return (
    <div>
      <Modal open={open} onClose={handleClose} className="modal">
        <Card className="cart-container">
          <CardHeader title="Cart" />
          <CardContent>
            {cart.length > 0 ? (
              cart.map(item => <CartItem vehicle={item} onRemove={handleRemove}/>)
            ) : (
              <Grid
                container
                justifyContent="center"
                alignItems="center"
              >
                No items in the cart.
              </Grid>
            )}
          </CardContent>
          {cart.length > 0 && (
            <CardActions className="cart-checkout">
              <Typography>{getCartTotal()}</Typography>
              <Button variant='contained' color='success' size="small" onClick={() => handleCheckout()}>Check out</Button>
            </CardActions>
          )}
        </Card>
      </Modal>
      <Alert message='Check out successful' open={alert} setOpen={setAlert} />
    </div>
  );
}

export default CartModal