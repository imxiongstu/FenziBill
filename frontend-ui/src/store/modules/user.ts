import { ILoginForm } from "@/interfaces/ILoginForm";
import { ApiHub } from '@/common/api-hub';

const state = {
    token: ''
}

const mutations = {
    //设置Token
    SET_TOKEN: (state: any, token: string) => {
        state.token = token;
    }
};

const getters = {
    //获取Token
    GET_TOKEN: (state: any) => {
        return state.token;
    }
}

const actions = {
    //登录
    login({ commit }: any, userLoginForm: ILoginForm) {
        return new Promise((resolve, reject) => {
            ApiHub.login(userLoginForm).then((res: any) => {
                let token = res.access_token;
                //设置Token至Vuex状态
                commit('SET_TOKEN', token);
                //设置Token至LocalStorage
                uni.setStorage({ key: "FenziBill-Token", data: token })
                resolve(res);
            }).catch((err: any) => {
                reject(err);
            });
        });
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    getters,
    actions
}