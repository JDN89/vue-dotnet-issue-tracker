using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence;

public class Seed
{
    public Seed()
    {
    }

    public static async Task SeedData(DataContext context,
        UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var users = new List<AppUser>
            {
                new AppUser
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                },
                new AppUser
                {
                    UserName = "jan",
                    Email = "jan@test.com",
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            ProjectId = new Guid(),
                            Title = "Issue Tracker",
                            OpenIssues = new List<OpenIssue>
                            {
                                new OpenIssue
                                {
                                    Id= new Guid(),
                                    Title = "Add right margin to Checkout button",
                                    Urgency = "HIGH",
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new OpenIssue
                                {
                                    Id= new Guid(),
                                    Title = "Add discount code to the checkout page",
                                    Urgency = "HIGH",

                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            },
                                       InProgressIssues = new List<InProgressIssue>
                            {
                                new InProgressIssue
                                {
                                    Id= new Guid(),
                                    Title = "Create A Cart Button",
                                    Urgency = "MEDIUM",
                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new InProgressIssue
                                {
                                    Id= new Guid(),
                                    Title = "Provide Documentation on Functionality",
                                    Urgency = "LOW",

                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },    new InProgressIssue
                                {
                                    Id= new Guid(),
                                    Title = "Desing Footer",
                                    Urgency = "LOW",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Desing",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                } ,   new InProgressIssue
                                {
                                    Id= new Guid(),
                                    Title = "Provide Documentation on State",
                                    Urgency = "MEDIUM",

                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            },
                            IssuesInReview = new List<IssueInReview>
                            {
                                new IssueInReview
                                {
                                    Id= new Guid(),
                                    Title = "Design dropdown menu for shopping cart",
                                    Urgency = "MEDIUM",
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new IssueInReview
                                {
                                    Id= new Guid(),
                                    Title = "Display Items in 4 Grid columns",
                                    Urgency = "HIGH",

                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },   new IssueInReview
                                {
                                    Id = new Guid(),
                                    Title = "Create login Controller",
                                    Urgency = "HIGH",

                                    Type = "Backend",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            }, ClosedIssues= new List<ClosedIssue>
                            {
                                new ClosedIssue
                                {
                                    Id= new Guid(),
                                    Title = "Fix DB connection String",
                                    Urgency = "HIGH",
                                    Type = "Backend",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new ClosedIssue
                                {
                                    Id= new Guid(),
                                    Title = "Review login user interface flow",
                                    Urgency = "HIGH",

                                    Type = "QA",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },   new ClosedIssue
                                {
                                    Id= new Guid(),
                                    Title = "Add Total Sum to checkout Page",
                                    Urgency = "HIGH",

                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            },
                        },

                    }
                },
                new AppUser
                {
                    UserName = "tom",
                    Email = "tom@test.com"
                },
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }


            await context.SaveChangesAsync();
        }

        if (!context.Projects.Any())
        {
            Console.WriteLine("no projects");
            var user = context.Users.SingleOrDefault((u) => u.Email == "jan@test.com");
            var project = new Project
            {
                ProjectId = new Guid(),
                Title = "Issue Tracker",
                AppUser = user,
                OpenIssues = new List<OpenIssue>
                {
                    new OpenIssue
                    {
                        Id = new Guid(),
                        Title = "Add right margin to Checkout button",
                        Urgency = "LOW",
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new OpenIssue
                    {
                       Id = new Guid(),
                        Title = "Add discount code to the checkout page",
                        Urgency = "HIGH",

                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                InProgressIssues = new List<InProgressIssue>
                {
                    new InProgressIssue
                    {
                        Id = new Guid(),
                        Title = "Create A Cart Button",
                        Urgency = "MEDIUM",
                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        Id = new Guid(),
                        Title = "Provide Documentation on Functionality",
                        Urgency = "LOW",

                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        Id = new Guid(),
                        Title = "Design Footer",
                        Urgency = "LOW",

                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        Id= new Guid(),
                        Title = "Provide Documentation on State",
                        Urgency = "MEDIUM",

                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                IssuesInReview = new List<IssueInReview>
                {
                    new IssueInReview
                    {
                        Id = new Guid(),
                        Title = "Design dropdown menu for shopping cart",
                        Urgency = "MEDIUM",
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new IssueInReview
                    {
                        Id= new Guid(),
                        Title = "Display Items in 4 Grid columns",
                        Urgency = "HIGH",

                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new IssueInReview
                    {
                        Id= new Guid(),
                        Title = "Create login Controller",
                        Urgency = "HIGH",

                        Type = "Backend",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                ClosedIssues = new List<ClosedIssue>
                {
                    new ClosedIssue
                    {
                        Id = new Guid(),
                        Title = "Fix DB connection String",
                        Urgency = "HIGH",
                        Type = "Backend",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new ClosedIssue
                    {
                        Id = new Guid(),
                        Title = "Review login user interface flow",
                        Urgency = "HIGH",

                        Type = "QA",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new ClosedIssue
                    {
                        Id= new Guid(),
                        Title = "Add Total Sum to checkout Page",
                        Urgency = "HIGH",
                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
            };
            await context.AddAsync(project);
            await context.SaveChangesAsync();
        }
    }
}
