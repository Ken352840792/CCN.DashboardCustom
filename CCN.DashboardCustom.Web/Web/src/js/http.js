import axios from 'axios'
import config from '../config'


const debounce = require('lodash/debounce');
const throttle = require('lodash/throttle');

let loadingCount = 0;

const _loading = {
    start() {
        const throttled = throttle(function () {
            if (config.isShowLoading)
            console.log('loading open');
        }, 1000);
        throttled();
        loadingCount++;
    },
    stop() {
        loadingCount--;
        const debounced = debounce(function () {
            if (loadingCount === 0) {
                config.isShowLoading = true;
                console.log('loading close');
            }
        }, 250);
        debounced();
    }
};

function createInstance(config = {timeout: 30000}) {
    const instance = axios.create(config);
    // 添加请求拦截器
    instance.interceptors.request.use(config => {
        _loading.start();
        return config;
    }, error => {
        _loading.stop();
        return Promise.reject(error);
    });

    // 添加响应拦截器
    instance.interceptors.response.use(response => {
        _loading.stop();
        return response;
    }, error => {
        _loading.stop();
        return Promise.reject(error);
    });

    return instance;
}

const http = createInstance();

http.create = function create(config = {}) {
    return createInstance(config);
};

export default http