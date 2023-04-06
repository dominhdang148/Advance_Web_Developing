import React from 'react'
import SearchForm from './SearchForm';
import CategoriesWidget from './CategoryWidget';

const SideBar = () => {
    return (
        <div className='pt-4 ps-2'>
            <SearchForm />

            <CategoriesWidget />
            <h1>
                Bài viết nổi bật
            </h1>
            <h1>
                Đăng ký nhận tin mới
            </h1>
            <h1>
                Tag Cloud
            </h1>
        </div>
    )
}

export default SideBar;