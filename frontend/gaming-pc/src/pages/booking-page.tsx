import { useState } from "react";
import BookingMap from "../components/booking";
import type React from "react";
import { BookingPlaceProps, Seat } from "../types/booking";

interface BookingFormData {
  name: string;
  email: string;
  date: string;
  startTime: string;
  endTime: string;
  resourceType: string;
  attendees: string;
  purpose: string;
}

const BookingPage: React.FC = () => {
  const [formData, setFormData] = useState<BookingFormData>({
    name: "",
    email: "",
    date: "",
    startTime: "",
    endTime: "",
    resourceType: "meeting-room",
    attendees: "",
    purpose: "",
  });

  const [isSubmitted, setIsSubmitted] = useState(false);

  const handleInputChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
    >
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    // Here you would typically send the data to your backend
    console.log("Booking submitted:", formData);
    setIsSubmitted(true);
  };

  const bookingPlacePropsStub: BookingPlaceProps = {
  halls: [
    {
      id: 1,
      name: "Главный Зал",
      floorPlanUrl: "/img/main-hall.svg",
      seats: [
        { id: 101, x: 5, y: 1, isOccupied: false},
        { id: 102, x: 20, y: 1, isOccupied: true },
        { id: 103, x: 35, y: 1, isOccupied: false },
      ],
      price_per_hour: 500
    },
    {
      id: 2,
      name: "VIP Зал",
      floorPlanUrl: "/img/main-hall.svg",
      seats: [
        { id: 201, x: 100, y: 50, isOccupied: false },
        { id: 202, x: 120, y: 50, isOccupied: false },
      ],
      price_per_hour: 800
    }
  ],
  onSeatPress: (seat: Seat) => {
    console.log("Seat pressed:", seat.id);
  },
  street: "Main Street 123"
};

  const resetForm = () => {
    setFormData({
      name: "",
      email: "",
      date: "",
      startTime: "",
      endTime: "",
      resourceType: "meeting-room",
      attendees: "",
      purpose: "",
    });
    setIsSubmitted(false);
  };

  return (
    <main className="flex-1 container mx-auto px-4 py-12">
      <div className="max-w-4xl mx-auto">
        <h1 className="text-4xl font-bold text-gray-900 mb-2">
          Resource Booking
        </h1>
        <p className="text-lg text-gray-600 mb-8">
          Book our facilities for your tech projects, meetings, or study
          sessions.
        </p>

        <div className="grid md:grid-cols-3 gap-8 mb-12">
          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🖥️</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">Computer Lab</h3>
            <p className="text-gray-600 mb-4">
              Access to high-performance computers with specialized software.
            </p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• 20 workstations</li>
              <li>• Development tools</li>
              <li>• High-speed internet</li>
            </ul>
          </div>

          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🏢</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">Meeting Rooms</h3>
            <p className="text-gray-600 mb-4">
              Collaborative spaces for team meetings and discussions.
            </p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• Projector & whiteboard</li>
              <li>• 10-15 person capacity</li>
              <li>• Video conferencing</li>
            </ul>
          </div>

          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🎮</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">VR/AR Studio</h3>
            <p className="text-gray-600 mb-4">
              Experiment with virtual and augmented reality technologies.
            </p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• VR headsets</li>
              <li>• Motion capture</li>
              <li>• Development kits</li>
            </ul>
          </div>
        </div>

        <BookingMap { ...bookingPlacePropsStub }/>

        {isSubmitted ? (
          <div className="bg-green-50 border border-green-200 rounded-lg p-8 text-center">
            <div className="w-16 h-16 bg-green-100 rounded-full mx-auto mb-4 flex items-center justify-center">
              <svg
                className="w-8 h-8 text-green-600"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M5 13l4 4L19 7"
                />
              </svg>
            </div>
            <h3 className="text-2xl font-semibold text-gray-900 mb-2">
              Забронировать стол
            </h3>
            <button
              onClick={resetForm}
              className="bg-amber-600 hover:bg-amber-700 text-white px-6 py-2 rounded-lg font-semibold transition-colors"
            >
              Make Another Booking
            </button>
          </div>
        ) : (
          <div className="bg-white rounded-lg border border-gray-200 p-8">
            <h2 className="text-2xl font-semibold mb-6">Booking Form</h2>
            <form onSubmit={handleSubmit} className="space-y-6">
              <div className="grid md:grid-cols-2 gap-6">
                <div>
                  <label
                    htmlFor="name"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    Имя
                  </label>
                  <input
                    type="text"
                    id="name"
                    name="name"
                    value={formData.name}
                    onChange={handleInputChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                </div>

                <div>
                  <label
                    htmlFor="email"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    Почта
                  </label>
                  <input
                    type="email"
                    id="email"
                    name="email"
                    value={formData.email}
                    onChange={handleInputChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                </div>
              </div>

              <div className="grid md:grid-cols-3 gap-6">
                <div>
                  <label
                    htmlFor="date"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    Дата
                  </label>
                  <input
                    type="date"
                    id="date"
                    name="date"
                    value={formData.date}
                    onChange={handleInputChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                </div>

                <div>
                  <label
                    htmlFor="startTime"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    Start Time
                  </label>
                  <input
                    type="time"
                    id="startTime"
                    name="startTime"
                    value={formData.startTime}
                    onChange={handleInputChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                </div>

                <div>
                  <label
                    htmlFor="endTime"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    End Time
                  </label>
                  <input
                    type="time"
                    id="endTime"
                    name="endTime"
                    value={formData.endTime}
                    onChange={handleInputChange}
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                </div>
              </div>

              <div>
                <label
                  htmlFor="resourceType"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Resource Type
                </label>
                <select
                  id="resourceType"
                  name="resourceType"
                  value={formData.resourceType}
                  onChange={handleInputChange}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                  required
                >
                  <option value="computer-lab">Computer Lab</option>
                  <option value="meeting-room">Meeting Room</option>
                  <option value="vr-studio">VR/AR Studio</option>
                </select>
              </div>

              <div>
                <label
                  htmlFor="attendees"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Number of Attendees
                </label>
                <input
                  type="number"
                  id="attendees"
                  name="attendees"
                  value={formData.attendees}
                  onChange={handleInputChange}
                  min="1"
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                  required
                />
              </div>

              <div>
                <label
                  htmlFor="purpose"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Purpose of Booking
                </label>
                <textarea
                  id="purpose"
                  name="purpose"
                  value={formData.purpose}
                  onChange={handleInputChange}
                  rows={4}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                  required
                ></textarea>
              </div>

              <div className="flex justify-end">
                <button
                  type="submit"
                  className="bg-amber-600 hover:bg-amber-700 text-white px-8 py-3 rounded-lg font-semibold transition-colors"
                >
                  Submit Booking
                </button>
              </div>
            </form>
          </div>
        )}
      </div>
    </main>
  );
};

export default BookingPage;
