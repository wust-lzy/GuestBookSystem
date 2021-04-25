# GuestBookSystem
2020/11/26

基于.NET架构开发的一款数据库留言本项目
实现了基本的数据库增删改查操作

## 数据库设计：
- Users表
  1. UserId 用户序号  （主键）
  2. Email  用户邮箱
  3. Name  用户姓名
  4. Password 用户密码
  5. SRole  判断用户是否为管理员
- Guestbook表
  1. Title 留言标题
  2. Content 留言内容
  3. AuthorEmail 作者邮箱
  4. CreateedOn  留言日期
  5. IsPass 是否被管理员审核通过
  6. UserId 留言用户的id
  7. GuestbookId 留言本id  （主键）





使用方法，下载项目，加载到vs2019中，点击 GuestBookSystem.slh 即可运行

首页 

![image](https://user-images.githubusercontent.com/54877983/115983849-5c984700-a5d6-11eb-9931-e2d6385ae9f7.png)



管理员后台

![image](https://user-images.githubusercontent.com/54877983/115984016-653d4d00-a5d7-11eb-908c-a0eadfb5d3bc.png)



用户提交留言请求

![image](https://user-images.githubusercontent.com/54877983/115984058-a170ad80-a5d7-11eb-8440-6b8eca3a1824.png)


管理员处理请求

![image](https://user-images.githubusercontent.com/54877983/115984073-b5b4aa80-a5d7-11eb-9123-aa706e017d02.png)