using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]

public class InventorySystem : MonoBehaviour
{
    public Dictionary<int, Item> itemList; 

    // Start is called before the first frame update
    void Start()
    {
        itemList = new Dictionary<int, Item>();

        //inventory setup
        //any new item created must be added to this list
        itemList.Add(0, new Item("Gold", 10 ,0));
        itemList.Add(1, new Item("Fish", 10, 1));
        itemList.Add(2, new Item("Fish", 10, 2));
        itemList.Add(3, new Item("Fish", 0, 3));
        itemList.Add(4, new Item("Fish", 0, 4));
        itemList.Add(5, new Item("Fish", 10, 5));
        itemList.Add(6, new Item("Wood", 10, 1));
        itemList.Add(7, new Item("Wood", 0, 2));
        itemList.Add(8, new Item("Wood",10, 3));
        itemList.Add(9, new Item("Wood", 0, 4));
        itemList.Add(10, new Item("Wood", 10, 5));
        itemList.Add(11, new Item("Iron", 0, 1));
        itemList.Add(12, new Item("Iron", 10, 2));
        itemList.Add(13, new Item("Iron", 0, 3));
        itemList.Add(14, new Item("Iron", 0, 4));
        itemList.Add(15, new Item("Iron", 0, 5));
        itemList.Add(16, new Item("Wheat", 10, 1));
        itemList.Add(17, new Item("Wheat", 0, 2));
        itemList.Add(18, new Item("Wheat", 0, 3));
        itemList.Add(19, new Item("Wheat", 10, 4));
        itemList.Add(20, new Item("Wheat", 10, 5));
    }

    //add item
    public void AddItem(int id, int amount)
    {
        itemList[id].AddAmount(amount);
    }
}
