import { FC } from "react";
import { Computer, Seat } from "../types/booking";
import ComputerIcon from "../assets/icons/ComputerIcon";
import CircleIcon from "../assets/icons/CircleIcon";

interface WorkPlaceProbs {
    seat: Seat,
    clickOnComputer: () => void,
    clickOnSeat: () => void,
}

const WorkPlace: FC<WorkPlaceProbs> = ({ seat, clickOnComputer, clickOnSeat }) => {
    return (
        <div className="flex flex-col items-center justify-center">
            <div className="w-full flex justify-center mb-0.5">
                <ComputerIcon width={30} height={30} onComputerClick={clickOnComputer} />
            </div>

            <div className="w-full flex justify-center">
                <CircleIcon
                    width={30}
                    height={30}
                    color={seat.isOccupied ? "red" : "green"}
                    onSeatClick={clickOnSeat}
                />
            </div>
        </div>
    )
}

export default WorkPlace;