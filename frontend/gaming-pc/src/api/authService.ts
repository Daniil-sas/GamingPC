import apiClient from './apiClient';
import { LoginRequest, RegisterRequest, AuthResponse } from '../types/api';
import { User } from '../types/auth';

export const AuthService = {
  login: async (data: LoginRequest): Promise<AuthResponse> => {
    const response = await apiClient.post('/auth/login', data);
    return response.data;
  },

  register: async (data: RegisterRequest): Promise<AuthResponse> => {
    const response = await apiClient.post('/api/auth/register', data);
    return response.data;
  },

  getProfile: async (): Promise<User> => {
    const response = await apiClient.get('/api/auth/profile');
    return response.data;
  },
};