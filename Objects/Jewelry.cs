using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Jewelry
  {
    private int _id;
    private string _necklace;
    private string _earring;
    private string _ring;

    public Jewelry(string necklace, string earring, string ring, int id = 0)
    {
      _id = id;
      _necklace = necklace;
      _earring = earring;
      _ring = ring;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetNecklace()
    {
      return _necklace;
    }
    public void SetNecklace(string newNecklace)
    {
      _necklace = newNecklace;
    }
    public string GetEarring()
    {
      return _earring;
    }
    public void SetEarring(string newEarring)
    {
      _earring = newEarring;
    }
    public string GetRing()
    {
      return _ring;
    }
    public void SetRing(string newRing)
    {
      _ring = newRing;
    }

    public override bool Equals(System.Object otherJewelry)
    {
      if(!(otherJewelry is Jewelry))
      {
        return false;
      }
      else
      {
        Jewelry newJewelry = (Jewelry) otherJewelry;
        bool idEquality = (this.GetId() == newJewelry.GetId());
        bool necklaceEquality = (this.GetNecklace() == newJewelry.GetNecklace());
        bool earringEquality = (this.GetEarring() == newJewelry.GetEarring());
        bool ringEquality = (this.GetRing() == newJewelry.GetRing());
        return (idEquality && necklaceEquality && earringEquality && ringEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
