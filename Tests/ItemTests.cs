using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
  public class ToDoTest : IDisposable
  {
    // string testString = "Hello World.";
    public ToDoTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_items_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Item.GetAll().Count;
      Assert.Equal(0, result);
      // Console.WriteLine(testString);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      Item firstItem = new Item("Short sword", 2, 4, 1);
      Item secondItem = new Item("Short sword", 2, 4, 1);

      Assert.Equal(firstItem, secondItem);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Item testItem = new Item("Long sword", 2, 5, 1);

      testItem.Save();
      List<Item> result = Item.GetAll();
      List<Item> testList = new List<Item>{testItem};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      Item testItem = new Item("Great Helm", 1, 3, 2);

      testItem.Save();
      Item savedItem = Item.GetAll()[0];

      int result = savedItem.GetId();
      int testId = testItem.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsItemInDatabase()
    {
      Item testItem = new Item("Plate Mail", 3, 15, 2);
      testItem.Save();

      Item foundItem = Item.Find(testItem.GetId());

      Assert.Equal(testItem, foundItem);
    }
    public void Dispose()
    {
      Item.DeleteAll();
    }
  }
}
