import { ChangeEvent, useState } from "react";
import BookingMap from "../components/booking";
import type React from "react";
import { BookingPlaceProps, Hall, Seat } from "../types/booking";
import { QRCodeSVG } from 'qrcode.react';
import { useAuth } from "../context/AuthContext";

interface BookingFormData {
  name: string;
  email: string;
  date: string;
  startTime: string;
  payment_method: string;
  countHour: number;
}

const BookingPage: React.FC = () => {
  const { user } = useAuth();
  const getTodayDate = () => {
    const today = new Date();
    return today.toISOString().split("T")[0];
  };

  const date = new Date();

  const [formData, setFormData] = useState<BookingFormData>({
    name: user?.username ?? "",
    email: user?.email ?? "",
    date: date.getDate().toString(),
    startTime: getTodayDate(),
    payment_method: "credit-card",
    countHour: 1,
  });

  const [errorVisible, setErrorVisible] = useState(false);

  const [bookingInfo, setBookingInfo] = useState({
    selectedPlace: false,
    priceInHall: 0,
    hallName: "",
    numSeat: 0,
  });
  const [isFormVisible, setIsFormVisible] = useState(false);
  const [paymentDetails, setPaymentDetails] = useState({
    cardNumber: '',
    expiryDate: '',
    cvv: '',
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLSelectElement | HTMLInputElement>) => {
    const { name, value } = e.target;

    if (name === 'payment_method') {
      setFormData(prev => ({
        ...prev,
        payment_method: value as 'cash' | 'credit-card' | 'qr-code',
      }));
    } else if (name.startsWith('card_')) {
      setPaymentDetails(prev => ({
        ...prev,
        [name.replace('card_', '')]: value
      }));
    } else {
      setFormData((prev) => ({
        ...prev,
        [name]: value,
      }));
    }
  };
  // Отображение формы оплаты
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (!formData.payment_method) {
      alert('Выберите способ оплаты');
      return;
    }

    setIsFormVisible(true);
  };

  // Генерация QR-кода (пример данных: сумма + уникальный ID транзакции)
  const generateQRCode = () => {
    const transactionId = `TRX-${Math.random().toString(36).substr(2, 9)}`;
    return `PAY:${formData.countHour * bookingInfo.priceInHall}:${transactionId}`;
  };

  const onChangeCoutHour = (e: ChangeEvent<HTMLInputElement>) => {
    const newVal = Number(e.target.value);
    if (formData.countHour === 10 && newVal !== 9) {
      setErrorVisible(true);
      return;
    } else if (newVal === 9 && errorVisible) {
      setErrorVisible(false);
    }

    setFormData((prev) => ({
      ...prev,
      countHour: newVal,
    }));
  };

  const bookingPlacePropsStub: BookingPlaceProps = {
    halls: [
      {
        id: 1,
        name: "Главный Зал",
        floorPlanUrl: "/img/main-hall.svg",
        seats: [
          { id: 101, x: 2, y: 1, rotate: 0, isOccupied: false },
          { id: 102, x: 12, y: 1, rotate: 0, isOccupied: false },
          { id: 103, x: 22, y: 1, rotate: 0, isOccupied: false },
          { id: 104, x: 32, y: 1, rotate: 0, isOccupied: false },
          { id: 105, x: 4, y: 20, rotate: -90, isOccupied: false },
          { id: 106, x: 4, y: 30, rotate: -90, isOccupied: false },
          { id: 107, x: 2, y: 88, rotate: 180, isOccupied: true },
          { id: 108, x: 20, y: 88, rotate: 180, isOccupied: true },
        ],
        computer: {
          monitor: ['27" 144Hz', "2560x1440 QHD", "IPS"],
          mouse: "Razer DeathAdder V3 Pro",
          keyboard: "Corsair K100 RGB",
          ram: "Kingston FURY Beast Black 16 ГБ",
          processor: "AMD Ryzen 9 7950X",
          chair: "Gaming chair DXRacer Air",
          internet: "1 Gbps",
          disk: "2TB NVMe SSD",
          graphics_card: "NVIDIA RTX 4080",
        },
        price_per_hour: 150,
      },
      {
        id: 2,
        name: "VIP Зал",
        floorPlanUrl: "/img/main-hall.svg",
        seats: [
          { id: 101, x: 2, y: 1, rotate: 0, isOccupied: false },
          { id: 102, x: 12, y: 1, rotate: 0, isOccupied: false },
          { id: 103, x: 22, y: 1, rotate: 0, isOccupied: false },
          { id: 104, x: 32, y: 1, rotate: 0, isOccupied: false },
          { id: 105, x: 4, y: 20, rotate: -90, isOccupied: false },
          { id: 106, x: 4, y: 30, rotate: -90, isOccupied: false },
          { id: 107, x: 2, y: 88, rotate: 180, isOccupied: true },
          { id: 108, x: 20, y: 88, rotate: 180, isOccupied: true },
        ],
        computer: {
          monitor: ['32" 165Hz', "3840x2160 UHD", "HDR"],
          mouse: "Logitech MX Vertical",
          keyboard: "Ducky One 2 Mini",
          ram: "Kingston FURY Beast Black 32 ГБ",
          processor: "AMD Radeon RX 7900 XTX",
          chair: "Gaming chair Noblechairs Hero",
          internet: "1 Gbps",
          disk: "4TB NVMe SSD",
          graphics_card: "AMD RX 7900 XT",
        },
        price_per_hour: 300,
      },
    ],
    onSeatPress: (seat: Seat, hall: Hall) => {
      setBookingInfo(() => ({
        numSeat: seat.id,
        hallName: hall.name,
        priceInHall: hall.price_per_hour,
        selectedPlace: true,
      }));
    },
    street: "Main Street 123",
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
              <li>• Процессор AMD</li>
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

        {bookingInfo.selectedPlace ? (
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
                    htmlFor="countHours"
                    className="block text-sm font-medium text-gray-700 mb-1"
                  >
                    Сколько часов
                  </label>
                  <input
                    type="number"
                    id="countHours"
                    name="countHours"
                    value={formData.countHour}
                    onChange={onChangeCoutHour}
                    min="1"
                    className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                    required
                  />
                  <p className="text-red-500">
                    {errorVisible ? "Максимум 10 часов" : ""}
                  </p>
                </div>
              </div>

              <div>
                <label
                  htmlFor="paymentMethod"
                  className="block text-sm font-medium text-gray-700 mb-1"
                >
                  Способ оплаты
                </label>
                <select
                  id="paymentMethod"
                  name="payment_method"
                  value={formData.payment_method}
                  onChange={handleInputChange}
                  className="w-full px-3 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-amber-500 focus:border-transparent"
                  required
                >
                  <option value="credit-card">Картой</option>
                  <option value="qr-code">QR Код</option>
                </select>
              </div>

              <div className="grid md:grid-cols-3 gap-6">
                <div className="text-gray-800 w-fit whitespace-nowrap">
                  <span className="font-medium">Место:</span>{" "}
                  {bookingInfo.numSeat}
                </div>
                <div className="text-gray-600 w-fit whitespace-nowrap">
                  <span className="font-medium">Зал:</span>{" "}
                  {bookingInfo.hallName}
                </div>

                <div>
                  <div className="text-gray-800 text-right">
                    <span className="font-medium">Итоговая цена: </span>
                    {formData.countHour * bookingInfo.priceInHall} руб.
                  </div>
                </div>
              </div>
            </form>

            <div className="justify-end mt-10 text-right">
              <button
                type="submit"
                onClick={() => setIsFormVisible(true)}
                className="bg-amber-600 hover:bg-amber-700 text-white px-8 py-3 rounded-lg font-semibold transition-colors"
              >
                Подтвердить бронирование
              </button>
            </div>
            {isFormVisible && (
              <div className="mt-6 p-4 bg-gray-50 rounded-lg animate-fade-in">
                {formData.payment_method === 'credit-card' && (
                  <div className="space-y-4">
                    <h3 className="text-lg font-semibold mb-2">Введите данные карты</h3>

                    <div>
                      <label className="block text-sm text-gray-600 mb-1">Номер карты</label>
                      <input
                        type="text"
                        name="card_cardNumber"
                        value={paymentDetails.cardNumber}
                        onChange={handleInputChange}
                        placeholder="1234 5678 9012 3456"
                        className="w-full px-3 py-2 border border-gray-300 rounded-lg"
                        maxLength={19}
                        required
                      />
                    </div>

                    <div className="flex space-x-4">
                      <div className="flex-1">
                        <label className="block text-sm text-gray-600 mb-1">Срок действия</label>
                        <input
                          type="text"
                          name="card_expiryDate"
                          value={paymentDetails.expiryDate}
                          onChange={handleInputChange}
                          placeholder="MM/YY"
                          className="w-full px-3 py-2 border border-gray-300 rounded-lg"
                          maxLength={5}
                          required
                        />
                      </div>

                      <div className="flex-1">
                        <label className="block text-sm text-gray-600 mb-1">CVV</label>
                        <input
                          type="password"
                          name="card_cvv"
                          value={paymentDetails.cvv}
                          onChange={handleInputChange}
                          placeholder="123"
                          className="w-full px-3 py-2 border border-gray-300 rounded-lg"
                          maxLength={4}
                          required
                        />
                      </div>
                    </div>

                    <button
                      type="button"
                      onClick={() => {
                        console.log('Оплата картой:', paymentDetails);
                        alert('Оплата картой прошла успешно!');
                        setIsFormVisible(false);
                      }}
                      className="w-full bg-amber-600 text-white py-2 px-4 rounded-lg hover:bg-green-600 transition"
                    >
                      Подтвердить оплату картой
                    </button>
                  </div>
                )}

                {formData.payment_method === 'qr-code' && (
                  <div className="space-y-4 text-center">
                    <h3 className="text-lg font-semibold mb-2">Отсканируйте QR-код для оплаты</h3>

                    <div className="mx-auto w-48 h-48 bg-white border border-gray-300 rounded-lg">
                      <QRCodeSVG
                        value={generateQRCode()}
                        bgColor="#ffffff"
                        size={190}
                        fgColor="#000000"
                        level="L"
                      />
                    </div>

                    <p className="text-sm text-gray-500">
                      Или сохраните QR-код и оплатите через приложение банка
                    </p>
                  </div>
                )}

                {/* Кнопка отмены */}
                <button
                  type="button"
                  onClick={() => setIsFormVisible(false)}
                  className="mt-4 w-full text-amber-500 hover:text-amber-700 transition"
                >
                  Отмена
                </button>
              </div>
            )}
          </div>
        ) : (
          <></>
        )}
      </div>
    </main>
  );
};

export default BookingPage;
