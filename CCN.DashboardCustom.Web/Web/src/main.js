import Vue from 'vue';
import App from './App.vue';
import router from './router';
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap/dist/css/bootstrap-theme.css";
import "bootstrap/dist/js/bootstrap.js";
import "@p/bootstrap-validator/bootstrapValidator.css";
import "@p/bootstrap-validator/bootstrapValidator.js";
// import layer from 'vue-layer'
// Vue.prototype.$layer = layer(Vue);
// import "bootstrap/dist/css/bootstrap.css";
// import "bootstrap-vue/dist/bootstrap-vue.css";
// Vue.use(BootstrapVue);
// import store from './store/store';

process.env.NODE_ENV !== 'production' ? require('./mock/index.js') : '';
Vue.config.productionTip = false;
window.vue = new Vue({
  router,
  //store,
  render: h => h(App),
}).$mount('#app');