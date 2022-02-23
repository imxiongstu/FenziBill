import store from "@/store";
import { getStorageToken } from "./auth";

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
            url: url,
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
            args.header = args.header ?? {};
            args.url = BaseUrl + args.url;

            //如果存在Token，则使用Token进行请求
            if (store.getters['user/GET_TOKEN']) {
                args.header['Authorization'] = `Bearer ${getStorageToken()}`;
            }
        },
        success(args) {

        },
        fail(err) {

        },
        complete(res) {

        }
    })
}