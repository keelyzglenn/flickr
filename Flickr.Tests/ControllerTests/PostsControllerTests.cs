using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Flickr.Controllers;
using Flickr.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Flickr.Tests
{
    public class PostsControllerTest
    {

        [Fact]
        public async Task Get_ViewResult_Index_Test()
        { 
            var contextOptions = new DbContextOptionsBuilder()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FlickrTest;integrated security=True")
            .Options;

            var _db = new ApplicationDbContext(contextOptions);


            //Arrange
            var controller = new PostsController(_db);
     
            //Act
            var result = await controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}