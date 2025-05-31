import { FC, SVGProps } from "react";

interface ComputerProps extends SVGProps<SVGSVGElement> {
  width?: number;
  height?: number;
  color?: string;
  onComputerClick: () => void;
}

const ComputerIcon: FC<ComputerProps> = ({ width, height, color, onComputerClick }) => (
  <button onClick={onComputerClick}>
    <svg id="svg2" viewBox="0 0 60 62" width={width} height={height} className="hover:fill-orange-700" xmlns="http://www.w3.org/2000/svg">
      <g id="PC" transform="matrix(1, 0, 0, 1, -2, -1)">
        <path d="M57,5H7A1,1,0,0,0,6,6V34a1,1,0,0,0,1,1H57a1,1,0,0,0,1-1V6A1,1,0,0,0,57,5ZM56,33H8V7H56Z" fill="fill:#1b1a1e" />
        <path d="M57,1H7A5.0059,5.0059,0,0,0,2,6V42a5.0059,5.0059,0,0,0,5,5H24v4H14a1,1,0,0,0-.8945.5527l-5,10A1,1,0,0,0,9,63H55a1,1,0,0,0,.8945-1.4473l-5-10A1,1,0,0,0,50,51H40V47H57a5.0059,5.0059,0,0,0,5-5V6A5.0059,5.0059,0,0,0,57,1ZM4,6A3.0033,3.0033,0,0,1,7,3H57a3.0033,3.0033,0,0,1,3,3V37H4ZM38,52a6.0066,6.0066,0,0,0,6,6,1,1,0,0,0,0-2,3.9958,3.9958,0,0,1-3.858-3h9.24l4,8H10.6182l4-8h9.24A3.9958,3.9958,0,0,1,20,56a1,1,0,0,0,0,2,6.0066,6.0066,0,0,0,6-6V47H38ZM60,42a3.0033,3.0033,0,0,1-3,3H7a3.0033,3.0033,0,0,1-3-3V39H60Z" fill="fill:#1b1a1e" />
        <path d="M7,43h6a1,1,0,0,0,0-2H7a1,1,0,0,0,0,2Z" fill="fill:#1b1a1e" />
        <path d="M16,43h2a1,1,0,0,0,0-2H16a1,1,0,0,0,0,2Z" fill="fill:#1b1a1e" />
      </g>
    </svg>
  </button>
);

export default ComputerIcon;