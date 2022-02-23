import store from '@/store/index'

/**
 * @description: 获取LocalStorage存储的Token
 * @param {*}
 * @return {*}
 */
export function getStorageToken(): string {
    return uni.getStorageSync('FenziBill-Token');
};

/**
 * @description: 设置LocalStorage存储的Token
 * @param {string} key
 * @param {string} value
 * @return {*}
 */
export function setStorageToken(value: string): void {
    uni.setStorageSync('FenziBill-Token', value);
};


/**
 * @description: 检验是否登录
 * @param {*}
 * @return {*}
 */
export function checkLogin(): void {
    //如果存在用户信息,说明已经登录
    if (!store.getters['user/GET_USERID']) {
        //如果不存在用户信息，说明未登录，但可能存在Token，尝试用Token获取一遍用户信息
        store.dispatch('user/getUserInfo').catch(() => {
            uni.reLaunch({
                url: '/pages/login/index',
            });
        });
    }
};