import httpInstance from "../../js/http";
class Generator {
    constructor(apiAlias, baseURL) {
        this._apiAlias = apiAlias;
        this._baseURL = baseURL;
        this._http = httpInstance;
        return this._mapApi();
    }
    _setMethodWithUri(options) {
        options.method = options.method || 'get';
        if (options.config) {
            this._http = httpInstance.create(options.config);
        }
        return async (params = {}) => {
            console.group(options.url + '请求参数');
            console.log(params);
            console.groupEnd(options.url + '请求参数');
            const requestParams = params;
            const response = await this._toHttp(options.method, options.url, requestParams);
            if (response.data instanceof Object ) {
                console.group(options.url + '响应');
                console.log(response.data);
                console.groupEnd(options.url + '响应');
                return response.data;
            }
        };
    }

    _toHttp(method, url, params) {
        if (!url) {
            return
        }
        if (method === 'get') {
            params = {
                params: params
            }
        }
        return this._http[method](`${this._baseURL}${url}`, params);
    }

    _mapApi() {
        let facade = {};
        Object.keys(this._apiAlias).forEach((key) => {
            const api = this._apiAlias[key];
            if (api instanceof Function) {
                facade[key] = api;
            } else {
                facade[key] = this._setMethodWithUri(api);
                facade[key].options = api;
            }
        });
        return facade;
    }
}

export default Generator