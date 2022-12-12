import './App.css';
import List from './pages/ChargingStation/List';
import {BrowserRouter} from 'react-router-dom';
import { Routes, Route } from "react-router";
import { Container } from 'reactstrap';

function App() {
  return (
    <BrowserRouter>
     <Container className="flex-grow-1 mt-3 main-panel">
          <Routes>
            <Route path="/" element={<List />} />             
          </Routes>
    </Container>
    </BrowserRouter>
  );
}

export default App;
