import React from 'react';
import { ProductCard } from './ProductCard';
import { products } from '../data/products';

export const ProductList: React.FC = () => {
  return (
    <div 
      className="product-list" 
      style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fit, minmax(250px, 1fr))', gap: '20px' }}
    >
      {products.map((product) => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
};