import { Link } from "react-router-dom";

const NotFound = () => {
    return (
        <>
            <div className="d-flex flex-column justify-content-center min-vh-100 align-items-center">
                <h1 className="text-dark display-1 fw-bold ">404</h1>
                <h4 className="text-dark "><span className="text-danger">Chà!</span> Không tìm thấy trang rồi!</h4>
                <p className="text-dark">Trang mà bạn đang tìm không tồn tại</p>
                <Link to='/' className="btn btn-outline-primary">Về trang chủ thôi</Link>
            </div >
        </>
    );
}

export default NotFound;