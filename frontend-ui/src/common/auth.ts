
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
export function setStorageToken(key: string, value: string): void {
    uni.setStorageSync(key, value);
};