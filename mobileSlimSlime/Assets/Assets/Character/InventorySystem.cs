using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]

public class InventorySystem : MonoBehaviour
{
    public static List<Item> items;

    public List<GameObject> iconsList=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();

        //inventory setup
        //any new item created must be added to this list
        items = new List<Item>();
        items.Add(new Item("Gold", 0, iconsList[0]));
        items.Add(new Item("Fish *",0,iconsList[1]));
        items.Add(new Item("Fish **", 0, iconsList[2]));
        items.Add(new Item("Fish ***", 0, iconsList[3]));
        items.Add(new Item("Fish ****", 0, iconsList[4]));
        items.Add(new Item("Fish *****", 0, iconsList[5]));
        items.Add(new Item("Wood *", 0, iconsList[6]));
        items.Add(new Item("Wood **", 0, iconsList[7]));
        items.Add(new Item("Wood ***", 0, iconsList[8]));
        items.Add(new Item("Wood ****", 0, iconsList[9]));
        items.Add(new Item("Wood *****", 0, iconsList[10]));
        items.Add(new Item("Iron *", 0, iconsList[11]));
        items.Add(new Item("Iron **", 0, iconsList[12]));
        items.Add(new Item("Iron ***", 0, iconsList[13]));
        items.Add(new Item("Iron ****", 0, iconsList[14]));
        items.Add(new Item("Iron *****", 0, iconsList[15]));
        items.Add(new Item("Wheat *", 0, iconsList[16]));
        items.Add(new Item("Wheat **", 0, iconsList[17]));
        items.Add(new Item("Wheat ***", 0, iconsList[18]));
        items.Add(new Item("Wheat ****", 0, iconsList[19]));
        items.Add(new Item("Wheat *****", 0, iconsList[20]));
    }

    //add item
    public static void AddItem(string name, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == name)
            {
                items[i].AddAmount(amount);
            }
        }
    }
}
