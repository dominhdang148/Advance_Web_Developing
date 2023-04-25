import { Link } from "react-router-dom";
import { useQuery } from "../Utils/Utils";

const BadRequest = () => {
    let query = useQuery(),
        redirectTo = query.get('redirectTo') ?? '/';

    return (
        <>
            <div className="d-flex flex-column justify-content-center min-vh-100 align-items-center">
                <h1 className="text-dark display-1 fw-bold ">400</h1>
                <h4 className="text-dark "><span className="text-danger">Chà!</span> Yêu cầu không hợp lệ!</h4>
                <p className="text-dark">Có vẻ tham số trong URL của bạn chưa đúng yêu cầu</p>
                <Link to='/' className="btn btn-outline-primary">Về trang chủ thôi</Link>
            </div >
        </>
    )
}

export default BadRequest;