import { ILoginForm } from "@/interfaces/ILoginForm";
import { request } from "./request";


export class ApiHub {
    /**
     * @description: 登录接口
     * @param {ILoginForm} userLoginForm
     * @return {*}
     */
    public static login(userLoginForm: ILoginForm): Promise<any> {
        return request('/connect/token', 'POST', userLoginForm, { "content-type": "application/x-www-form-urlencoded" });
    }
}
