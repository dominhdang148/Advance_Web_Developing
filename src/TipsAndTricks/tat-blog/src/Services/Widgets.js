import { get_api } from "./Methods";
export function getCategories() {
    return get_api('https://localhost:7134/api/categories');
}

