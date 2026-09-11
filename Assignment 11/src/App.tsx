import React from 'react';
import { ProductList } from './components/ProductList';

const App: React.FC = () => {
  return (
    <div style={{ maxWidth: '1200px', margin: '0 auto', padding: '20px', fontFamily: 'sans-serif' }}>
      <h1 style={{ textAlign: 'center', marginBottom: '40px' }}>Our Product Catalog</h1>
      <ProductList />
    </div>
  );
};

export default App;