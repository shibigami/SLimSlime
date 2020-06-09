using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyItem : MonoBehaviour
{
    private Item _item;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetItem(Item item)
    {
        _item = new Item(item.GetBaseName(), item.GetAmount(), item.GetRarity());
    }
    public void AddToPot()
    {
        GameObject.FindGameObjectWithTag("AlchemyPanel").GetComponent<AlchemySystem>().AddToPot(_item);
    }
    public int GetAmount()
    {
        return _item.GetAmount(); 
    }
    public Item GetItem()
    {
        return _item;
    }
}