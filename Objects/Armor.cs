using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Armor
  {
    private int _id;
    private string _name;
    private int _sizeId;
    private int _weight;
    private int _categoryId;

    public Armor(string Name, int SizeId, int Weight, int CategoryId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _sizeId = SizeId;
      _weight = Weight;
      _categoryId = CategoryId;
    }

    public override bool Equals(System.Object otherArmor)
    {
      if(!(otherArmor is Armor))
      {
        return false;
      }
      else
      {
        Armor newArmor = (Armor) otherArmor;
        bool idEquality = (this.GetId() == newArmor.GetId());
        bool nameEquality = (this.GetName() == newArmor.GetName());
        bool categoryEquality = (this.GetCategoryId() == newArmor.GetCategoryId());
        bool weightEquality = (this.GetWeight() == newArmor.GetWeight());
        bool sizeEquality = (this.GetSizeId() == newArmor.GetSizeId());
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
    public static List<Armor> GetAll()
    {
      List<Armor> AllArmors = new List<Armor>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM armors;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int ArmorId = rdr.GetInt32(0);
        string ArmorName = rdr.GetString(1);
        int ArmorSizeId = rdr.GetInt32(2);
        int ArmorWeight = rdr.GetInt32(3);
        int ArmorCategoryId = rdr.GetInt32(4);
        Armor newArmor = new Armor(ArmorName, ArmorSizeId, ArmorWeight, ArmorCategoryId, ArmorId);
        AllArmors.Add(newArmor);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllArmors;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO armors (name, size_id, weight, category_id) OUTPUT INSERTED.id VALUES (@ArmorName, @ArmorSizeId, @ArmorWeight,  @ArmorCategoryId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ArmorName";
      nameParameter.Value = this.GetName();

      SqlParameter sizeIdParameter = new SqlParameter();
      sizeIdParameter.ParameterName = "@ArmorSizeId";
      sizeIdParameter.Value = this.GetSizeId();

      SqlParameter weightParameter = new SqlParameter();
      weightParameter.ParameterName = "@ArmorWeight";
      weightParameter.Value = this.GetWeight();

      SqlParameter categoryIdParameter =  new SqlParameter();
      categoryIdParameter.ParameterName = "@ArmorCategoryId";
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

    public static Armor Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM armors WHERE id = @ArmorId;", conn);
      SqlParameter ArmorIdParameter = new SqlParameter();
      ArmorIdParameter.ParameterName = "@ArmorId";
      ArmorIdParameter.Value = id.ToString();
      cmd.Parameters.Add(ArmorIdParameter);
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
      Armor foundArmor = new Armor(foundName, foundSizeId, foundWeight, foundCategoryId, foundId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return foundArmor;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM armors;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
