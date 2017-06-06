using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
  public class CategoryTest : IDisposable
  {
    public CategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_items_test;Integrated Security=SSPI;";
    }

    // [Fact]
    // public void Test_CategoriesEmptyAtFirst()
    // {
    //   int result = Category.GetAll().Count;
    //   Assert.Equal(0, result);
    // }
    //
    // [Fact]
    // public void Test_Equal_ReturnsTrueForSameName()
    // {
    //   Category firstCategory = new Category("Household chores");
    //   Category secondCategory = new Category("Household chores");
    //   Assert.Equal(firstCategory, secondCategory);
    // }
    //
    // [Fact]
    // public void Test_Save_SavesCategroyToDatabase()
    // {
    //   Category testCategory = new Category("Household chores");
    //   testCategory.Save();
    //   List<Category> result = Category.GetAll();
    //   List<Category> testList = new List<Category>{testCategory};
    //   Assert.Equal(testList, result);
    // }
    //
    // [Fact]
    // public void Test_Save_AssignsIdToCategoryObject()
    // {
    //   Category testCategory = new Category("Household chores");
    //   testCategory.Save();
    //   Category savedCategory = Category.GetAll()[0];
    //   int result = savedCategory.GetId();
    //   int testId = testCategory.GetId();
    //   Assert.Equal(testId, result);
    // }
    //
    // [Fact]
    // public void Test_Find_FindsCategoryInDatabase()
    // {
    //   Category testCategory = new Category("Household chores");
    //   testCategory.Save();
    //   Category foundCategory = Category.Find(testCategory.GetId());
    //   Assert.Equal(testCategory, foundCategory);
    // }
    //
    // [Fact]
    // public void Test_GetItems_RetrievesAllItemsWithCategory()
    // {
    //   Category testCategory = new Category("Household chores");
    //   testCategory.Save();
    //
    //   Item firstItem = new Item("item1", testCategory.GetId());
    //   firstItem.Save();
    //   Item secondItem = new Item("item2", testCategory.GetId());
    //   secondItem.Save();
    //
    //   List<Item> testItemList = new List<Item> {firstItem, secondItem};
    //   List<Item> resultItemList = testCategory.GetItems();
    //
    //   foreach(Item item in resultItemList)
    //   {
    //     Console.WriteLine("Result Item: {0}, Id: {1}, CatId: {2}", item.GetDescription(), item.GetId(), item.GetCategoryId());
    //   }
    //   Assert.Equal(testItemList, resultItemList);
    // }

    public void Dispose()
    {
      Item.DeleteAll();
      Category.DeleteAll();
    }
  }
}
