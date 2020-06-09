using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    private string _name;
    private int _amount,_rarity;

    public Item(string name)
    {
        _name = name;
        _amount = 0;
        _rarity = 0;
    }
    public Item(string name, int amount)
    {
        _name = name;
        _amount = amount;
        _rarity = 0;
    }
    public Item(string name, int amount,int rarity)
    {
        _name = name;
        _amount = amount;
        _rarity = rarity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetBaseName()
    {
        return _name;
    }
    public string GetName()
    {
        if (_rarity == 0) return _name;
        else return _name+_rarity;
    }
    public void AddAmount(int amount)
    {
        _amount += amount;
    }
    public void TakeAmount(int amount)
    {
        _amount -= amount;
    }
    public int GetAmount()
    {
        return _amount;
    }
    public int GetRarity()
    {
        return _rarity;
    }
}
