using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Zeun.Web.Data;
using Zeun.Web.Models;

public class DbContextTests
{
    [Fact]
    public void DbContext_CanBeCreated()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<OgrenciDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Act
        using (var context = new OgrenciDbContext(options))
        {
            // Assert
            Assert.NotNull(context);
        }
    }

    [Fact]
    public void DbContext_CanRetrieveData()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<OgrenciDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new OgrenciDbContext(options))
        {
            var expectedFakulte = new Fakulte { FakulteId = 1, FakulteAdi = "Test Fakulte" };
            context.Fakultes.Add(expectedFakulte);
            context.SaveChanges();
        }

        // Act
        using (var context = new OgrenciDbContext(options))
        {
            var retrievedFakulte = context.Fakultes.FirstOrDefault();

            // Assert
            Assert.NotNull(retrievedFakulte);
            Assert.Equal(expectedFakulte.FakulteAdi, retrievedFakulte.FakulteAdi);
        }
    }

    // Add more tests for other entities and relationships as needed
}
