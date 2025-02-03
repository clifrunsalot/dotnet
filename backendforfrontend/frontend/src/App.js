import React, { useState } from 'react';
import axios from 'axios';

function App() {
  const [data, setData] = useState({ data1: [], data2: [] });

  const loadData = () => {
    axios.get('http://localhost:5000/api/aggregate')
      .then(response => {
        const { data1, data2 } = response.data;
        if (Array.isArray(data1) && Array.isArray(data2)) {
          setData({ data1, data2 });
          console.log('Data loaded successfully', response.data);
        } else {
          console.error('Invalid data structure', response.data);
        }
      })
      .catch(error => {
        console.error('There was an error fetching the data!', error);
      });
  };

  const clearData = () => {
    setData({ data1: [], data2: [] });
  };

  return (
    <div className="App">
      <h1>Data from Microservices</h1>
      <button onClick={loadData}>Load</button>
      <button onClick={clearData}>Clear</button>
      <table>
        <thead>
          <tr>
            <th>Microservice</th>
            <th>Content Type</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {data.data1.map(item => (
            <tr key={`data1-${item.id}`}>
              <td>Microservice1</td>
              <td>{item.contentType}</td>
              <td>{item.description}</td>
            </tr>
          ))}
          {data.data2.map(item => (
            <tr key={`data2-${item.id}`}>
              <td>Microservice2</td>
              <td>{item.contentType}</td>
              <td>{item.description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;