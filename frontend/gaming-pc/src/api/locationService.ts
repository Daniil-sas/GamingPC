import apiClient from './apiClient';
import { Location, Hall, Workplace } from '../types/api';

export const LocationService = {
  getLocations: async (): Promise<Location[]> => {
    const response = await apiClient.get('/api/booking/locations');
    return response.data;
  },

  getHalls: async (locationId: string): Promise<Hall[]> => {
    const response = await apiClient.get(`/api/booking/locations/${locationId}/halls`);
    return response.data;
  },

  getWorkplaces: async (hallId: string): Promise<Workplace[]> => {
    const response = await apiClient.get(`/api/booking/halls/${hallId}/workplaces`);
    return response.data;
  },
};