import './App.css';
import Navbar from './Component/Navbar';
import SideBar from './Component/Sidebar';
import Footer from './Component/Footer';
import Index from './Pages/Index';
import About from './Pages/About';
import Contact from './Pages/Contact';
import Rss from './Pages/Rss';
import Layout from './Pages/Layout';

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
              <Routes>
                <Route path='/' element={<Layout />}>
                  <Route path='/' element={<Index />} />
                  <Route path='blog' element={<Index />} />
                  <Route path='blog/Contact' element={<Contact />} />
                  <Route path='blog/About' element={<About />} />
                  <Route path='blog/Rss' element={<Rss />} />
                </Route>
              </Routes>
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