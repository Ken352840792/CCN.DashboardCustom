import config from '../../../config';
import Generator from '../../../webApi/generator'
export default new Generator({
     //获取用户信息
     get_UserList: {url: '/user/GetUserList', method: 'post'},
     //删除用户信息
     get_DeleteUser: {url: '/user/DeleteUser', method: 'post'},
}, config.pgyerApiUrl);