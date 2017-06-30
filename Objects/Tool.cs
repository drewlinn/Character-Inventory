using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Tool
  {
    private int _id;
    private string _name;
    private int _sizeId;
    private int _weight;
    private int _categoryId;

    public Tool(string Name, int SizeId, int Weight, int CategoryId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _sizeId = SizeId;
      _weight = Weight;
      _categoryId = CategoryId;
    }

    public override bool Equals(System.Object otherTool)
    {
      if(!(otherTool is Tool))
      {
        return false;
      }
      else
      {
        Tool newTool = (Tool) otherTool;
        bool idEquality = (this.GetId() == newTool.GetId());
        bool nameEquality = (this.GetName() == newTool.GetName());
        bool categoryEquality = (this.GetCategoryId() == newTool.GetCategoryId());
        bool weightEquality = (this.GetWeight() == newTool.GetWeight());
        bool sizeEquality = (this.GetSizeId() == newTool.GetSizeId());
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
    public static List<Tool> GetAll()
    {
      List<Tool> AllTools = new List<Tool>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tools;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ToolId = rdr.GetInt32(0);
        string ToolName = rdr.GetString(1);
        int ToolSizeId = rdr.GetInt32(2);
        int ToolWeight = rdr.GetInt32(3);
        int ToolCategoryId = rdr.GetInt32(4);
        Tool newTool = new Tool(ToolName, ToolSizeId, ToolWeight, ToolCategoryId, ToolId);
        AllTools.Add(newTool);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllTools;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO tools (name, size_id, weight, category_id) OUTPUT INSERTED.id VALUES (@ToolName, @ToolSizeId, @ToolWeight,  @ToolCategoryId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ToolName";
      nameParameter.Value = this.GetName();

      SqlParameter sizeIdParameter = new SqlParameter();
      sizeIdParameter.ParameterName = "@ToolSizeId";
      sizeIdParameter.Value = this.GetSizeId();

      SqlParameter weightParameter = new SqlParameter();
      weightParameter.ParameterName = "@ToolWeight";
      weightParameter.Value = this.GetWeight();

      SqlParameter categoryIdParameter =  new SqlParameter();
      categoryIdParameter.ParameterName = "@ToolCategoryId";
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

    public static Tool Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tools WHERE id = @ToolId;", conn);
      SqlParameter ToolIdParameter = new SqlParameter();
      ToolIdParameter.ParameterName = "@ToolId";
      ToolIdParameter.Value = id.ToString();
      cmd.Parameters.Add(ToolIdParameter);
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
      Tool foundTool = new Tool(foundName, foundSizeId, foundWeight, foundCategoryId, foundId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundTool;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM tools;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
