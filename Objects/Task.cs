using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace Inventory
{
  public class Item
  {
    private int _id;
    private string _description;
    private int _categoryId;

    public Item(string Description,int CategoryId, int Id = 0)
    {
      _description = Description;
      _categoryId = CategoryId;
      _id = Id;
    }

    public override bool Equals(System.Object otherItem)
    {
      if(!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = (this.GetId() == newItem.GetId());
        bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
        bool categoryEquality = (this.GetCategoryId() == newItem.GetCategoryId());
        return (descriptionEquality && idEquality && categoryEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public int GetCategoryId()
    {
      return _categoryId;
    }
    public void SetCategoryId(int newCategoryId)
    {
      _categoryId = newCategoryId;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      List<Item> AllItems = new List<Item>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Items;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ItemId = rdr.GetInt32(0);
        string ItemDescription = rdr.GetString(1);
        int ItemCategoryId = rdr.GetInt32(2);
        Item newItem = new Item(ItemDescription, ItemCategoryId, ItemId);
        AllItems.Add(newItem);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllItems;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Items (description, category_id) OUTPUT INSERTED.id VALUES (@ItemDescription, @ItemCategoryId);", conn);

      SqlParameter descriptionParameter = new SqlParameter();
      descriptionParameter.ParameterName = "@ItemDescription";
      descriptionParameter.Value = this.GetDescription();

      SqlParameter categoryIdParameter =  new SqlParameter();
      categoryIdParameter.ParameterName = "@ItemCategoryId";
      categoryIdParameter.Value = this.GetCategoryId();

      cmd.Parameters.Add(descriptionParameter);
      cmd.Parameters.Add(categoryIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Item Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Items WHERE id = @ItemId;", conn);
      SqlParameter ItemIdParameter = new SqlParameter();
      ItemIdParameter.ParameterName = "@ItemId";
      ItemIdParameter.Value = id.ToString();
      cmd.Parameters.Add(ItemIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundItemId = 0;
      string foundItemDescription = null;
      int foundItemCategoryId = 0;

      while(rdr.Read())
      {
        foundItemId = rdr.GetInt32(0);
        foundItemDescription = rdr.GetString(1);
        foundItemCategoryId = rdr.GetInt32(2);
      }
      Item foundItem = new Item(foundItemDescription, foundItemCategoryId, foundItemId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundItem;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM Items;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
