import Vue from 'vue';
import Router from 'vue-router';
import UserManager from './views/UserModule/UserManagerment/UserManager';
Vue.use(Router);

var router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'UserManager',
      meta: { title: '用户管理' },
      component: UserManager,
    }
  ],
});;
router.beforeEach((to, from, next) => {
  /* 路由发生变化修改页面title */
  if (to.meta.title) {
    document.title = to.meta.title
  }
  next();
})
 

export default router