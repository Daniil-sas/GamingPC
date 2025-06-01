import { FC, useState } from "react";
import { BookingPlaceProps } from "../types/booking";
import { Hall } from "../types/booking";
import WorkPlace from "./work-place";

const BookingMap: FC<BookingPlaceProps> = ({ halls, onSeatPress, street }) => {
  const [date, setDate] = useState<string>("");
  const [selectedHall, setSelectedHall] = useState<Hall | null>(
    halls[0] || null
  );

  return (
    <div className="max-w-4xl mx-auto p-4 bg-white border my-6">
      <div className="mb-6 text-center">
        <h1 className="text-2xl font-bold text-gray-800">
          {street ? `Бронирование мест - ${street}` : "Бронирование мест"}
        </h1>
      </div>

      <div className="flex flex-col md:flex-row gap-4 mb-6 p-4 bg-gray-50 rounded-lg">
        <div className="flex-1">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Выберите дату
          </label>
          <input
            type="date"
            value={date}
            onChange={(e) => setDate(e.target.value)}
            className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent"
          />
        </div>

        <div className="flex-1">
          <label className="block text-sm font-medium text-gray-700 mb-1">
            Выберите зал
          </label>
          <select
            value={selectedHall?.id || ""}
            onChange={(e) => {
              const hall = halls.find((h) => h.id === parseInt(e.target.value));
              if (hall) setSelectedHall(hall);
            }}
            className="w-full p-2 border border-gray-300 rounded-md focus:ring-2 focus:ring-blue-500 focus:border-transparent"
          >
            {halls.map((hall) => (
              <option key={hall.id} value={hall.id}>
                {hall.name}
              </option>
            ))}
          </select>
          <p>Цена в час: {selectedHall?.price_per_hour} руб.</p>
        </div>
      </div>

      <div className="flex justify-center gap-6 mb-6">
        <div className="flex items-center">
          <div className="w-4 h-4 rounded-full bg-green-500 mr-2"></div>
          <span className="text-sm text-gray-600">Свободно</span>
        </div>
        <div className="flex items-center">
          <div className="w-4 h-4 rounded-full bg-red-500 mr-2"></div>
          <span className="text-sm text-gray-600">Занято</span>
        </div>
        <div className="flex items-center">
          <div className="w-4 h-4 rounded-full bg-blue-500 mr-2"></div>
          <span className="text-sm text-gray-600">Выбрано</span>
        </div>
      </div>

      {selectedHall ? (
        <div className="flex gap-6 max-h-[59vh]">
          <div className="relative bg-gray-100 rounded-lg overflow-hidden border border-gray-200 flex-1">
            <div className="relative h-full">
              <object
                type="image/svg+xml"
                data={selectedHall.floorPlanUrl}
                aria-label="Карта помещения"
              ></object>

              {selectedHall.seats.map((seat) => (
                <div
                  key={seat.id}
                  className="absolute"
                  style={{
                    left: `${seat.x}%`,
                    top: `${seat.y}%`,
                    rotate: `${seat.rotate}deg`,
                  }}
                >
                  <WorkPlace
                    seat={seat}
                    hall={selectedHall}
                    clickOnComputer={() => console.log(seat)}
                    clickOnSeat={onSeatPress}
                  />
                </div>
              ))}
            </div>
          </div>
          <div className="w-1/3 bg-white rounded-lg overflow-y-auto">
            <h3 className="text-lg font-semibold mb-4">Компьютеры в зале</h3>

            <div className="space-y-4">
              <div className="text-sm text-gray-600 mt-1">
                <p>Монитор: {selectedHall.computer.monitor.join(", ")}</p>
                <p>ОЗУ: {selectedHall.computer.ram}</p>
                <p>Видеокарта: {selectedHall.computer.graphics_card}</p>
                <p>Процессор: {selectedHall.computer.processor}</p>
                <p>Интернет: {selectedHall.computer.internet}</p>
                <p>Кресло: {selectedHall.computer.chair}</p>
                <p>Память: {selectedHall.computer.disk}</p>
                <p>Клавиатура: {selectedHall.computer.keyboard}</p>
                <p>Мышь: {selectedHall.computer.mouse}</p>
              </div>
            </div>
          </div>
        </div>
      ) : (
        <div className="text-center py-10 bg-gray-50 rounded-lg">
          <p className="text-gray-500">Залы не найдены</p>
        </div>
      )}

      <div className="mt-4 text-center text-sm text-gray-500">
        <p>
          Выберите дату и зал, затем кликните на свободное место для
          бронирования
        </p>
      </div>
    </div>
  );
};

export default BookingMap;
