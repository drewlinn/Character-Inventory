using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
  public class ToDoTest : IDisposable
  {
    public ToDoTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_items_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Item.GetAll().Count;
      Assert.Equal(0, result);
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

    // [Fact]
    // public void Test_Save_AssignsIdToObject()
    // {
    //   Item testItem = new Item("Mow the lawn", 1);
    //
    //   testItem.Save();
    //   Item savedItem = Item.GetAll()[0];
    //
    //   int result = savedItem.GetId();
    //   int testId = testItem.GetId();
    //
    //   Assert.Equal(testId, result);
    // }
    //
    // [Fact]
    // public void Test_Find_FindsItemInDatabase()
    // {
    //   Item testItem = new Item("Do the dishes", 1);
    //   testItem.Save();
    //
    //   Item foundItem = Item.Find(testItem.GetId());
    //
    //   Assert.Equal(testItem, foundItem);
    // }
    public void Dispose()
    {
      Item.DeleteAll();
    }
  }
}
