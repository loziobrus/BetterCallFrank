import React, { useState } from 'react';
import './App.css';
import VehiclesTable from './components/Table';
import CartButton from './components/CartButton';
import { CartProvider } from './context/CartContext'

function App() {
  return (
    <CartProvider>
      <div className="app">
        <div className="app-header">
          <CartButton />
        </div>
        <div className="app-body">
          <VehiclesTable />
        </div>
      </div>
    </CartProvider>
  );
}

export default App;
