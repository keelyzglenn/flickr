using Flickr.Models;
using Xunit;

namespace Flickr.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var post = new Post();
            post.Description = "Dog picture";

            //Act
            var result = post.Description;

            //Assert
            Assert.Equal("Dog picture", result);
        }
    }
}
