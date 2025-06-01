import { FC, SVGProps } from "react";

interface CircleProps extends SVGProps<SVGSVGElement> {
  width?: number;
  height?: number;
  color?: string;
}

const CircleIcon: FC<CircleProps> = ({ width, height, color }) => (
  <svg viewBox="-10 0 120 120" width={width} height={height} version="1.1" xmlns="http://www.w3.org/2000/svg">
    <circle className={`${color === "red" ? "cursor-not-allowed" : "hover:fill-sky-700"}`} fill={color} cx="50" cy="50" r="50" />
  </svg>
);

export default CircleIcon;
