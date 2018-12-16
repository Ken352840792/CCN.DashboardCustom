import Mock from 'mockjs'
const Random = Mock.Random;
const produceNewsData = function () {
    let articles = [];
    for (let i = 0; i < 100; i++) {
        let newArticleObject = {
            title: Random.csentence(5, 30), //  Random.csentence( min, max )
            thumbnail_pic_s: Random.dataImage('300x250', 'mock的图片'), // Random.dataImage( size, text ) 生成一段随机的 Base64 图片编码
            author_name: Random.cname(), // Random.cname() 随机生成一个常见的中文姓名
            date: Random.date() + ' ' + Random.time() // Random.date()指示生成的日期字符串的格式,默认为yyyy-MM-dd；Random.time() 返回一个随机的时间字符串
        }
        articles.push(newArticleObject)
    }
    return {
        articles: articles
    }
}
var userList = { "result": { "totalCount": 4309, "items": [{ "title": "什么东西啊", "text": "这是什么东西啊", "voteCount": 0, "answerCount": 0, "viewCount": 1, "creatorUserName": "Yunus Emre", "creationTime": "2018-12-11T04:56:06.233", "creatorUserId": 3, "id": 4309 }, { "title": "What is my name? Anyone can guess?", "text": "You need to find my name", "voteCount": 0, "answerCount": 1, "viewCount": 6, "creatorUserName": "System", "creationTime": "2018-12-10T15:58:39.837", "creatorUserId": 2, "id": 4308 }, { "title": "teste", "text": "teste", "voteCount": 0, "answerCount": 0, "viewCount": 1, "creatorUserName": "System", "creationTime": "2018-12-10T14:24:58.347", "creatorUserId": 2, "id": 4307 }, { "title": "gdfgsd", "text": "gsdfg", "voteCount": 0, "answerCount": 0, "viewCount": 1, "creatorUserName": "System", "creationTime": "2018-12-10T12:27:09.477", "creatorUserId": 2, "id": 4306 }, { "title": "teste", "text": "asdfasdfasd", "voteCount": 0, "answerCount": 0, "viewCount": 0, "creatorUserName": "System", "creationTime": "2018-12-10T05:23:08.103", "creatorUserId": 2, "id": 4305 }, { "title": "asc", "text": "sac", "voteCount": 1, "answerCount": 2, "viewCount": 6, "creatorUserName": "System", "creationTime": "2018-12-10T00:15:11.383", "creatorUserId": 2, "id": 4304 }, { "title": "test", "text": "tet", "voteCount": 1, "answerCount": 3, "viewCount": 18, "creatorUserName": "System", "creationTime": "2018-12-08T13:20:36.12", "creatorUserId": 2, "id": 4303 }, { "title": "hello", "text": "abc", "voteCount": 0, "answerCount": 2, "viewCount": 9, "creatorUserName": "System", "creationTime": "2018-12-08T09:49:56.233", "creatorUserId": 2, "id": 4302 }, { "title": "vcxv", "text": "vcxv", "voteCount": 0, "answerCount": 0, "viewCount": 0, "creatorUserName": "System", "creationTime": "2018-12-07T21:19:02.73", "creatorUserId": 2, "id": 4301 }, { "title": "dfsdfs", "text": "dfsfsfs", "voteCount": 0, "answerCount": 0, "viewCount": 0, "creatorUserName": "System", "creationTime": "2018-12-07T07:30:46.09", "creatorUserId": 2, "id": 4300 }] }, "success": true, "error": null, "unAuthorizedRequest": false };
Mock.mock('/user/GetUserList', 'post', (options) => {
    console.log(JSON.parse(options.body));
    return userList;
});

Mock.mock('/user/DeleteUser', 'post', (options) => {
    console.log(JSON.parse(options.body));
    var options = JSON.parse(options.body);
    var index;
    for (var i in userList.result.items) {
        if (userList.result.items[i].id === id) {//在数组arr里找到这个id
            index = i
            break;
        }
    }
    userList.result.items.splice(index, 1)//把这个id对应的对象从数组里删除
    return { "result": {}, "success": true, "error": null, "unAuthorizedRequest": false };
});
export default Mock