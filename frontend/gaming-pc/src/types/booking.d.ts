export interface Hall {
  id: number;
  name: string;
  seats: Seat[]
  floorPlanUrl: string;
  price_per_hour: number;
}

export interface Seat {
  id: number;
  x: number;
  y: number;
  isOccupied: boolean;
}

export interface BookingPlaceProps {
  halls: Hall[];
  onSeatPress: (seat: Seat) => void;
  street?: string;
}

export interface Computer {
    montior: string[];
    mouse: string;
    keyboard: string;
    cpu: string;
    processor: string;
    chair: string;
    internet: string;
    disk: string;
    graphics_card: string;
}