using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Weapon
  {
    private int _id;
    private string _name;
    private string _type;
    private string _material;
    private int _sharpness;
    private int _weight;

    public Weapon(string name, string type, string material, int weight, int sharpness, int id = 0)
    {
      _id = id;
      _name = name;
      _type = type;
      _material = material;
      _weight = weight;
      _sharpness = sharpness;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetType()
    {
      return _type;
    }
    public void SetType(string newType)
    {
      _type = newType;
    }
    public string GetMaterial()
    {
      return _material;
    }
    public void SetMaterial(string newMaterial)
    {
      _material = newMaterial;
    }
    public int GetSharpness()
    {
      return _sharpness;
    }
    public void SetSharpness(int newSharpness)
    {
      _sharpness = newSharpness;
    }
    public int GetWeight()
    {
      return _weight;
    }
    public void SetWeight(int newWeight)
    {
      _weight = newWeight;
    }

    public override bool Equals(System.Object otherWeapon)
    {
      if(!(otherWeapon is Weapon))
      {
        return false;
      }
      else
      {
        Weapon newWeapon = (Weapon) otherWeapon;
        bool idEquality = (this.GetId() == newWeapon.GetId());
        bool nameEquality = (this.GetName() == newWeapon.GetName());
        bool typeEquality = (this.GetType() == newWeapon.GetType());
        bool materialEquality = (this.GetMaterial() == newWeapon.GetMaterial());
        bool sharpnessEquality = (this.GetSharpness() == newWeapon.GetSharpness());
        bool weightEquality = (this.GetWeight() == newWeapon.GetWeight());
        return (idEquality && nameEquality && typeEquality && materialEquality && sharpnessEquality && weightEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
