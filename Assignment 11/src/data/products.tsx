import { Product } from '../types/Product';
// Assuming images are placed in src/assets/
import laptopImg from '../assets/laptop.jpg'; 
import phoneImg from '../assets/phone.jpg';
import headphonesImg from '../assets/headphones.jpg';
import monitorImg from '../assets/monitor.jpg';
import keyboardImg from '../assets/keyboard.jpg';
import mouseImg from '../assets/mouse.jpg';

export const products: Product[] = [
  { id: 1, name: "ProBook 15", brand: "TechCorp", price: 999.99, image: laptopImg, inStock: true },
  { id: 2, name: "Smartphone X", brand: "MobileCo", price: 799.00, image: phoneImg, inStock: false },
  { id: 3, name: "Noise Cancelling Headphones", brand: "AudioMax", price: 199.50, image: headphonesImg, inStock: true },
  { id: 4, name: "27-inch 4K Monitor", brand: "Visionary", price: 349.99, image: monitorImg, inStock: true },
  { id: 5, name: "Mechanical Keyboard", brand: "ClickKey", price: 89.99, image: keyboardImg, inStock: false },
  { id: 6, name: "Wireless Ergonomic Mouse", brand: "ClickKey", price: 49.99, image: mouseImg, inStock: true }
];