import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { Card, CardActions, CardContent, CardHeader } from '@mui/material';
import './styles.css'

interface ModalProps {
  vehicle: Vehicle,
  open: boolean,
  setOpen: (value: boolean) => void 
}

const DetailsModal = ({ vehicle, open, setOpen }: ModalProps) => {
  const handleClose = () => setOpen(false);

  const getVehicleLocation = () => {
    return <>
      {`${vehicle.location.warehouseName}, ${vehicle.location.garage}`}<br/>
      {`Lat: ${vehicle.location.warehouseLocation.lat}, Long: ${vehicle.location.warehouseLocation.long}`}
    </>
  }

  return (
    <div>
      <Modal open={open} onClose={handleClose} className="modal">
        <Card className="details-container">
          <CardHeader title={`${vehicle.make} ${vehicle.model}`}></CardHeader>
          <CardContent>
            <div className="info-block">
              <Typography variant="h6">
                Location
              </Typography>
              <Typography>
                {getVehicleLocation()}
              </Typography>
            </div>
            <div className="info-block">
              <Typography variant="h6">
                Year
              </Typography>
              <Typography>
                {vehicle.year_Model}
              </Typography>
            </div>
            <div className="info-block">
              <Typography variant="h6">
                Date added
              </Typography>
              <Typography>
                {new Date(vehicle.date_Added).toLocaleDateString("en-US")}
              </Typography>
            </div>
            <div className="info-block">
              <Typography variant="h6">
                Price
              </Typography>
              <Typography>
                {vehicle.price}
              </Typography>
            </div>
          </CardContent>
          {/* <CardActions>
            <Button size="small">Learn More</Button>
          </CardActions> */}
        </Card>
      </Modal>
    </div>
  );
}

export default DetailsModal