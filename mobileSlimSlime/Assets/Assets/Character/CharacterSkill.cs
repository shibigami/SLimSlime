using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill
{
    //basic info
    private string _name;
    private string _effectDescription;
    //each level increases 1 point of int based values and 0.1f of float based values
    private int _level;
    private int _maxLevel;

    //exp info
    private int currentExp;
    private int expPerLevel;

    //list of possible things skills might influence
    public DictionaryHolder statsBase,statsPerLevel,statsCurrent;

    //used for storing stat increments
    public DictionaryHolder.element _element;

    //used for calculations
    private int totalDamage, percentDamage;

    //passive or active
    public bool _passive,_unlocked,_alchemy;

    //unlock requirements
    public Requirements unlockRequirements;

    //cost in case active
    public int spCost;

    //in case of active, set element combination
    public string comboStr="";
    
    //constructers
    public CharacterSkill(string name, string effectDescription, int expToLevelUp,int maxLvl, DictionaryHolder.element element)
    {
        unlockRequirements = new Requirements();

        statsBase = new DictionaryHolder();
        statsPerLevel = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();

        _name = name;
        _effectDescription = effectDescription;
        _level = 0;
        _maxLevel = maxLvl;
        expPerLevel = expToLevelUp;
        currentExp = 0;
        _passive = true;
        spCost = 0;
        if (_level <= 0)
        {
            _unlocked = false;
        }
        else
        {
            _unlocked = true;
        }
        AdjustSkillBonus();
        _element=element;

        _alchemy = false;
    }
    public CharacterSkill(string name, string effectDescription, int level, int expToLevelUp,int maxLvl, DictionaryHolder.element element)
    {
        unlockRequirements = new Requirements();

        statsBase = new DictionaryHolder();
        statsPerLevel = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();

        _name = name;
        _effectDescription = effectDescription;
        _level = level;
        _maxLevel = maxLvl;
        expPerLevel = expToLevelUp;
        currentExp = 0;
        _passive = true;
        spCost = 0;
        if (_level <= 0)
        {
            _unlocked = false;
        }
        else
        {
            _unlocked = true;
        }
        AdjustSkillBonus();
        _element=element;

        _alchemy = false;
    }
    public CharacterSkill(string name, string effectDescription, int expToLevelUp,int maxLvl, int spcost, DictionaryHolder.element element,string _comboString)
    {
        unlockRequirements = new Requirements();

        statsBase = new DictionaryHolder();
        statsPerLevel = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();

        _name = name;
        _effectDescription = effectDescription;
        _level = 0;
        _maxLevel = maxLvl;
        expPerLevel = expToLevelUp;
        currentExp = 0;
        _passive = false;
        spCost = spcost;
        if (_level <= 0)
        {
            _unlocked = false;
        }
        else
        {
            _unlocked = true;
        }
        AdjustSkillBonus();
        _element=element;
        comboStr = _comboString;

        _alchemy = false;
    }
    public CharacterSkill(string name, string effectDescription, int level, int expToLevelUp,int maxLvl, int spcost, DictionaryHolder.element element,string _comboString)
    {
        unlockRequirements = new Requirements();

        statsBase = new DictionaryHolder();
        statsPerLevel = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();

        _name = name;
        _effectDescription = effectDescription;
        _level = level;
        _maxLevel = maxLvl;
        expPerLevel = expToLevelUp;
        currentExp = 0;
        _passive = false;
        spCost = spcost;
        if (_level <= 0)
        {
            _unlocked = false;
        }
        else
        {
            _unlocked = true;
        }
        AdjustSkillBonus();
        _element=element;
        comboStr = _comboString;

        _alchemy = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        statsBase = new DictionaryHolder();
        statsPerLevel = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();
    }

    // Update is called once per frame
    void Update()
    {
        //triggers passive switch
        if (comboStr == "") _passive = true;
        else _passive = false;

        //triggers unlock switch
        if (_level <= 0) _unlocked = false;
        else _unlocked = true;

        //adjusts skill when max _lvl
        if (_level >= _maxLevel) { _level = _maxLevel; expPerLevel = 0; }
    }

    public string Name()
    {
        return _name;
    }
    public string EffectDescription()
    {
        return _effectDescription;
    }
    public int CurrentLevel()
    {
        return _level;
    }
    public int MaxLevel()
    {
        return _maxLevel;
    }
    public void AddSkillStat(DictionaryHolder.statType statType, DictionaryHolder.element element, int _perLevelValue)
    {
        //save
        statsPerLevel.ChangeStat(statType, element, _perLevelValue);

        //adjust
        AdjustSkillBonus();
    }
    public void AddSkillStat(DictionaryHolder.statType baseStat, int _perLevelValue)
    {
        //save
        statsPerLevel.ChangeStat(baseStat, _perLevelValue);

        //adjust
        AdjustSkillBonus();
    }
    private void AdjustSkillBonus()
    {
        //regular skill increase
        if (_level < _maxLevel) statsCurrent = DictionaryHolder.MergeStats(statsBase, statsPerLevel, _level);
        //max level bonus increase (current bonus x2)
        else statsCurrent = DictionaryHolder.MergeStats(statsBase, DictionaryHolder.MergeStats(statsPerLevel, statsPerLevel),_maxLevel);
    }
    public int Damage(DictionaryHolder.element element)
    {
        totalDamage = 0;
        percentDamage = 0;

        //add damage:

        //fixed
        statsCurrent.fixedDamageStats.TryGetValue(element, out totalDamage);

        //percent
        statsCurrent.percentDamageStats.TryGetValue(element, out percentDamage);

        //adjust percentage increase
        totalDamage = Mathf.RoundToInt((totalDamage * percentDamage) / 100);

        return totalDamage;
    }
    public bool ChangeExp(int exp)
    {
        if (exp > 0)
        {
            if (_level < _maxLevel)
            {
                //add exp
                currentExp += exp;
                //level up until it cant anymore
                if (currentExp >= expPerLevel)
                {
                    while (currentExp >= expPerLevel)
                    {
                        _level=Mathf.Clamp(_level+1,0,_maxLevel);
                        //take level exp from pool
                        currentExp -= expPerLevel;

                        AdjustSkillBonus();

                        //unlock
                        if (_level <= 0)
                        {
                            _unlocked = false;
                        }
                        else
                        {
                            _unlocked = true;
                        }
                    }
                }
            }
            return true;
        }
        else
        {
            //take exp
            if (currentExp + exp >= 0)
            {
                currentExp += exp;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public int CurrentExp()
    {
        return currentExp;
    }
    public int LevelExp()
    {
        return expPerLevel;
    }
    public void SetCharacterSkill(CharacterSkill charSkill)
    {
        //basic info
        _name = charSkill.Name();
        _effectDescription = charSkill.EffectDescription();
        //each level increases 1 point of int based values and 0.1f of float based values
        _level = charSkill.CurrentLevel();

        //exp info
        currentExp = charSkill.currentExp;
        expPerLevel = charSkill.expPerLevel;

        //list of possible things skills might influence
        statsBase = charSkill.statsBase;
        statsPerLevel = charSkill.statsPerLevel;
        statsCurrent = charSkill.statsCurrent;

        //base stats
        statsBase.health = charSkill.statsBase.health;
        statsBase.expPool = charSkill.statsBase.expPool;
        statsBase.actionPoints = charSkill.statsBase.actionPoints;
        statsBase.slime = charSkill.statsBase.slime;
        statsBase.elementSlots = charSkill.statsBase.elementSlots;

        //passive or active
        _passive = charSkill._passive;
        _unlocked = charSkill._unlocked;

        //cost in case active
        spCost = charSkill.spCost;

        //in case of active set element combination
        comboStr = charSkill.comboStr;

        //element
        _element = charSkill._element;
    }
    public void Unlock()
    {
        if (CurrentLevel() == 0) { _level = 1; _unlocked = true; }
    }
}
