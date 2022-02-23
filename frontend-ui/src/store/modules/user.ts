import { ILoginForm } from "@/interfaces/ILoginForm";
import { ApiHub } from '@/common/api-hub';
import { getStorageToken, setStorageToken } from "@/common/auth";

const state = {
    token: getStorageToken(),//初始化的时候读取Storeage里的Token
    userName: '',
    userRole: '',
    userId: ''
}

const mutations = {
    //设置Token
    SET_TOKEN: (state: any, token: string) => {
        state.token = token;
    },
    //设置用户名
    SET_USERNAME: (state: any, userName: string) => {
        state.userName = userName;
    },
    //设置用户角色
    SET_USERROLE: (state: any, userRole: string) => {
        state.userRole = userRole;
    },
    //设置用户ID
    SET_USERID: (state: any, userId: string) => {
        state.userId = userId;
    }
};

const getters = {
    //获取Token
    GET_TOKEN: (state: any) => {
        return state.token;
    },
    //获取用户Id
    GET_USERID: (state: any) => {
        return state.userId;
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
                setStorageToken(token);
                resolve(res);
            }).catch((err: any) => {
                reject(err);
            });
        });
    },
    //获取用户信息
    getUserInfo({ commit }: any) {
        return new Promise((resolve, reject) => {
            ApiHub.getUserInfo().then((res: any) => {
                commit('SET_USERNAME', res.name);
                commit('SET_USERROLE', res.role);
                commit('SET_USERID', res.sub);
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