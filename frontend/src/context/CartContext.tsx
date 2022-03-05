import React, { useContext, useState } from "react";

const CartContext = React.createContext<Vehicle[]>([]);
const CartUpdateContext = React.createContext<Function>(() => {});

export const useCartContext = () => {
  return useContext(CartContext);
}

export const useCartContextUpdate = () => {
  return useContext(CartUpdateContext);
}

export const CartProvider = ({ children }: any) => {
  const [cart, setCart] = useState<Vehicle[]>([]);

  const updateCart = (vehicles: Vehicle[]) => {
    setCart(vehicles)
  }

  return (
    <CartContext.Provider value={cart}>
      <CartUpdateContext.Provider value={updateCart}>
        {children}
      </CartUpdateContext.Provider>
    </CartContext.Provider>
  );
}
