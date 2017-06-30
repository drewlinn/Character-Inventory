using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Inventory
  {
    private int _id;
    private int _hardness;
    private int _brittleness;
    private int _density;

    public Inventory(int hardness, int brittleness, int density, int id = 0)
    {
      _id = id;
      _hardness = hardness;
      _brittleness = brittleness;
      _density = density;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public int GetHardness()
    {
      return _hardness;
    }
    public void SetHardness(int newHardness)
    {
      _hardness = newHardness;
    }
    public int GetBrittleness()
    {
      return _brittleness;
    }
    public void SetBrittleness(int newBrittleness)
    {
      _brittleness = newBrittleness;
    }
    public int GetDensity()
    {
      return _density;
    }
    public void SetDensity(int newDensity)
    {
      _density = newDensity;
    }

    public override bool Equals(System.Object otherInventory)
    {
      if(!(otherInventory is Inventory))
      {
        return false;
      }
      else
      {
        Inventory newInventory = (Inventory) otherInventory;
        bool idEquality = (this.GetId() == newInventory.GetId());
        bool hardnessEquality = (this.GetHardness() == newInventory.GetHardness());
        bool brittlenessEquality = (this.GetBrittleness() == newInventory.GetBrittleness());
        bool densityEquality = (this.GetDensity() == newInventory.GetDensity());
        return (idEquality && hardnessEquality && brittlenessEquality && densityEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
