import React, { useEffect, useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { getWarehouses } from '../api/requests';
import './styles.css'
import { TableFooter, TablePagination } from '@mui/material';

interface Row {  
  name: string,
  year: number,
  price: number,
  warehouse: string,
  date: Date
}

const VehiclesTable = () => {
  const [rows, setRows] = useState<any>([]);

  const getRows = async () => {
    const data = (await getWarehouses()).data;

    const rows: Row[] = data.map((warehouse: any) => warehouse.cars.vehicles.map((vehicle: any) =>
      ({
        name: `${vehicle.make} ${vehicle.model}`, 
        year: vehicle.year_Model, 
        price: vehicle.price, 
        warehouse: warehouse.name,
        date: new Date(vehicle.date_Added)
      })
    )).flat();

    rows.sort((a, b) => -(b.date.valueOf() - a.date.valueOf()));

    setRows(rows);
  }

  useEffect(() => {
    getRows();
  }, [])

  return (
    <TableContainer component={Paper} className="table-container">
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            <TableCell>Model</TableCell>
            <TableCell align="right">Place</TableCell>
            <TableCell align="right">Year</TableCell>
            <TableCell align="right">Date added</TableCell>
            <TableCell align="right">Price</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row: Row) => (
            <TableRow
              key={row.name}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.name}
              </TableCell>
              <TableCell align="right">{row.warehouse}</TableCell>
              <TableCell align="right">{row.year}</TableCell>
              <TableCell align="right">{row.date.toLocaleDateString("en-US")}</TableCell>
              <TableCell align="right">{row.price} $</TableCell>
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
    </TableContainer>
  );
}

export default VehiclesTable;