const BaseUrl = import.meta.env.VITE_API_BASEURL;

/**
 * @description: Http请求
 * @param {*}
 * @return {*}
 */
export function request(
    url: string, method: UniApp.RequestOptions["method"],
    data?: any, header?: UniApp.RequestOptions["header"]): Promise<any> {
    return new Promise((resolve, reject) => {
        uni.request({
            url: BaseUrl + url,
            method: method,
            data: data,
            header: header,
            success: (res) => {
                if (res.statusCode === 200) {
                    resolve(res.data);
                } else {
                    reject(res);
                }
            },
            fail: (err) => {
                reject(err);
            }
        });
    });
}


/**
 * @description: Http请求拦截器
 * @param {*}
 * @return {*}
 */
export function useRequestInterceptor(): void {
    uni.addInterceptor('request', {
        invoke(args) {
            console.log(args);
        },
        success(args) {

        },
        fail(err) {

        },
        complete(res) {

        }
    })
}