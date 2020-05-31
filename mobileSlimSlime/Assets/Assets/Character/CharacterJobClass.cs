using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJobClass
{
    private string _name;
    private int _lvl, _exp,_expTotal,_expPerLevel;

    public CharacterJobClass(string name,int perLevelExp)
    {
        _name = name;
        _lvl = 1;
        _exp = 0;
        _expPerLevel = perLevelExp;
    }

    public CharacterJobClass(string name,int lvl,int perLevelExp)
    {
        _name = name;
        _lvl = lvl;
        _exp = 0;
        _expPerLevel = perLevelExp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(int amount)
    {
        _exp += amount;
        _expTotal += amount;
        if (_exp >= _lvl * _expPerLevel)
        {
            _lvl++;
            _exp = _expTotal-(_lvl-1)*_expPerLevel;
        }
    }
    public int GetLevel()
    {
        return _lvl;
    }
    public int GetExp()
    {
        return _exp;
    }
    public int GetExpTotal()
    {
        return _expTotal;
    }
    public int GetExpToLevel()
    {
        return _lvl * _expPerLevel;
    }
}
