using Microsoft.VisualStudio.TestTools.UnitTesting;
using PZ_User_Panel_console.Data.Models;
using PZ_User_Panel_console.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PZ_DAL_Tests
{

    [TestClass]
    public class CategoryRepositoryTests
{
    private CategoryRepository _categoryRepository;
    private StoreDBContext _dbContext;

    [TestInitialize]
    public void Initialize()
    {
        var options = new DbContextOptionsBuilder<StoreDBContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        _dbContext = new StoreDBContext(options);
        _categoryRepository = new CategoryRepository(_dbContext);
    }

    [TestMethod]
    public void AddCategory_Should_Add_Category()
    {
        var category = new Category
        {
            CategoryId = 1,
            CategoryName = "TestCategory1",
        };

        _categoryRepository.AddCategory(category);

        var addedCategory = _dbContext.Category.FirstOrDefault(c => c.CategoryId == category.CategoryId);

        Assert.IsNotNull(addedCategory);
    }

    [TestMethod]
    public void DeleteCategory_Should_Delete_Category()
    {
        var category = new Category
        {
            CategoryId = 2,
            CategoryName = "TestCategory2",
        };

        _categoryRepository.AddCategory(category);
        _categoryRepository.DeleteCategory(2);

        var deletedCategory = _categoryRepository.GetCategoryById(2);

        Assert.IsNull(deletedCategory);
    }

    [TestMethod]
    public void GetAllCategories_Should_Return_All_Categories()
    {
        var category3 = new Category
        {
            CategoryId = 3,
            CategoryName = "TestCategory3",
        };

        _categoryRepository.AddCategory(category3);

        List<Category> categories = _categoryRepository.GetAllCategories();

        Assert.IsNotNull(categories);
        Assert.AreEqual(2, categories.Count);
    }

    [TestMethod]
    public void GetCategoryById_Should_Return_This_Category()
    {
        var expectedCategory = new Category
        {
            CategoryId = 4,
            CategoryName = "TestCategory4",
        };

        _categoryRepository.AddCategory(expectedCategory);

        var retrievedCategory = _categoryRepository.GetCategoryById(4);

        Assert.IsNotNull(retrievedCategory);
        Assert.AreEqual(expectedCategory.CategoryId, retrievedCategory.CategoryId);
        Assert.AreEqual(expectedCategory.CategoryName, retrievedCategory.CategoryName);
    }

    [TestMethod]
    public void UpdateCategory_Should_Update_Category()
    {
        var originalCategory = new Category
        {
            CategoryId = 5,
            CategoryName = "TestCategory5",
        };

        _categoryRepository.AddCategory(originalCategory);

        var updatedCategory = new Category
        {
            CategoryId = 5,
            CategoryName = "UpdatedCategory",
        };

        _categoryRepository.UpdateCategory(updatedCategory);

        var retrievedCategory = _categoryRepository.GetCategoryById(5);

        Assert.IsNotNull(retrievedCategory);
        Assert.AreEqual(updatedCategory.CategoryName, retrievedCategory.CategoryName);
    }

    [TestMethod]
    public void GetCategoryByName_Should_Return_This_Category()
    {
        var category = new Category
        {
            CategoryId = 6,
            CategoryName = "TestCategory6",
        };

        _categoryRepository.AddCategory(category);

        Category retrievedCategory = _categoryRepository.GetCategoryByName("TestCategory6");

        Assert.IsNotNull(retrievedCategory);
        Assert.AreEqual(category.CategoryName, retrievedCategory.CategoryName);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _dbContext = null;
        _categoryRepository = null;
    }
}
}