export function request(url: string, method: UniApp.RequestOptions["method"], data: any, header: UniApp.RequestOptions["header"]) {
    return uni.request({
        url: url,
        method: method,
        data: data,
        header: header
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