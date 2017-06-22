using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Inventory
  {
    private int _id;
    private string _head;
    private string _face;
    private string _back;
    private string _shirt;
    private string _chest;
    private string _hands;
    private string _pants;
    private string _legs;
    private string _feet;
    private string _slot1;
    private string _slot2;
    private string _slot3;
    private string _slot4;
    private string _slot5;
    private string _slot6;
    private string _slot7;
    private string _slot8;

    public Inventory(string head, string face, string back, string shirt, string chest, string hands, string pants, string legs, string feet, string slot1, string slot2, string slot3, string slot4, string slot5, string slot6, string slot7, string slot8, int id = 0)
    {
      _id = id;
      _head = head;
      _face = face;
      _back = back;
      _shirt = shirt;
      _chest = chest;
      _hands = hands:
      _pants = pants;
      _legs = legs;
      _feet = feet;
      _slot1 = slot1;
      _slot2 = slot2;
      _slot3 = slot3;
      _slot4 = slot4;
      _slot5 = slot5;
      _slot6 = slot6;
      _slot7 = slot7;
      _slot8 = slot8;
    }
    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public int GetHead()
    {
      return _head;
    }
    public void SetHead(int newHead)
    {
      _head = newHead;
    }
    public int GetFace()
    {
      return _face;
    }
    public void SetFace(int newFace)
    {
      _face = newFace;
    }
    public int GetBack()
    {
      return _back;
    }
    public void SetBack(int newBack)
    {
      _back = newBack;
    }
    public int GetShirt()
    {
      return _shirt;
    }
    public void SetShirt(int newShirt)
    {
      _shirt = newShirt;
    }
    public int GetChest()
    {
      return _chest;
    }
    public void SetChest(int newChest)
    {
      _chest = newChest;
    }
    public int GetHands()
    {
      return _hands;
    }
    public void SetHands(int newHands)
    {
      _hands = newHands;
    }
    public int GetPants()
    {
      return _pants;
    }
    public void SetPants(int newPants)
    {
      _pants = newPants;
    }
    public int GetLegs()
    {
      return _legs;
    }
    public void SetLegs(int newLegs)
    {
      _legs = newLegs;
    }
    public int GetFeet()
    {
      return _feet;
    }
    public void SetFeet(int newFeet)
    {
      _feet = newFeet;
    }
    public int GetSlot1()
    {
      return _slot1;
    }
    public void SetSlot1(int newSlot1)
    {
      _slot1 = newSlot1;
    }
    public int GetSlot2()
    {
      return _slot2;
    }
    public void SetSlot2(int newSlot2)
    {
      _slot2 = newSlot2;
    }
    public int GetSlot3()
    {
      return _slot3;
    }
    public void SetSlot3(int newSlot3)
    {
      _slot3 = newSlot3;
    }
    public int GetSlot4()
    {
      return _slot4;
    }
    public void SetSlot4(int newSlot4)
    {
      _slot4 = newSlot4;
    }
    public int GetSlot5()
    {
      return _slot5;
    }
    public void SetSlot5(int newSlot5)
    {
      _slot5 = newSlot5;
    }
    public int GetSlot6()
    {
      return _slot6;
    }
    public void SetSlot6(int newSlot6)
    {
      _slot6 = newSlot6;
    }
    public int GetSlot7()
    {
      return _slot7;
    }
    public void SetSlot7(int newSlot7)
    {
      _slot7 = newSlot7;
    }
    public int GetSlot8()
    {
      return _slot8;
    }
    public void SetSlot8(int newSlot8)
    {
      _slot8 = newSlot8;
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
        bool faceEquality = (this.GetFace() == newInventory.GetFace());
        bool backEquality = (this.GetBack() == newInventory.GetBack());
        bool shirtEquality = (this.GetShirt() == newInventory.GetShirt());
        bool chestEquality = (this.GetChest() == newInventory.GetChest());
        bool handsEquality = (this.GetHands() == newInventory.GetHands());
        bool pantsEquality = (this.GetPants() == newInventory.GetPants());
        bool legsEquality = (this.GetLegs() == newInventory.GetLegs());
        bool feetEquality = (this.GetFeet() == newInventory.GetFeet());
        bool slot1Equality = (this.GetSlot1() == newInventory.GetSlot1());
        bool slot2Equality = (this.GetSlot2() == newInventory.GetSlot2());
        bool slot3Equality = (this.GetSlot3() == newInventory.GetSlot3());
        bool slot4Equality = (this.GetSlot4() == newInventory.GetSlot4());
        bool slot5Equality = (this.GetSlot5() == newInventory.GetSlot5());
        bool slot6Equality = (this.GetSlot6() == newInventory.GetSlot6());
        bool slot7Equality = (this.GetSlot7() == newInventory.GetSlot7());
        bool slot8Equality = (this.GetSlot8() == newInventory.GetSlot8());
        return (idEquality && headEquality && faceEquality && backEqualityshirtEquality && chestEquality && handsEquality && pantsEquality && legsEquality && feetEquality && slot1Equality && slot2Equality && slot3Equality && slot4Equality && slot5Equality && slot6Equality && slot7Equality && slot8Equality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
