using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CharacterInventory.Objects
{
  public class Equipment
  {
    private int _id;
    private string _slot1;
    private string _slot2;
    private string _slot3;
    private string _slot4;
    private string _slot5;
    private string _slot6;
    private string _slot7;
    private string _slot8;


    public Equipment(string slot1, string slot2, string slot3, string slot4, string slot5, string slot6, string slot7, string slot8, int id = 0)
    {
      _id = id;
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
    public string GetSlot1()
    {
      return _slot1;
    }
    public void SetSlot1(string newSlot1)
    {
      _slot1 = newSlot1;
    }
    public string GetSlot2()
    {
      return _slot2;
    }
    public void SetSlot2(string newSlot2)
    {
      _slot2 = newSlot2;
    }
    public string GetSlot3()
    {
      return _slot3;
    }
    public void SetSlot3(string newSlot3)
    {
      _slot3 = newSlot3;
    }
    public string GetSlot4()
    {
      return _slot4;
    }
    public void SetSlot4(string newSlot4)
    {
      _slot4 = newSlot4;
    }
    public string GetSlot5()
    {
      return _slot5;
    }
    public void SetSlot5(string newSlot5)
    {
      _slot5 = newSlot5;
    }
    public string GetSlot6()
    {
      return _slot6;
    }
    public void SetSlot6(string newSlot6)
    {
      _slot6 = newSlot6;
    }
    public string GetSlot7()
    {
      return _slot7;
    }
    public void SetSlot7(string newSlot7)
    {
      _slot7 = newSlot7;
    }
    public string GetSlot8()
    {
      return _slot8;
    }
    public void SetSlot8(string newSlot8)
    {
      _slot8 = newSlot8;
    }

    public override bool Equals(System.Object otherEquipment)
    {
      if(!(otherEquipment is Equipment))
      {
        return false;
      }
      else
      {
        Equipment newEquipment = (Equipment) otherEquipment;
        bool idEquality = (this.GetId() == newEquipment.GetId());
        bool slot1Equality = (this.GetSlot1() == newInventory.GetSlot1());
        bool slot2Equality = (this.GetSlot2() == newInventory.GetSlot2());
        bool slot3Equality = (this.GetSlot3() == newInventory.GetSlot3());
        bool slot4Equality = (this.GetSlot4() == newInventory.GetSlot4());
        bool slot5Equality = (this.GetSlot5() == newInventory.GetSlot5());
        bool slot6Equality = (this.GetSlot6() == newInventory.GetSlot6());
        bool slot7Equality = (this.GetSlot7() == newInventory.GetSlot7());
        bool slot8Equality = (this.GetSlot8() == newInventory.GetSlot8());
        return (idEquality && slot1Equality && slot2Equality && slot3Equality && slot4Equality && slot5Equality && slot6Equality && slot7Equality && slot8Equality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetHashCode();
    }
  }
}
