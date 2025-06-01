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
          { id: 101, x: 2, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 12, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 22, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 32, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 3, y: 20, rotate: -1.57, isOccupied: false },
          { id: 103, x: 3, y: 25, rotate: -1.57, isOccupied: false },
          { id: 102, x: 2, y: 92, rotate: 3.14, isOccupied: true },
        ],
        price_per_hour: 500,
      },
      {
        id: 2,
        name: "VIP Зал",
        floorPlanUrl: "/img/main-hall.svg",
        seats: [
          { id: 101, x: 2, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 12, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 22, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 32, y: 1, rotate: 0, isOccupied: false },
          { id: 101, x: 3, y: 20, rotate: -1.57, isOccupied: false },
          { id: 103, x: 3, y: 25, rotate: -1.57, isOccupied: false },
          { id: 102, x: 2, y: 92, rotate: 3.14, isOccupied: true },
        ],
        price_per_hour: 800,
      },
    ],
    onSeatPress: (seat: Seat) => {
      console.log("Seat pressed:", seat.id);
    },
    street: "Main Street 123",
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
        <h1 className="text-4xl font-bold text-gray-900 mb-2">Бронь места</h1>
        <p className="text-lg text-gray-600 mb-8">
          Никогда ещё pay-to-win не было настолько уместно, как при оплате места
          за нашим компьютером.
        </p>

        <div className="grid md:grid-cols-3 gap-8 mb-12">
          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🖥️</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">Компьютеры</h3>
            <p className="text-gray-600 mb-4">Современное железо</p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• ОЗУ от 16 ГБ</li>
              <li>• Видюха начиная с 4060</li>
              <li>• Процессер AMD</li>
            </ul>
          </div>

          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🏢</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">Залы</h3>
            <p className="text-gray-600 mb-4">
              Комфортные помещения, чтобы ни что не мешало проявлятся вашим
              скилам!
            </p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• Кондиционер</li>
              <li>• Проффесиональное игровое кресло</li>
              <li>• Уютная обстановка</li>
            </ul>
          </div>

          <div className="bg-gray-50 p-6 rounded-lg border border-gray-200">
            <div className="w-12 h-12 bg-amber-600 rounded-lg flex items-center justify-center mb-4">
              <span className="text-white text-xl">🎮</span>
            </div>
            <h3 className="text-xl font-semibold mb-2">Игры</h3>
            <p className="text-gray-600 mb-4">Игры на любой вкус и цвет.</p>
            <ul className="text-sm text-gray-500 space-y-1">
              <li>• Steam</li>
              <li>• Epic Games</li>
              <li>• И даже торрент</li>
            </ul>
          </div>
        </div>

        <BookingMap {...bookingPlacePropsStub} />

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
            <h2 className="text-2xl font-semibold mb-6">Бронирование</h2>
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
                    Со скольки
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
                    Сколько часов
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
                  <p className="text-red-500">Максимум 10 часов</p>
                </div>
              </div>

              <div>
                <label
                  htmlFor="resourceType"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Способ оплаты
                </label>
                <select
                  id="resourceType"
                  name="resourceType"
                  value={formData.resourceType}
                  onChange={handleInputChange}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                  required
                >
                  <option value="cash">Наличными</option>
                  <option value="credit-card">Картой</option>
                  <option value="qr-code">QR Код</option>
                </select>
              </div>

              <div className="grid md:grid-cols-3 gap-6">
                <div className="text-gray-800 w-fit whitespace-nowrap">
                  <span className="font-medium">Место:</span> {10}
                </div>
                <div className="text-gray-600 w-fit whitespace-nowrap">
                  <span className="font-medium">Зал:</span> {"10"}
                </div>

                <div>
                  <div className="text-gray-800 text-right">
                    <span className="font-medium">Итоговая цена: </span>
                    {(2222.24).toFixed(2)} руб.
                  </div>
                </div>
              </div>
            </form>

            <div className="justify-end mt-10 text-right">
              <button
                type="submit"
                className="bg-amber-600 hover:bg-amber-700 text-white px-8 py-3 rounded-lg font-semibold transition-colors"
              >
                Подтвердить бронирование
              </button>
            </div>
          </div>
        )}
      </div>
    </main>
  );
};

export default BookingPage;
