using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using CharacterInventory.Objects;

namespace CharacterInventory
{
  [Collection("CharacterInventory")]
  public class ItemCategoryTest : IDisposable
  {
    public ItemCategoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=character_inventory_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_CategoriesEmptyAtFirst()
    {
      int result = Category.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Category firstCategory = new Category("Talismans");
      Category secondCategory = new Category("Talismans");
      Assert.Equal(firstCategory, secondCategory);
    }

    [Fact]
    public void Test_Save_SavesCategoryToDatabase()
    {
      Category testCategory = new Category("Weapons");
      testCategory.Save();
      List<Category> result = Category.GetAll();
      List<Category> testList = new List<Category>{testCategory};
      Assert.Equal(testList, result);
    }

    // [Fact]
    // public void Test_Save_AssignsIdToCategoryObject()
    // {
    //   Category testCategory = new Category("Armor");
    //   testCategory.Save();
    //   Category savedCategory = Category.GetAll()[0];
    //   int result = savedCategory.GetId();
    //   int testId = testCategory.GetId();
    //   Assert.Equal(testId, result);
    // }

    [Fact]
    public void Test_Find_FindsCategoryInDatabase()
    {
      Category testCategory = new Category("More Weapons");
      testCategory.Save();
      Category foundCategory = Category.Find(testCategory.GetId());
      Assert.Equal(testCategory, foundCategory);
    }

    [Fact]
    public void Test_GetItems_RetrievesAllItemsWithCategory()
    {
      Category testCategory = new Category("Clothing");
      testCategory.Save();

      Item firstItem = new Item("A peasant hat", 1, 2, testCategory.GetId());
      firstItem.Save();
      Item secondItem = new Item("some peasant pants", 2, 3, testCategory.GetId());
      secondItem.Save();

      List<Item> testItemList = new List<Item> {firstItem, secondItem};
      List<Item> resultItemList = testCategory.GetItems();

      // foreach(Item item in resultItemList)
      // {
      //   Console.WriteLine("Result Item: {0}, SizeId: {1}, weight: {2}, catId: {3}, id: {4}", item.GetName(), item.GetSizeId(), item.GetWeight(), item.GetCategoryId(), item.GetId());
      // }
      Assert.Equal(testItemList, resultItemList);
    }

    public void Dispose()
    {
      Category.DeleteAll();
      Item.DeleteAll();
    }
  }
}
