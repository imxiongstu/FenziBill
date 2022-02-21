import { ILoginForm } from "@/interfaces/ILoginForm";
import { request } from "@/common/request";

const state = {
    token: ''
}

const mutations = {
    SET_TOKEN: (state: any, token: string) => {
        state.token = token
    }
};


const actions = {
    login({ commit }: any, userLoginForm: ILoginForm) {
        return new Promise((resolve, reject) => {
            commit('SET_TOKEN', 'token');
            resolve(void 0);
        });
    }
}

export default {
    namespaced: true,
    state,
    mutations,
    actions
}