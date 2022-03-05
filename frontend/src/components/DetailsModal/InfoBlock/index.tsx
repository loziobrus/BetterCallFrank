import React from 'react';
import Typography from '@mui/material/Typography';
import '../styles.css'

interface InfoProps {
  name: string,
  value: any,
}

const InfoBlock = ({ name, value }: InfoProps) => {
  return (
    <div className="info-block">
      <Typography variant="h6">{name}</Typography>
      <Typography>{value}</Typography>
    </div>
  );
}

export default InfoBlock