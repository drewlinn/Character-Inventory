using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Item
  {
    private int _id;
    private string _name;
    private int _sizeId;
    private int _weight;
    private int _categoryId;

    public Item(string Name, int SizeId, int Weight, int CategoryId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _sizeId = SizeId;
      _weight = Weight;
      _categoryId = CategoryId;
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
        bool nameEquality = (this.GetName() == newItem.GetName());
        bool categoryEquality = (this.GetCategoryId() == newItem.GetCategoryId());
        bool weightEquality = (this.GetWeight() == newItem.GetWeight());
        bool sizeEquality = (this.GetSizeId() == newItem.GetSizeId());
        return (nameEquality && idEquality && categoryEquality && weightEquality && sizeEquality);
      }
    }
    public string GetSizeString()
    {
      if (this._sizeId == 1)
      {
        return "small";
      }
      if (this._sizeId == 2)
      {
        return "medium";
      }
      if (this._sizeId == 3)
      {
        return "large";
      }
      return "Invalid ID!";
    }
    public string GetCategoryString()
    {
      if (this._categoryId == 1)
      {
        return "weapon";
      }
      if (this._categoryId == 2)
      {
        return "armor";
      }
      return "Invalid ID!";
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
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetWeight()
    {
      return _weight;
    }
    public void SetWeight(int newWeight)
    {
      _weight = newWeight;
    }
    public int GetSizeId()
    {
      return _sizeId;
    }
    public void SetSizeId(int newSizeId)
    {
      _sizeId = newSizeId;
    }
    public static List<Item> GetAll()
    {
      List<Item> AllItems = new List<Item>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM items;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ItemId = rdr.GetInt32(0);
        string ItemName = rdr.GetString(1);
        int ItemSizeId = rdr.GetInt32(2);
        int ItemWeight = rdr.GetInt32(3);
        int ItemCategoryId = rdr.GetInt32(4);
        Item newItem = new Item(ItemName, ItemSizeId, ItemWeight, ItemCategoryId, ItemId);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO items (name, size_id, weight, category_id) OUTPUT INSERTED.id VALUES (@ItemName, @ItemSizeId, @ItemWeight,  @ItemCategoryId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ItemName";
      nameParameter.Value = this.GetName();

      SqlParameter sizeIdParameter = new SqlParameter();
      sizeIdParameter.ParameterName = "@ItemSizeId";
      sizeIdParameter.Value = this.GetSizeId();

      SqlParameter weightParameter = new SqlParameter();
      weightParameter.ParameterName = "@ItemWeight";
      weightParameter.Value = this.GetWeight();

      SqlParameter categoryIdParameter =  new SqlParameter();
      categoryIdParameter.ParameterName = "@ItemCategoryId";
      categoryIdParameter.Value = this.GetCategoryId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(sizeIdParameter);
      cmd.Parameters.Add(weightParameter);
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

      SqlCommand cmd = new SqlCommand("SELECT * FROM items WHERE id = @ItemId;", conn);
      SqlParameter ItemIdParameter = new SqlParameter();
      ItemIdParameter.ParameterName = "@ItemId";
      ItemIdParameter.Value = id.ToString();
      cmd.Parameters.Add(ItemIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundId = 0;
      string foundName = null;
      int foundSizeId = 0;
      int foundWeight = 0;
      int foundCategoryId = 0;

      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundSizeId = rdr.GetInt32(2);
        foundWeight = rdr.GetInt32(3);
        foundCategoryId = rdr.GetInt32(4);
      }
      Item foundItem = new Item(foundName, foundSizeId, foundWeight, foundCategoryId, foundId);

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
      SqlCommand cmd = new SqlCommand("DELETE FROM items;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
