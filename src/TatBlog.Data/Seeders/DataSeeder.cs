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

        // 10 Categories at least
        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() // 1
                {
                    Name=".NET Core",
                    Description="Strong framework using C#",
                    UrlSlug="dot-net-core"
                },
                new() // 2
                {
                    Name="Architecture",
                    Description="Computer Architecture",
                    UrlSlug="architecture",
                },
                new() // 3
                {
                    Name="Messaging",
                    Description="Digital messaging",
                    UrlSlug="messaging",
                },
                new() // 4
                {
                    Name="OOP",
                    Description="Object-Oriented Programming",
                    UrlSlug="object-oriented-programming"
                },
                new() // 5
                {
                    Name="Design Pattern",
                    Description="A variety of solutions to solve various problems in OOP",
                    UrlSlug="design-pattern"
                },
                new() // 6
                {
                    Name="Data structure ",
                    Description="Data oganization, management and storage format that is usually chosen for " +
                    " efficient access to data.",
                    UrlSlug="data-structure"
                },
                new() // 7
                {
                    Name="Algorithms",
                    Description="Colections of steps to sole a particular problem.",
                    UrlSlug="data-structure"
                },
                new() // 8
                {
                    Name="Front-end developing",
                    Description="Building UI of a website or a web application",
                    UrlSlug="react",
                },
                new() // 9
                {
                    Name="Back-end developing",
                    Description="Building logic processing system for a web application",
                    UrlSlug="messaging",
                },
                new() // 10
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
                }, // 1
                new()
                {
                    Name="ASP.NET MVC",
                    Description="MVC is one of the most popular patterns used for Web developing.\nTake a look about MVC pattern deployed in ASP.NET framework ",
                    UrlSlug="asp-dot-net-mvc",
                }, // 2
                new()
                {
                    Name="Razor Page",
                    Description="Tip about HTML pages that contain C# Scripts",
                    UrlSlug="razor-page"
                }, // 3
                new()
                {
                    Name="Blazor",
                    Description="A framework help you to interact with Web UI using C#",
                    UrlSlug="blazor",
                }, // 4
                new()
                {
                    Name="Deep Learning",
                    Description="A part of Machine Learning (ML) in Artificial Intelligence (AI). " +
                    "In stead of being trained from human being in ML, Deep Learning allow computer " +
                    "to \"study\" and \"upgrade\" itself through complex algorithms ",
                    UrlSlug="deep-learning"
                }, // 5
                new()
                {
                    Name="Neural Network",
                    Description="A chain of Algorithms that help finding basic relationships of a set of data based on human brain's activity imitation.",
                    UrlSlug="neural-network"
                }, // 6
                new()
                {
                    Name="Flutter",
                    Description="A powerful framework help building apps in multi-platform"  ,
                    UrlSlug="flutter"
                }, // 7
                new()
                {
                    Name="Django",
                    Description="Web-developing framework using Python",
                    UrlSlug="django",
                }, // 8
                new()
                {
                    Name="Unity",
                    Description="Game development platform using C#",
                    UrlSlug="unity"
                }, // 9
                new()
                {
                    Name="Machine Learning",
                    Description="A part of Artificial Intelligence (AI). The computer will be trained " +
                    "to do various tasks that impossible for human being",
                    UrlSlug="machine-learning",
                }, // 10
                new()
                {
                    Name="Bootstrap",
                    Description="Powerful library for front-end developers",
                    UrlSlug="bootstrap"
                }, // 11
                new()
                {
                    Name="Natural Language Processing",
                    Description="Give computer ability to understand text and spoken words in much the same" +
                    " way human beings can ",
                    UrlSlug="nlp"
                }, // 12
                new()
                {
                    Name="Lavarel",
                    Description="A famous web-developing framework use PHP language",
                    UrlSlug="lavarel"
                }, // 13
                new()
                {
                    Name="Python",
                    Description="A popular programming language, especially in Data Science",
                    UrlSlug="python",
                }, // 14
                new()
                {
                    Name="Java",
                    Description="A well-knowned programming language",
                    UrlSlug="java"
                }, // 15
                new()
                {
                    Name="Docker",
                    Description="Platform used for deploying projects in various containers",
                    UrlSlug="blazor",
                }, // 16
                new()
                {
                    Name="Ruby On Rail",
                    Description="A web-developing framework use Ruby",
                    UrlSlug="ruby-on-rail"
                }, // 17
                new()
                {
                    Name="Golang",
                    Description="A short-syntax programming language developed by Google",
                    UrlSlug="neural-network"
                }, // 18
                new()
                {
                    Name="Dart",
                    Description="An amazing programming language used in Flutter SDK"  ,
                    UrlSlug="flutter"
                }, // 19
                new()
                {
                    Name="SQL",
                    Description="Popular Language used in data querying",
                    UrlSlug="swift",
                }, // 20
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 2
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 3
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2  ],tags[1]
                    }
                }, // 4
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
                }, // 5
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 6
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 7
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 8
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
                }, // 9
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 10
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 11
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 12
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
                }, // 13
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 14
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 15
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 16
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 2
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 3
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 4
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
                }, // 5
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 6
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 7
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 8
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
                }, // 9
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 10
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 11
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 12
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
                }, // 13
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
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[19],tags[1]
                    }
                }, // 14
                new()
                {
                    Title="Top web developing frameworks",
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
                }, // 15
                new()
                {
                    Title="Tips to manage your data",
                    ShortDecription="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec commodo felis. Integer venenatis velit sit amet vulputate ornare. Maecenas finibus rhoncus ligula, sit amet rhoncus nunc. Vivamus bibendum lorem ipsum. Fusce maximus velit quis turpis iaculis consequat.",
                    Meta="Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    UrlSlug="tips-to-manage-your-data",
                    Published=true,
                    PostedDate=new DateTime(2020,11,23,13,20,0),
                    ModifiedDate=null,
                    ViewCount=10,
                    Author=authors[0],
                    Category=categories[9],
                    Tags=new List<Tag>()
                    {
                        tags[2],tags[1]
                    }
                }, // 16

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

