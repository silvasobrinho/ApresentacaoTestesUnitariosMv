import React, { useState, useEffect } from 'react';
import './ConselhoComponente.css';

const MyComponent = () => {
  const [advice, setAdvice] = useState('');

  const fetchAdvice = async () => {
    try {
      const response = await fetch('https://localhost:7170/Conselhos');
      const data = await response.json();
      setAdvice(data.data.slip.advice);
    } catch (error) {
      console.error('Error fetching advice:', error);
    }
  };

  useEffect(() => {
    fetchAdvice();
  }, []);

  return (
    <div className="my-component">
      <div className="advice">{advice}</div>
      <button className="fetch-button" onClick={fetchAdvice}>
        Obter Novo Conselho
      </button>
    </div>
  );
};

export default MyComponent;