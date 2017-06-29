using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Clothing
  {
    private int _id;
    private string _cloak;
    private string _shirt;
    private string _pants;

    public Clothing(string cloak, string shirt, string pants, int id = 0)
    {
      _id = id;
      _cloak = cloak;
      _shirt = shirt;
      _pants = pants;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetCloak()
    {
      return _cloak;
    }
    public void SetCloak(string newCloak)
    {
      _cloak = newCloak;
    }
    public string GetShirt()
    {
      return _shirt;
    }
    public void SetShirt(string newShirt)
    {
      _shirt = newShirt;
    }
    public string GetPants()
    {
      return _pants;
    }
    public void SetPants(string newPants)
    {
      _pants = newPants;
    }

    public override bool Equals(System.Object otherClothing)
    {
      if(!(otherClothing is Clothing))
      {
        return false;
      }
      else
      {
        Clothing newClothing = (Clothing) otherClothing;
        bool idEquality = (this.GetId() == newClothing.GetId());
        bool cloakEquality = (this.GetCloak() == newClothing.GetCloak());
        bool shirtEquality = (this.GetShirt() == newClothing.GetShirt());
        bool pantsEquality = (this.GetPants() == newClothing.GetPants());
        return (idEquality && cloakEquality && shirtEquality && pantsEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
