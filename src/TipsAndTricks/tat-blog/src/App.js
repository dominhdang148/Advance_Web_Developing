import './App.css';
import AdminLayout from './Pages/Admin/Layout';
import * as AdminIndex from './Pages/Admin/Index';
import Footer from './Components/Footer';
import Index from './Pages/Index';
import About from './Pages/About';
import NotFound from './Pages/NotFound';
import BadRequest from './Pages/BadRequest';
import Contact from './Pages/Contact';
import Rss from './Pages/Rss';
import Layout from './Pages/Layout';

import {
  BrowserRouter as Router,
  Routes,
  Route,
} from 'react-router-dom'
import Posts from './Pages/Admin/Post/Posts';
import Edit from './Pages/Admin/Post/Edit';


function App() {
  return (
    <Router>
      <Routes>
        <Route path='/' element={<Layout />}>
          <Route path='/' element={<Index />} />
          <Route path='blog' element={<Index />} />
          <Route path='blog/Contact' element={<Contact />} />
          <Route path='blog/About' element={<About />} />
          <Route path='blog/Rss' element={<Rss />} />
        </Route>
        <Route path='/admin' element={<AdminLayout />}>
          <Route path="/admin" element={<AdminIndex.default />} />
          <Route path="/admin/posts" element={<Posts />} />
          <Route path="/admin/posts/edit" element={<Edit />} />
          <Route path="/admin/posts/edit/:id" element={<Edit />} />
        </Route>

        <Route path='/400' element={<BadRequest />} />
        <Route path='*' element={<NotFound />} />


      </Routes>
      <Footer />
    </Router>

  );
}

export default App;