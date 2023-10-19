using DotnetAngular.Dto;
using DotnetAngular.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DotnetAngular.Data
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Slide>().HasData(
                new Slide
                {
                    Id =1,
                    Urlimage = "./assets/images/img1.jpg",
                    Active = true
                },
                new Slide
                {
                    Id=2,
                    Urlimage = "./assets/images/img2.jpg",
                    Active = false
                }
                );
            modelBuilder.Entity<Post>().HasData(
                    new Post
                    {
                    Id = 1,
                    Title = "The biggest and most awesome camera of year",
                    Createdat = DateTime.Now,
                    Content =
                    "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                    Imageurl = "./assets/images/blog1.png"
                    },
                    new Post
                    {
                    Id = 2,
                    Title = "What 3 years of android taught me the hard way",
                    Createdat = DateTime.Now,
                    Content =
                    "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                    Imageurl = "./assets/images/blog2.png"
                    },
                    new Post
                    {
                    Id = 3,
                    Title = " 2 The biggest and most awesome camera of year",
                    Createdat = DateTime.Now,
                    Content =
                    "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                    Imageurl = "./assets/images/blog1.png"
                    },
                    new Post
                    {
                    Id = 4,
                    Title = " 2 What 3 years of android taught me the hard way",
                    Createdat = DateTime.Now,
                    Content =
                    "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable.",
                    Imageurl = "./assets/images/blog2.png"
                    },
                    new Post
                    {
                        Id = 5,
                        Title = "About",
                        Createdat = DateTime.Now,
                        Content = "<div class=\"section layout_padding dark_bg\">\r\n  <div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n      <div class=\"col-md-6\">\r\n        <img src=\"images/marketing_img.png\" alt=\"#\" />\r\n      </div>\r\n      <div class=\"col-md-6\">\r\n        <div class=\"full blog_cont\">\r\n          <h3 class=\"white_font\">Where can I get some</h3>\r\n          <h5 class=\"grey_font\">March 19 2019 5 READ</h5>\r\n          <p class=\"white_font\">There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined g to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator..</p>\r\n        </div>\r\n      </div>\r\n    </div>\r\n\r\n  </div>\r\n</div>\r\n<div class=\"section layout_padding\">\r\n  <div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n      <div class=\"col-md-6\">\r\n        <div class=\"full blog_cont\">\r\n          <h3>Where can I get some</h3>\r\n          <h5>March 19 2019 5 READ</h5>\r\n          <p>There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined g to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator..</p>\r\n        </div>\r\n      </div>\r\n      <div class=\"col-md-6\">\r\n        <img src=\"assets/images/marketing_img.png\" alt=\"#\" />\r\n      </div>\r\n\r\n    </div>\r\n  </div>\r\n</div>",
                        Imageurl = "",
                        PostTypeId =1
                    }
                    );
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                Id = 1,
                PostId = 1,
                Name = "Veniam - Veniam@gmail.com",
                Content =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.",
                Createdat = DateTime.Today
                },
                new Comment
                {
                Id = 2,
                PostId = 1,
                Name = "Jack - Jack@gmail.com",
                Content =
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.",
                Createdat = DateTime.Today
                }
                 );
            modelBuilder.Entity<PostType>().HasData(
                        new PostType
                        {
                            Id = 1,
                            Name = "About"
                        });

        }
    }
}
