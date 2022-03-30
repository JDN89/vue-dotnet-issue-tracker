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
                                    OpenIssueId = new Guid(),
                                    Title = "Add right margin to Checkout button",
                                    Urgency = "High",
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new OpenIssue
                                {
                                    OpenIssueId = new Guid(),
                                    Title = "Add discount code to the checkout page",
                                    Urgency = "High",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            },
                                       InProgressIssues = new List<InProgressIssue>
                            {
                                new InProgressIssue
                                {
                                    InProgressIssueId = new Guid(),
                                    Title = "Create A Cart Button",
                                    Urgency = "Medium",
                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new InProgressIssue
                                {
                                    InProgressIssueId = new Guid(),
                                    Title = "Provide Documentation on Functionality",
                                    Urgency = "Low",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },    new InProgressIssue
                                {
                                    InProgressIssueId = new Guid(),
                                    Title = "Desing Footer",
                                    Urgency = "Low",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Desing",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                } ,   new InProgressIssue
                                {
                                    InProgressIssueId = new Guid(),
                                    Title = "Provide Documentation on State",
                                    Urgency = "Medium",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Feature Request",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            }, 
                            TestIssues = new List<IssueInReview>
                            {
                                new IssueInReview
                                {
                                    IssueInReviewId = new Guid(),
                                    Title = "Design dropdown menu for shopping cart",
                                    Urgency = "Medium",
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new IssueInReview
                                {
                                    IssueInReviewId = new Guid(),
                                    Title = "Display Items in 4 Grid columns",
                                    Urgency = "High",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Design",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },   new IssueInReview
                                {
                                    IssueInReviewId = new Guid(),
                                    Title = "Create login Controller",
                                    Urgency = "High",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "Backend",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                }
                            }, ClosedIssues= new List<ClosedIssue>
                            {
                                new ClosedIssue
                                {
                                    ClosedIssueId = new Guid(),
                                    Title = "Fix DB connection String",
                                    Urgency = "High",
                                    Type = "Backend",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },
                                new ClosedIssue
                                {
                                    ClosedIssueId    = new Guid(),
                                    Title = "Review login user interface flow",
                                    Urgency = "High",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                                    Type = "QA",
                                    Description =
                                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                                },   new ClosedIssue
                                {
                                    ClosedIssueId = new Guid(),
                                    Title = "Add Total Sum to checkout Page",
                                    Urgency = "High",
                                    
                                  //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
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
                        OpenIssueId = new Guid(),
                        Title = "Add right margin to Checkout button",
                        Urgency = "High",
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new OpenIssue
                    {
                        OpenIssueId = new Guid(),
                        Title = "Add discount code to the checkout page",
                        Urgency = "High",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                InProgressIssues = new List<InProgressIssue>
                {
                    new InProgressIssue
                    {
                        InProgressIssueId = new Guid(),
                        Title = "Create A Cart Button",
                        Urgency = "Medium",
                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        InProgressIssueId = new Guid(),
                        Title = "Provide Documentation on Functionality",
                        Urgency = "Low",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        InProgressIssueId = new Guid(),
                        Title = "Desing Footer",
                        Urgency = "Low",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Desing",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new InProgressIssue
                    {
                        InProgressIssueId = new Guid(),
                        Title = "Provide Documentation on State",
                        Urgency = "Medium",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Feature Request",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                TestIssues = new List<IssueInReview>
                {
                    new IssueInReview
                    {
                        IssueInReviewId = new Guid(),
                        Title = "Design dropdown menu for shopping cart",
                        Urgency = "Medium",
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new IssueInReview
                    {
                        IssueInReviewId = new Guid(),
                        Title = "Display Items in 4 Grid columns",
                        Urgency = "High",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Design",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new IssueInReview
                    {
                        IssueInReviewId = new Guid(),
                        Title = "Create login Controller",
                        Urgency = "High",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "Backend",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    }
                },
                ClosedIssues = new List<ClosedIssue>
                {
                    new ClosedIssue
                    {
                        ClosedIssueId = new Guid(),
                        Title = "Fix DB connection String",
                        Urgency = "High",
                        Type = "Backend",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new ClosedIssue
                    {
                        ClosedIssueId = new Guid(),
                        Title = "Review login user interface flow",
                        Urgency = "High",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
                        Type = "QA",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nec nibh at urna fringilla posuere. Maecenas aliquam mollis faucibus. Nulla tempor diam massa, eget convallis arcu fringilla tempor. Nullam interdum, magna et cursus sodales, ex tellus sodales justo, ac rhoncus lacus libero vel ligula. Sed molestie a magna gravida blandit."
                    },
                    new ClosedIssue
                    {
                        ClosedIssueId = new Guid(),
                        Title = "Add Total Sum to checkout Page",
                        Urgency = "High",

                        //  Date = new DateTime(2022, 03, 15, 01, 01,01 ),
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