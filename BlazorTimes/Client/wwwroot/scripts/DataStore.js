window.datastore = {
    storeItem: function (key, item) {
        var ok = true;
        try {
            window.localStorage.setItem(key, item);
        } catch (e) {
            ok = false;
        }
        return ok;
    },
    retrieveItem: function (key) {
        return window.localStorage.getItem(key);
    },
    removeItem: function (key) {
        window.localStorage.removeItem(key);
    },
    clearAll: function () {
        window.localStorage.clear();
    },
    getLength: function () {
        return window.localStorage.length;
    },
    getKey: function (index) {
        return window.localStorage.key(index);
    }
}