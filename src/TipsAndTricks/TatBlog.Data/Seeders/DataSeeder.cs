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

        // 5 Authors at least
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
                }, // 0
                new()
                {
                    FullName ="Jessica Wonder",
                    UrlSlug="jessica-wonder",
                    Email="jessica665@motip.com",
                    JoinedDate=new DateTime(2020,4,19)
                }, // 1
                new()
                {
                    FullName ="Benedict House",
                    UrlSlug="benedict-house",
                    Email="bndhouse632@motip.com",
                    JoinedDate=new DateTime(2010,4,10)
                }, // 2
                new()
                {
                    FullName ="Leonard Gester",
                    UrlSlug="Leonard-gester",
                    Email="leogester@hotmail.com",
                    JoinedDate=new DateTime(2018,8,3)
                }, // 3
                new()
                {
                    FullName ="Alexander Helminton",
                    UrlSlug="alexander-helminton",
                    Email="alexhelmin@gmail.com",
                    JoinedDate=new DateTime(2015,12,19)
                } //4
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }

        // 10 Categories at least
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name=".NET Core",
                    Description="Strong framework using C#",
                    UrlSlug="dot-net-core"
                }, // 0 .netcore 
                new()
                {
                    Name="Architecture",
                    Description="Computer Architecture",
                    UrlSlug="architecture",
                }, // 1 architecture
                new()
                {
                    Name="Mobile",
                    Description="Mobile developing",
                    UrlSlug="mobile",
                }, // 2 mobile
                new()
                {
                    Name="OOP",
                    Description="Object-Oriented Programming",
                    UrlSlug="object-oriented-programming"
                }, // 3 oop
                new()
                {
                    Name="Design Pattern",
                    Description="A variety of solutions to solve various problems in OOP",
                    UrlSlug="design-pattern"
                }, // 4 design pattern
                new()
                {
                    Name="Data structure ",
                    Description="Data oganization, management and storage format that is usually chosen for " +
                    " efficient access to data.",
                    UrlSlug="data-structure"
                }, // 5 data structure
                new()
                {
                    Name="Algorithms",
                    Description="Colections of steps to sole a particular problem.",
                    UrlSlug="data-structure"
                }, // 6 algorithms
                new()
                {
                    Name="Artificial Inteligence",
                    Description="Help computer to behave similar with human beings",
                    UrlSlug="artificial-inteligence",
                }, // 7 artificial inteligence
                new()
                {
                    Name="Web developing",
                    Description="Building logic processing system for a web application",
                    UrlSlug="web-developing",
                }, // 8 web developing
                new()
                {
                    Name="Database",
                    Description="An oganized collection of data stored and accessed electronically",
                    UrlSlug="database"
                }, // 9 database

            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        // 20 Tags at least
        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new()
                {
                    Name="Google",
                    Description="Google applications",
                    UrlSlug="google-applications"
                }, // 0 Google
                new()
                {
                    Name="ASP.NET MVC",
                    Description="MVC is one of the most popular patterns used for Web developing.\nTake a look about MVC pattern deployed in ASP.NET framework ",
                    UrlSlug="asp-dot-net-mvc",
                }, // 1 asp.net mvc
                new()
                {
                    Name="Razor Page",
                    Description="Tip about HTML pages that contain C# Scripts",
                    UrlSlug="razor-page"
                }, // 2 razor page
                new()
                {
                    Name="Blazor",
                    Description="A framework help you to interact with Web UI using C#",
                    UrlSlug="blazor",
                }, // 3 blazor
                new()
                {
                    Name="Deep Learning",
                    Description="A part of Machine Learning (ML) in Artificial Intelligence (AI). " +
                    "In stead of being trained from human being in ML, Deep Learning allow computer " +
                    "to \"study\" and \"upgrade\" itself through complex algorithms ",
                    UrlSlug="deep-learning"
                }, // 4 deep learning
                new()
                {
                    Name="Neural Network",
                    Description="A chain of Algorithms that help finding basic relationships of a set of data based on human brain's activity imitation.",
                    UrlSlug="neural-network"
                }, // 5 neural network
                new()
                {
                    Name="Flutter",
                    Description="A powerful framework help building apps in multi-platform"  ,
                    UrlSlug="flutter"
                }, // 6 flutter
                new()
                {
                    Name="Django",
                    Description="Web-developing framework using Python",
                    UrlSlug="django",
                }, // 7 django
                new()
                {
                    Name="Unity",
                    Description="Game development platform using C#",
                    UrlSlug="unity"
                }, // 8 unity
                new()
                {
                    Name="Machine Learning",
                    Description="A part of Artificial Intelligence (AI). The computer will be trained " +
                    "to do various tasks that impossible for human being",
                    UrlSlug="machine-learning",
                }, // 9 machine learning
                new()
                {
                    Name="Bootstrap",
                    Description="Powerful library for front-end developers",
                    UrlSlug="bootstrap"
                }, // 10 bootstrap
                new()
                {
                    Name="Natural Language Processing",
                    Description="Give computer ability to understand text and spoken words in much the same" +
                    " way human beings can ",
                    UrlSlug="nlp"
                }, // 11 nlp
                new()
                {
                    Name="Lavarel",
                    Description="A famous web-developing framework use PHP language",
                    UrlSlug="lavarel"
                }, // 12 lavarel
                new()
                {
                    Name="Python",
                    Description="A popular programming language, especially in Data Science",
                    UrlSlug="python",
                }, // 13 python
                new()
                {
                    Name="Java",
                    Description="A well-knowned programming language",
                    UrlSlug="java"
                }, // 14 java
                new()
                {
                    Name="Docker",
                    Description="Platform used for deploying projects in various containers",
                    UrlSlug="blazor",
                }, // 15 docker
                new()
                {
                    Name="Ruby On Rail",
                    Description="A web-developing framework use Ruby",
                    UrlSlug="ruby-on-rail"
                }, // 16 ruby on rail
                new()
                {
                    Name="Golang",
                    Description="A short-syntax programming language developed by Google",
                    UrlSlug="neural-network"
                }, // 17 golang
                new()
                {
                    Name="Dart",
                    Description="An amazing programming language used in Flutter SDK"  ,
                    UrlSlug="dart"
                }, // 18 dart
                new()
                {
                    Name="SQL",
                    Description="Popular Language used in data querying",
                    UrlSlug="sql",
                }, // 19 sql
            };
            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

        // 30 Posts at least
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
                }, // 1
                new()
                {
                    Title="Tip to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tip-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2011,9,20,10,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[6],
                    Tags=new List<Tag>()
                    {
                        tags[13],tags[19]
                    }
                }, // 2
                new()
                {
                    Title="Top web developing frameworks",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="top-web-developing-frameworks",
                    Published=true,
                    PostedDate=new DateTime(2018,9,4,13,30,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[0],tags[1], tags[7], tags[12], tags[16]
                    }
                }, // 3
                new()
                {
                    Title="How I build a game",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-i-build-a-game",
                    Published=true,
                    PostedDate=new DateTime(2019,11,1,8,22,0),
                    ModifiedDate=null,
                    ViewCount=20,
                    Author=authors[1],
                    Category=categories[0],
                    Tags=new List<Tag>()
                    {
                        tags[1],tags[8]
                    }
                }, // 4
                new()
                {
                    Title="Mobile Developing trend",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="mobile-developing-trend",
                    Published=true,
                    PostedDate=new DateTime(2012,9,4,7,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[2],
                    Tags=new List<Tag>()
                    {
                        tags[6],tags[18]
                    }
                }, // 5
                new()
                {
                    Title="A closer look about facial recognition",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="a-closer-look-about-facial-recognition",
                    Published=true,
                    PostedDate=new DateTime(2020,3,4,17,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[7],
                    Tags=new List<Tag>()
                    {
                        tags[9],tags[11],tags[13]
                    }
                }, // 6
                new()
                {
                    Title="Front-end developing",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="front-end-developing",
                    Published=true,
                    PostedDate=new DateTime(2010,12,30,15,23,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[10]
                    }
                }, // 7
                new()
                {
                    Title="How I became a server-side developer",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-i-became-a-server-side-developer",
                    Published=true,
                    PostedDate=new DateTime(2009,11,30,12,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[1],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[7],tags[16],tags[17]
                    }
                }, // 8
                new()
                {
                    Title="How computer understand our words",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-computer-understand-out-words",
                    Published=true,
                    PostedDate=new DateTime(2022,12,25,8,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[7],
                    Tags=new List<Tag>()
                    {
                        tags[13],tags[11]
                    }
                }, // 9
                new()
                {
                    Title="How to have a clean code?",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-to-have-a-clean-code",
                    Published=true,
                    PostedDate=new DateTime(2015,3,10,11,30,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[6],
                    Tags=new List<Tag>()
                    {
                        tags[14],tags[13]
                    }
                }, // 10
                new()
                {
                    Title="How I sort my array",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-i-sort-my-array",
                    Published=true,
                    PostedDate=new DateTime(2022,3,2,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[6],
                    Tags=new List<Tag>()
                    {
                        tags[13],tags[18]
                    }
                }, // 11
                new()
                {
                    Title="Upside down tree",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="upside-down-tree",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[5],
                    Tags=new List<Tag>()
                    {
                        tags[13],tags[17]
                    }
                }, // 12
                new()
                {
                    Title="My reaction about Django",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="my-reaction-about-django",
                    Published=true,
                    PostedDate=new DateTime(2011,10,23,14,32,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[1],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[7],tags[13]
                    }
                }, // 13
                new()
                {
                    Title="Terms about AI",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="terms-about-ai",
                    Published=true,
                    PostedDate=new DateTime(2022,4,2,12,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[7],
                    Tags=new List<Tag>()
                    {
                        tags[5],tags[9],tags[4],tags[11],tags[13]
                    }
                }, // 14
                new()
                {
                    Title="How to be good at SQL",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-to-be-good-at-sql",
                    Published=true,
                    PostedDate=new DateTime(2011,12,10,22,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[1],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19]
                    }
                }, // 15
                new()
                {
                    Title="Where is Multiple inheritance",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="where-is-multiple-inheritance",
                    Published=true,
                    PostedDate=new DateTime(2013,1,23,23,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[3],
                    Tags=new List<Tag>()
                    {
                        tags[14]
                    }
                }, // 16
                new()
                {
                    Title="Prototype in python",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="prototype-in-python",
                    Published=true,
                    PostedDate=new DateTime(2011,3,1,20,10,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[4],
                    Tags=new List<Tag>()
                    {
                        tags[13]
                    }
                }, // 17
                new()
                {
                    Title="Mobile trend",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="mobile-trend",
                    Published=true,
                    PostedDate=new DateTime(2012,12,13,10,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[2],
                    Tags=new List<Tag>()
                    {
                        tags[6],tags[18]
                    }
                }, // 18
                new()
                {
                    Title="Brief history about computer",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="brief-history-about-computer",
                    Published=true,
                    PostedDate=new DateTime(2011,12,20,6,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[1],
                    Tags=new List<Tag>()
                    {
                        tags[0]
                    }
                }, // 19
                new()
                {
                    Title="How to host your website?",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="how-to-host-your-website",
                    Published=true,
                    PostedDate=new DateTime(2018,3,22,11,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[1],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[15]
                    }
                }, // 20
                new()
                {
                    Title="SQL or noSQL?",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="sql-or-nosql",
                    Published=true,
                    PostedDate=new DateTime(2020,10,20,3,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[15],tags[19]
                    }
                }, // 21
                new()
                {
                    Title="Write C# on your html page",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="write-c-shaph-on-your-html-page",
                    Published=true,
                    PostedDate=new DateTime(2011,9,20,10,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[1],tags[2],tags[3]
                    }
                }, // 22
                new()
                {
                    Title="Japanese Web Application",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="japanese-web-application",
                    Published=true,
                    PostedDate=new DateTime(2011,2,11,15,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[16]
                    }
                }, // 23
                new()
                {
                    Title="Widget, what is that?",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="widget-what-is-that",
                    Published=true,
                    PostedDate=new DateTime(2020,1,2,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[2],
                    Category=categories[2],
                    Tags=new List<Tag>()
                    {
                        tags[6],tags[18]
                    }
                }, // 24
                new()
                {
                    Title="ASP.NET tips",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="aspnet-core-dianostic-scenarios",
                    Published=true,
                    PostedDate=new DateTime(2021,9,30,10,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[0],
                    Tags=new List<Tag>()
                    {
                        tags[0],tags[1]
                    }
                }, // 25
                new()
                {
                    Title="Shortest code ever",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="shortest-code-ever",
                    Published=true,
                    PostedDate=new DateTime(2012,1,15,20,15,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[4],
                    Category=categories[3],
                    Tags=new List<Tag>()
                    {
                        tags[13]
                    }
                }, // 26
                new()
                {
                    Title="Digital brain",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="digital-brain",
                    Published=true,
                    PostedDate=new DateTime(2020,9,10,10,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[7],
                    Tags=new List<Tag>()
                    {
                        tags[4],tags[5]
                    }
                }, // 27
                new()
                {
                    Title="What is docker?",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="what-is-docker?",
                    Published=true,
                    PostedDate=new DateTime(2012,12,23,3,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[8],
                    Tags=new List<Tag>()
                    {
                        tags[17],tags[15]
                    }
                }, // 28
                new()
                {
                    Title="Why I choose Python",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="why-i-choose-python",
                    Published=true,
                    PostedDate=new DateTime(2011,3,20,10,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[3],
                    Tags=new List<Tag>()
                    {
                        tags[13]
                    }
                }, // 29
                new()
                {
                    Title="Look how I made chatbot",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="look-how-i-made-chatbot",
                    Published=true,
                    PostedDate=new DateTime(2011,9,20,10,00,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[3],
                    Category=categories[7],
                    Tags=new List<Tag>()
                    {
                        tags[13],tags[11],tags[4],tags[9]
                    }
                }, // 30
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

