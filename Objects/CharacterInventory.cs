using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Inventory
  {
    private int _id;
    private string _jewelry;
    private string _head;
    private string _clothing;
    private string _armor;
    private string _hands;
    private string _pants;
    private string _feet;
    private string _equipment;

    public Inventory(string jewelry, string head, string clothing, string armor, string hands, string feet, string equipment, int id = 0)
    {
      _id = id;
      _jewelry = jewelry;
      _head = head;
      _clothing = clothing;
      _armor = armor;
      _hands = hands:
      _feet = feet;
      _equipment = equipment;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetJewelry()
    {
      return _jewelry;
    }
    public void SetJewelry(string newJewelry)
    {
      _jewelry = newJewelry;
    }
    public string GetHead()
    {
      return _head;
    }
    public void SetHead(string newHead)
    {
      _head = newHead;
    }
    public string GetClothing()
    {
      return _clothing;
    }
    public void SetClothing(string newClothing)
    {
      _clothing = newClothing;
    }
    public string GetArmor()
    {
      return _armor;
    }
    public void SetArmor(string newArmor)
    {
      _armor = newArmor;
    }
    public string GetHands()
    {
      return _hands;
    }
    public void SetHands(string newHands)
    {
      _hands = newHands;
    }
    public string GetFeet()
    {
      return _feet;
    }
    public void SetFeet(string newFeet)
    {
      _feet = newFeet;
    }
    public string GetEquipment()
    {
      return _equipment;
    }
    public void SetEquipment(string newEquipment)
    {
      _equipment = newEquipment;
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
        bool headEquality = (this.GetHead() == newInventory.GetHead());
        bool clothingEquality = (this.GetClothing() == newInventory.GetClothing());
        bool armorEquality = (this.GetArmor() == newInventory.GetArmor());
        bool handsEquality = (this.GetHands() == newInventory.GetHands());
        bool feetEquality = (this.GetFeet() == newInventory.GetFeet());
        bool equipmentEquality = (this.GetEquipment() == newInventory.GetEquipment());
        return (idEquality && headEquality && clothingEquality && armorEquality && handsEquality && feetEquality && equipmentEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
