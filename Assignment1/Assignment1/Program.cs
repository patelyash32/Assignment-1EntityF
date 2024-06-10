using Assignment1;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

var dbcontect = new BloggingContext();


var user1 = new User
{
    Name = "User1",
    EmailAddress = "User1@example.com",
    PhoneNumber = "1234785996"
};

var user2 = new User
{
    Name = "User2",
    EmailAddress = "User2@example.com",
    PhoneNumber = "987564123"
};
dbcontect.Users.Add(user1);
dbcontect.Users.Add(user2);
dbcontect.SaveChanges();


var blogType = new BlogType
{

    Name = "Blog1",
    Description = "A blog Description"
};

var postType = new PostType
{
    Name = "Post Type Name",
    Description = "Post Type Description",
    Status = "Active"
};

dbcontect.BlogTypes.Add(blogType);
dbcontect.PostTypes.Add(postType);
dbcontect.SaveChanges();

var blog = new Blog
{
    Url = "http://example.com",
    IsPublic = true,
   
    BlogTypeId = blogType.BlogTypeId 
};
dbcontect.Blogs.Add(blog);
dbcontect.SaveChanges();



List<User> users;
List<Blog> blogs;
List<PostType> postTypes;


users = dbcontect.Users.ToList();
var UserId = users.First().UserId;

blogs = dbcontect.Blogs.ToList();
var BlogId = blogs.First().BlogId;

postTypes = dbcontect.PostTypes.ToList();
var postTypeId = postTypes.First().PostTypeId;


var newPost = new Post
{
    Title = "New Post Title",
    Content = "This is the content of the new post",
    UserId = UserId,
    BlogId = BlogId,
    PostTypeId = postTypeId

};

dbcontect.Posts.Add(newPost);
dbcontect.SaveChanges();

List<Post> Posts;


Posts = dbcontect.Posts.ToList();


foreach (var p in Posts)
{
    Console.WriteLine($"ID : {p.PostId},Title : {p.Title},  Content : {p.Content}, User Name : {p.User.Name}, Post Type Name : {p.PostType.Name}, ");
}

