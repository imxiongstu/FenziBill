/**
 * @description: Outh2.0 用户账号密码登录表单接口
 * @param {*}
 * @return {*}
 */
export interface ILoginForm {
    username: string,
    password: string,
    grant_type: "password",
    client_id: string
}