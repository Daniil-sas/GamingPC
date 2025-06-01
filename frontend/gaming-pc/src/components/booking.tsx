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
            <p>Я вас ебал идите нахуй</p>
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
        <div className="relative bg-gray-100 rounded-lg overflow-hidden border border-gray-200">
          <div className="relative overflow-auto max-h-[95vh]">
            <object
              type="image/svg+xml"
              data={selectedHall.floorPlanUrl}
              className="w-full h-full"
              aria-label="Карта помещения"
            ></object>

            {selectedHall.seats.map((seat) => (
              // <button
              //   key={seat.id}
              //   className={`absolute transform -translate-x-1/2 -translate-y-1/2 w-8 h-8 rounded-full flex items-center justify-center
              //     ${seat.isOccupied
              //       ? 'bg-red-500 cursor-not-allowed'
              //       : 'bg-green-500 hover:bg-green-600 cursor-pointer'
              //     }`}
              //   style={{ left: `${seat.x}%`, top: `${seat.y}%` }}
              //   onClick={() => !seat.isOccupied && onSeatPress(seat)}
              //   disabled={seat.isOccupied}
              //   aria-label={`Место ${seat.id} - ${seat.isOccupied ? 'занято' : 'свободно'}`}
              // >
              //   <CircleIcon color="red" width={100} height={100}/>
              //   <span className="text-xs text-white font-bold">{seat.id}</span>
              // </button>
              <div
                key={seat.id}
                className={`absolute rotate-[${seat.rotate}rad]`}
                style={{
                  left: `${seat.x}%`,
                  top: `${seat.y}%`,
                }}
              >
                <WorkPlace
                  seat={seat}
                  clickOnComputer={() => {}}
                  clickOnSeat={() => {}}
                />
              </div>
            ))}
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
