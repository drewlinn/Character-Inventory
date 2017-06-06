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

    [Fact]
    public void Test_CategoriesEmptyAtFirst()
    {
      int result = Category.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Category firstCategory = new Category("Household chores");
      Category secondCategory = new Category("Household chores");
      Assert.Equal(firstCategory, secondCategory);
    }

    [Fact]
    public void Test_Save_SavesCategroyToDatabase()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      List<Category> result = Category.GetAll();
      List<Category> testList = new List<Category>{testCategory};
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToCategoryObject()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      Category savedCategory = Category.GetAll()[0];
      int result = savedCategory.GetId();
      int testId = testCategory.GetId();
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsCategoryInDatabase()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();
      Category foundCategory = Category.Find(testCategory.GetId());
      Assert.Equal(testCategory, foundCategory);
    }

    [Fact]
    public void Test_GetTasks_RetrievesAllTasksWithCategory()
    {
      Category testCategory = new Category("Household chores");
      testCategory.Save();

      Task firstTask = new Task("task1", testCategory.GetId());
      firstTask.Save();
      Task secondTask = new Task("task2", testCategory.GetId());
      secondTask.Save();

      List<Task> testTaskList = new List<Task> {firstTask, secondTask};
      List<Task> resultTaskList = testCategory.GetTasks();

      foreach(Task task in resultTaskList)
      {
        Console.WriteLine("Result Task: {0}, Id: {1}, CatId: {2}", task.GetDescription(), task.GetId(), task.GetCategoryId());
      }
      Assert.Equal(testTaskList, resultTaskList);
    }

    public void Dispose()
    {
      Task.DeleteAll();
      Category.DeleteAll();
    }
  }
}
