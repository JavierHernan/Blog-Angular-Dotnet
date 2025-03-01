# Blog-Angular-Dotnet
<!-- Account EndPoints
POST api/Account/register - create new user
POST api/Account/login - allows existing user login

Blog EndPoints
POST api/Blog - create new blog (needs auth)
GET api/Blog - gets all of blogs page by page
GET api/Blog/famous - get top 6 most talked about blogs
GET api/Blog/:id - get the given blog
GET api/Blog/user/:id - get all blogs by user
DELETE api/Blog/:id - delete existing blog (needs auth)

Blog Comment EndPoints
POST api/BlogComment - create new blog comment (needs auth)
DELETE api/BlogCommemt/:id - delete given blog comment (needs auth)
GET api/BlogComment/:Blogid - load all blog comments for a blog

Photo EndPoints
POST api/Photo - upload photo (needs auth)
DELETE api/Photo - delete photo (needs auth)
GET api/Photo - get all of user's photo's (needs auth)
GET api/Photo/:id - get photo -->

<!-- Database Info:

Tables
Users
Blogs
BlogComments
Photo

Schemas
aggregate

Views
Blog
BlogComment

Types
AccountType
BlogCommentType
BlogType
PhotoType

Stored Procedures (Reusable SQL code invoked by API)
Account_GetByUsername
Account_Insert
Blog_Delete
Blog_Get
Blog_GetAll
Blog_GetAllFamous
Blog_GetByUserId
Blog_Upsert
BlogComment_Delete
BlogComment_GetAll
Photo_Delete
Photo_Get
Photo_GetByUserId
Photo_Insert -->