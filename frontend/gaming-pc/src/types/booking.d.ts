export interface Hall {
  id: number;
  name: string;
  seats: Seat[];
  computer: Computer,
  floorPlanUrl: string;
  price_per_hour: number;
}

export interface Seat {
  id: number;
  x: number;
  y: number;
  rotate: number;
  isOccupied: boolean;
}

export interface BookingPlaceProps {
  halls: Hall[];
  onSeatPress: (seat: Seat, hall: Hall) => void;
  street?: string;
}

export interface Computer {
  monitor: string[];
  mouse: string;
  keyboard: string;
  ram: string;
  processor: string;
  chair: string;
  internet: string;
  disk: string;
  graphics_card: string;
}
