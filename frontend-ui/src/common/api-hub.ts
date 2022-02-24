import { ILoginForm } from "@/interfaces/ILoginForm";
import { request } from "./request";



/**
 * @description 所有的接口请求集线
 */
export class ApiHub {

    /**
     * @description: 登录接口
     * @param {ILoginForm} userLoginForm
     * @return {*}
     */
    public static login(userLoginForm: ILoginForm): Promise<any> {
        return request('/connect/token', 'POST', userLoginForm, { "content-type": "application/x-www-form-urlencoded" });
    };

    /**
     * @description: 获取用户信息
     * @param {*}
     * @return {*}
     */
    public static getUserInfo(): Promise<any> {
        return request('/connect/userinfo', 'GET');
    }

    /**
     * @description: 创建关系
     * @param {any} relation
     * @return {*}
     */
    public static createRelation(name: string): Promise<any> {
        return request('/api/app/relation/relation', 'POST', { name: name });
    };

    /**
     * @description: 获取关系
     * @param {number} skipCount
     * @param {number} maxResultCount
     * @return {*}
     */
    public static getAllRelation(skipCount?: number, maxResultCount?: number): Promise<any> {
        return request(`/api/app/relation/relation?SkipCount=${skipCount ?? 0}&MaxResultCount=${maxResultCount ?? 100}`, 'GET');
    }

    /**
     * @description: 删除关系
     * @param {number} id
     * @return {*}
     */
    public static deleteRelation(id: string): Promise<any> {
        return request(`/api/app/relation/${id}/relation`, 'DELETE');
    }


    /**
     * @description: 删除关系
     * @param {number} id
     * @param {string} newName
     * @return {*}
     */
    public static changeRelationName(id: string, newName: string): Promise<any> {
        return request(`/api/app/relation/${id}/change-relation-name?newName=${newName}`, 'POST');
    }
}

