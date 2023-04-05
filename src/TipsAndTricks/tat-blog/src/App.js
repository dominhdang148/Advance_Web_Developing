import './App.css';
import Navbar from './Component/Navbar';
import SideBar from './Component/Sidebar';
import Footer from './Component/Footer';
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from 'react-router-dom'

function App() {
  return (
    <div>
      <Router>
        <Navbar />
        <div className='container-fluid'>
          <div className='row'>
            <div className='col-9'>
          
            </div>
            <div className='col-3 border-start'>
              <SideBar />
            </div>
          </div>
        </div>
        <Footer />
      </Router>
    </div>

  );
}

export default App;