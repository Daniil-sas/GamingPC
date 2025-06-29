import { User } from "./auth";

export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterRequest {
  name: string;
  login: string;
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  user: User;
}

export interface Location {
  id: string;
  address: {
    city: string;
    street: string;
    building: string;
  };
}

export interface Hall {
  id: string;
  name: string;
  layoutUrl: string;
  pricePerHour: number;
  computerConfiguration: {
    cpu: string;
    gpu: string;
    ram: number;
    storage: string;
  };
}

export interface Workplace {
  id: string;
  hallId: string;
  number: number;
  position: {
    x: number;
    y: number;
    rotation: number;
  };
}

export interface QRCodeResponse {
  qrCodeUrl: string;
  paymentId: string;
}

export interface CardPaymentRequest {
  cardNumber: string;
  cardHolder: string;
  expiryDate: string;
  cvv: string;
  amount: number;
  bookingId: string;
}