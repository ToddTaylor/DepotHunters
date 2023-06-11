import { Link, Outlet } from "react-router-dom";
import TopNavbar from "../Navbar";

export default function Root() {
    return (
        <>
            <TopNavbar />
            <div id="detail">
                <Outlet />
            </div>
        </>
    );
}