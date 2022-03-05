import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { Card, CardActions, CardContent, CardHeader } from '@mui/material';
import './styles.css'
import { useCartContext, useCartContextUpdate } from '../../context/CartContext';
import CartItem from './CartItem';
import { SettingsApplicationsRounded } from '@mui/icons-material';

interface ModalProps {
  open: boolean,
  setOpen: (value: boolean) => void 
}

const CartModal = ({ open, setOpen }: ModalProps) => {

  const cart = useCartContext();
  const updateCart = useCartContextUpdate();

  const handleClose = () => setOpen(false);

  const handleRemove = (vehicleId: number) => {
    updateCart(cart.filter(i => i._ID === vehicleId))
  }

  return (
    <div>
      <Modal open={open} onClose={handleClose} className="modal">
        <Card className="cart-container">
          <CardHeader title="Cart" />
          <CardContent>
            {cart.map(item => <CartItem vehicle={item} onRemove={handleRemove}/>)}
          </CardContent>
          {/* <CardActions>
            <Button size="small">Learn More</Button>
          </CardActions> */}
        </Card>
      </Modal>
    </div>
  );
}

export default CartModal