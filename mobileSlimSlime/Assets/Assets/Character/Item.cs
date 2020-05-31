using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    private string _name;
    private int _amount;
    private GameObject _icon;

    public Item(string name)
    {
        _name = name;
    }

    public Item(string name, int amount)
    {
        _name = name;
        _amount = amount;
    }

    public Item(string name, int amount, GameObject icon)
    {
        _name = name;
        _amount = amount;
        _icon = icon;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetName()
    {
        return _name;
    }

    public void AddAmount(int amount)
    {
        _amount += amount;
    }

    public int GetAmount()
    {
        return _amount;
    }

    public GameObject GetIcon()
    {
        return _icon;
    }
}
