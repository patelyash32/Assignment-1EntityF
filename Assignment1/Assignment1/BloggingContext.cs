﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1;

namespace Assignment1

{
   
        public class BloggingContext : DbContext
        {
            

            public BloggingContext()
            {
                var path = AppContext.BaseDirectory;
                Dbpath = Path.Join(path, "UserBlogPost.db");
            }

            public DbSet<User> Users { get; set; }
                public DbSet<Blog> Blogs { get; set; }
                public DbSet<BlogType> BlogTypes { get; set; }
                public DbSet<Post> Posts { get; set; }
                public DbSet<PostType> PostTypes { get; set; }
                public string Dbpath { get; set; }
               

                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlite($"Data source={Dbpath}");
                }



      
    }
}