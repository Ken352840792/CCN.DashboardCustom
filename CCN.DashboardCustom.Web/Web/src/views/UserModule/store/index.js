import Vue from 'vue'
import Vuex from 'vuex'
// initial state
const state = {};

// getters
const getters = {};

// actions
const actions = {};

// mutations
const mutations = {};

Vue.use(Vuex);

export default new Vuex.Store({
    modules: {
        cart,
        address,
        user,
        home
    },
    state,
    getters,
    mutations,
    actions,
    strict: process.env.NODE_ENV !== 'production'
});