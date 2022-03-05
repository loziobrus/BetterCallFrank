import React, { useState } from 'react';
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { IconButton } from '@mui/material';
import CartModal from '../CartModal';
import './styles.css';

const CartButton = () => {
  const [open, setOpen] = useState<boolean>(false);

  return (
    <>
      <IconButton onClick={() => setOpen(true)}>
        <ShoppingCartIcon className='cart-button'/>
      </IconButton>
      <CartModal open={open} setOpen={setOpen} />
    </>
  );
}

export default CartButton;
