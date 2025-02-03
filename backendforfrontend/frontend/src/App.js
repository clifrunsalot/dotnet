import React, { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
  const [data, setData] = useState({ data1: [], data2: [] });

  useEffect(() => {
    axios.get('http://localhost:5000/api/aggregate')
      .then(response => {
        setData(response.data);
      })
      .catch(error => {
        console.error('There was an error fetching the data!', error);
      });
  }, []);

  return (
    <div className="App">
      <h1>Data from Microservices</h1>
      <h2>Data1</h2>
      <ul>
        {data.data1.map(item => (
          <li key={item.id}>{item.name}</li>
        ))}
      </ul>
      <h2>Data2</h2>
      <ul>
        {data.data2.map(item => (
          <li key={item.id}>{item.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;