import user from '../views/UserModule/mock/user.js'
import Mock from 'mockjs'
Mock.setup({
    timeout: '500-600'
});
export default {
    ...user,
}