import apiClient from './apiClient';
import { QRCodeResponse, CardPaymentRequest } from '../types/api';

export const PaymentService = {
  generateQRCode: async (bookingId: string): Promise<QRCodeResponse> => {
    const response = await apiClient.get(`/api/payment/qr?bookingId=${bookingId}`);
    return response.data;
  },

  payByCard: async (data: CardPaymentRequest): Promise<void> => {
    await apiClient.post('/api/payment/card', data);
  },
};