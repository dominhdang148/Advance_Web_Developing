import React, { useEffect } from "react";


const Rss = () => {
    useEffect(() => {
        document.title = "Rss"          
    },[])

    return (
        <h1>
            Đây là trang Rss
        </h1>
    );
};


export default Rss;