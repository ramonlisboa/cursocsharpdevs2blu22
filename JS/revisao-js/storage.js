const getItem = (key) => {
    return localStorage.getItem(key);
}

const setItem = (key, value) => {
    localStorage.setItem(key, value);
}

const getJsonItem = (key) => {
    var obj = getItem(key);
    return JSON.parse(obj);
}

const setJsonItem = (key, value) => {
    var obj = JSON.stringify(value);
    setItem(key, obj);
}

const removeItem = (key) => {
    localStorage.removeItem(key);
}