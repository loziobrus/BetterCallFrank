import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { getVehicles } from '../api/requests';
import './styles.css'
import { TableFooter, TablePagination } from '@mui/material';
import DetailsModal from '../Modal';

const VehiclesTable = () => {
  const [rows, setRows] = useState<Vehicle[]>([]);
  const [open, setOpen] = useState<boolean>(false);
  const [vehicle, setVehicle] = useState<Vehicle>({ 
    _ID: 0, 
    date_Added: new Date(), 
    licensed: false, 
    location: {
      garage: '',
      warehouseLocation: {
        lat: '',
        long: ''
      },
      warehouseName: ''
    }, 
    make: '',
    model: '',
    price: 0,
    year_Model: 0
  });

  const getRows = async () => {
    const data: Vehicle[] = (await getVehicles()).data;
    setRows(data);
  }

  useEffect(() => {
    getRows();
  }, [])

  const openModal = (vehicle: Vehicle) => {
    setOpen(true);
    setVehicle(vehicle);
  }

  return (
    <TableContainer component={Paper} className="table-container">
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            <TableCell>Model</TableCell>
            <TableCell align="right">Year</TableCell>
            <TableCell align="right">Date added</TableCell>
            <TableCell align="right">Price</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((vehicle: Vehicle) => (
            <TableRow
              key={vehicle._ID}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              onClick={() => openModal(vehicle)}
            >
              <TableCell component="th" scope="row">
                {vehicle.make} {vehicle.model}
              </TableCell>
              <TableCell align="right">{vehicle.year_Model}</TableCell>
              <TableCell align="right">{new Date(vehicle.date_Added).toLocaleDateString("en-US")}</TableCell>
              <TableCell align="right">{vehicle.price} $</TableCell>
            </TableRow>
          ))}
        </TableBody>
        {/* <TableFooter>
          <TableRow>
          <TablePagination
          rowsPerPageOptions={[5, 10, 25, { label: 'All', value: -1 }]}
          colSpan={3}
          count={rows.length}
          rowsPerPage={10}
          page={page}
          onPageChange={handleChangePage}
          ActionsComponent={TablePaginationActions}
          />
          </TableRow>
        </TableFooter> */}
      </Table>
      <DetailsModal vehicle={vehicle} open={open} setOpen={setOpen}/>
    </TableContainer>
  );
}

export default VehiclesTable;