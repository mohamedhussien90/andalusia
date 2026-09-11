import React from 'react';
import { Product } from '../types/Product';

// Define the props interface expected by this component
interface ProductCardProps {
  product: Product;
}

export const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  return (
    <div className="product-card" style={{ border: '1px solid #ccc', padding: '1rem', borderRadius: '8px' }}>
      <img 
        src={product.image} 
        alt={product.name} 
        style={{ width: '100%', height: '200px', objectFit: 'cover', borderRadius: '4px' }} 
      />
      <h3>{product.name}</h3>
      <p><strong>Brand:</strong> {product.brand}</p>
      <p><strong>Price:</strong> ${product.price.toFixed(2)}</p>
      <p style={{ color: product.inStock ? 'green' : 'red', fontWeight: 'bold' }}>
        {product.inStock ? 'In Stock' : 'Out of Stock'}
      </p>
    </div>
  );
};