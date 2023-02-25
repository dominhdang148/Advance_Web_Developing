using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName ="Jason Mouth",
                    UrlSlug="jason-mouth",
                    Email="json@gmail.com",
                    JoinedDate=new DateTime(2022,10,21)
                },
                new()
                {
                    FullName ="Jessica Wonder",
                    UrlSlug="jessica-wonder",
                    Email="jessica665@motip.com",
                    JoinedDate=new DateTime(2020,4,19)
                },
                 new()
                {
                    FullName ="Benedict House",
                    UrlSlug="benedict-house",
                    Email="bndhouse632@motip.com",
                    JoinedDate=new DateTime(2010,4,10)
                },
                  new()
                {
                    FullName ="Leonard Gester",
                    UrlSlug="Leonard-gester",
                    Email="leogester@hotmail.com",
                    JoinedDate=new DateTime(2018,8,3)
                },
                   new()
                {
                    FullName ="Alexander Helminton",
                    UrlSlug="alexander-helminton",
                    Email="alexhelmin@gmail.com",
                    JoinedDate=new DateTime(2015,12,19)
                }
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name=".NET Core",
                    Description="Strong framework using C#",
                    UrlSlug="dot-net-core"
                },
                new()
                {
                    Name="Architecture",
                    Description="Computer Architecture",
                    UrlSlug="architecture",
                },
                new()
                {
                    Name="Messaging",
                    Description="Digital messaging",
                    UrlSlug="messaging",
                },
                new()
                {
                    Name="OOP",
                    Description="Object-Oriented Programming",
                    UrlSlug="object-oriented-programming"
                },
                new()
                {
                    Name="Design Pattern",
                    Description="A variety of solutions to solve various problems in OOP",
                    UrlSlug="design-pattern"
                },
                 new()
                {
                    Name="Data structure ",
                    Description="Data oganization, management and storage format that is usually chosen for " +
                    " efficient access to data and collections of steps to solve a particular problem.",
                    UrlSlug="data-structure"
                },
                 new()
                {
                    Name="Data structure ",
                    Description="Data oganization, management and storage format that is usually chosen for " +
                    " efficient access to data and collections of steps to solve a particular problem.",
                    UrlSlug="data-structure"
                },
                new()
                {
                    Name="Front-end developing",
                    Description="Building UI of a website or a web application",
                    UrlSlug="react",
                },
                new()
                {
                    Name="Back-end developing",
                    Description="Building logic processing system for a web application",
                    UrlSlug="messaging",
                },
                new()
                {
                    Name="Database",
                    Description="An oganized collection of data stored and accessed electronically",
                    UrlSlug="object-oriented-programming"
                },

            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new()
                {
                    Name="Google",
                    Description="Google applications",
                    UrlSlug="google-applications"
                },
                new()
                {
                    Name="ASP.NET MVC",
                    Description="MVC is one of the most popular patterns used for Web developing.\nTake a look about MVC pattern deployed in ASP.NET framework ",
                    UrlSlug="asp-dot-net-mvc",
                },
                new()
                {
                    Name="Razor Page",
                    Description="Tip about HTML pages that contain C# Scripts",
                    UrlSlug="razor-page"
                },
                new()
                {
                    Name="Blazor",
                    Description="A framework help you to interact with Web UI using C#",
                    UrlSlug="blazor",
                }
                new()
                {
                    Name="Deep Learning",
                    Description="A part of Machine Learning (ML) in Artificial Intelligence (AI). " +
                    "In stead of being trained from human being in ML, Deep Learning allow computer " +
                    "to \"study\" and \"upgrade\" itself through complex algorithms ",
                    UrlSlug="deep-learning"
                },
                new()
                {
                    Name="Neural Network",
                    Description="A chain of Algorithms that help finding basic relationships of a set of data based on human brain's activity imitation."
                }
            };
            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }
        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title="ASP.NET Core Dianostic Scenarios",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="aspnet-core-dianostic-scenarios",
                    Published=true,
                    PostedDate=new DateTime(2021,9,30,10,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[0],
                    Tags=new List<Tag>()
                    {
                        tags[0],tags[1]
                    }
                }
            };

            _dbContext.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) { return; }

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);


        }
    }


}

