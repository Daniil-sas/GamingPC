import { FC } from "react";
import { Seat, Hall } from "../types/booking";
import ComputerIcon from "../assets/icons/ComputerIcon";
import CircleIcon from "../assets/icons/CircleIcon";

interface WorkPlaceProbs {
    seat: Seat,
    hall: Hall,
    clickOnComputer: () => void,
    clickOnSeat: (seat: Seat, hall: Hall) => void,
}

const WorkPlace: FC<WorkPlaceProbs> = ({ seat, hall, clickOnComputer, clickOnSeat }) => {
    return (
        <div className="flex flex-col items-center justify-center">
            <div className="w-full flex justify-center mb-0.5">
                <ComputerIcon width={30} height={30} onComputerClick={clickOnComputer} />
            </div>

            <div className="w-full flex justify-center">
                <button onClick={() => clickOnSeat(seat, hall)}>
                    <CircleIcon
                        width={30}
                        height={30}
                        color={seat.isOccupied ? "red" : "green"}
                    />
                </button>
            </div>
        </div>
    )
}

export default WorkPlace;