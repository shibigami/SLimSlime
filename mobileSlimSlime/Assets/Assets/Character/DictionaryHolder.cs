using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryHolder
{
    public Dictionary<element, int> fixedDamageStats, fixedResStats, percentDamageStats;
    public int health, expPool, actionPoints, slime, elementSlots;

    public enum statType
    {
        Damage,
        DamagePercent,
        Res,
        Health,
        ExpPool,
        ActionPoints,
        Slime,
        ElementSlots
    }
    public enum element
    {
        Fire,
        Water,
        Earth,
        Wind,
        Light,
        Dark,
        Neutral
    }

    public DictionaryHolder()
    {
        fixedDamageStats = new Dictionary<element, int>();
        fixedResStats = new Dictionary<element, int>();
        percentDamageStats = new Dictionary<element, int>();

        fixedDamageStats.Add(element.Fire, 0);
        fixedDamageStats.Add(element.Water, 0);
        fixedDamageStats.Add(element.Wind, 0);
        fixedDamageStats.Add(element.Earth, 0);
        fixedDamageStats.Add(element.Light, 0);
        fixedDamageStats.Add(element.Dark, 0);
        fixedDamageStats.Add(element.Neutral, 0);

        percentDamageStats.Add(element.Fire, 0);
        percentDamageStats.Add(element.Water, 0);
        percentDamageStats.Add(element.Wind, 0);
        percentDamageStats.Add(element.Earth, 0);
        percentDamageStats.Add(element.Light, 0);
        percentDamageStats.Add(element.Dark, 0);
        percentDamageStats.Add(element.Neutral, 0);

        fixedResStats.Add(element.Fire, 0);
        fixedResStats.Add(element.Water, 0);
        fixedResStats.Add(element.Wind, 0);
        fixedResStats.Add(element.Earth, 0);
        fixedResStats.Add(element.Light, 0);
        fixedResStats.Add(element.Dark, 0);
        fixedResStats.Add(element.Neutral, 0);

        health = 0;
        slime = 0;
        actionPoints = 0;
        elementSlots = 0;
        expPool = 0;
    }

    public void Clear()
    {
        fixedDamageStats[element.Fire] = 0;
        fixedDamageStats[element.Water] = 0;
        fixedDamageStats[element.Wind] = 0;
        fixedDamageStats[element.Earth] = 0;
        fixedDamageStats[element.Light] = 0;
        fixedDamageStats[element.Dark] = 0;
        fixedDamageStats[element.Neutral] = 0;

        percentDamageStats[element.Fire] = 0;
        percentDamageStats[element.Water] = 0;
        percentDamageStats[element.Wind] = 0;
        percentDamageStats[element.Earth] = 0;
        percentDamageStats[element.Light] = 0;
        percentDamageStats[element.Dark] = 0;
        percentDamageStats[element.Neutral] = 0;

        fixedResStats[element.Fire] = 0;
        fixedResStats[element.Water] = 0;
        fixedResStats[element.Wind] = 0;
        fixedResStats[element.Earth] = 0;
        fixedResStats[element.Light] = 0;
        fixedResStats[element.Dark] = 0;
        fixedResStats[element.Neutral] = 0;

        health = 0;
        slime = 0;
        actionPoints = 0;
        elementSlots = 0;
        expPool = 0;
    }
    public void AddToStat(statType stat, element element, int increment)
    {
        switch (stat)
        {
            case statType.Damage:
                {
                    fixedDamageStats[element] += increment;
                    break;
                }
            case statType.DamagePercent:
                {
                    percentDamageStats[element] += increment;
                    break;
                }
            case statType.Res:
                {
                    fixedResStats[element] += increment;
                    break;
                }
            case statType.Health:
                {
                    health += increment;
                    break;
                }
            case statType.Slime:
                {
                    slime += increment;
                    break;
                }
            case statType.ActionPoints:
                {
                    actionPoints += increment;
                    break;
                }
            case statType.ExpPool:
                {
                    expPool += increment;
                    break;
                }
            case statType.ElementSlots:
                {
                    elementSlots += increment;
                    break;
                }
        }
    }
    public void ChangeStat(statType stat, int statValue)
    {
        switch (stat)
        {
            case statType.Health:
                {
                    health = statValue;
                    break;
                }
            case statType.Slime:
                {
                    slime = statValue;
                    break;
                }
            case statType.ActionPoints:
                {
                    actionPoints = statValue;
                    break;
                }
            case statType.ExpPool:
                {
                    expPool = statValue;
                    break;
                }
            case statType.ElementSlots:
                {
                    elementSlots = statValue;
                    break;
                }
        }
    }
    public void ChangeStat(statType stat, element element, int statValue)
    {
        switch (stat)
        {
            case statType.Damage:
                {
                    fixedDamageStats[element] = statValue;
                    break;
                }
            case statType.DamagePercent:
                {
                    percentDamageStats[element] = statValue;
                    break;
                }
            case statType.Res:
                {
                    fixedResStats[element] = statValue;
                    break;
                }
        }
    }
    public static int AverageFixedDamageNonZero(DictionaryHolder dic)
    {
        int average = 0;
        int counter = 0;

        if (dic.fixedDamageStats[element.Fire] > 0) { average += dic.fixedDamageStats[element.Fire]; counter++; }
        if (dic.fixedDamageStats[element.Water] > 0) { average += dic.fixedDamageStats[element.Water]; counter++; }
        if (dic.fixedDamageStats[element.Wind] > 0) { average += dic.fixedDamageStats[element.Wind]; counter++; }
        if (dic.fixedDamageStats[element.Earth] > 0) { average += dic.fixedDamageStats[element.Earth]; counter++; }
        if (dic.fixedDamageStats[element.Dark] > 0) { average += dic.fixedDamageStats[element.Dark]; counter++; }
        if (dic.fixedDamageStats[element.Light] > 0) { average += dic.fixedDamageStats[element.Light]; counter++; }
        if (dic.fixedDamageStats[element.Neutral] > 0) { average += dic.fixedDamageStats[element.Neutral]; counter++; }

        if (counter > 0)
        {
            average = Mathf.RoundToInt(average / counter);
        }
        else
        {
            average = 0;
        }

        return average;
    }
    public static DictionaryHolder MergeStats(DictionaryHolder baseDic, DictionaryHolder incrementDic)
    {
        DictionaryHolder temp = new DictionaryHolder();

        temp.health = baseDic.health + incrementDic.health;
        temp.slime = baseDic.slime + incrementDic.slime;
        temp.elementSlots = baseDic.elementSlots + incrementDic.elementSlots;
        temp.actionPoints = baseDic.actionPoints + incrementDic.actionPoints;
        temp.expPool = baseDic.expPool + incrementDic.expPool;

        temp.fixedDamageStats[element.Fire] = baseDic.fixedDamageStats[element.Fire] + incrementDic.fixedDamageStats[element.Fire];
        temp.fixedDamageStats[element.Water] = baseDic.fixedDamageStats[element.Water] + incrementDic.fixedDamageStats[element.Water];
        temp.fixedDamageStats[element.Wind] = baseDic.fixedDamageStats[element.Wind] + incrementDic.fixedDamageStats[element.Wind];
        temp.fixedDamageStats[element.Earth] = baseDic.fixedDamageStats[element.Earth] + incrementDic.fixedDamageStats[element.Earth];
        temp.fixedDamageStats[element.Light] = baseDic.fixedDamageStats[element.Light] + incrementDic.fixedDamageStats[element.Light];
        temp.fixedDamageStats[element.Dark] = baseDic.fixedDamageStats[element.Dark] + incrementDic.fixedDamageStats[element.Dark];
        temp.fixedDamageStats[element.Neutral] = baseDic.fixedDamageStats[element.Neutral] + incrementDic.fixedDamageStats[element.Neutral];

        temp.percentDamageStats[element.Fire] = baseDic.percentDamageStats[element.Fire] + incrementDic.percentDamageStats[element.Fire];
        temp.percentDamageStats[element.Water] = baseDic.percentDamageStats[element.Water] + incrementDic.percentDamageStats[element.Water];
        temp.percentDamageStats[element.Wind] = baseDic.percentDamageStats[element.Wind] + incrementDic.percentDamageStats[element.Wind];
        temp.percentDamageStats[element.Earth] = baseDic.percentDamageStats[element.Earth] + incrementDic.percentDamageStats[element.Earth];
        temp.percentDamageStats[element.Light] = baseDic.percentDamageStats[element.Light] + incrementDic.percentDamageStats[element.Light];
        temp.percentDamageStats[element.Dark] = baseDic.percentDamageStats[element.Dark] + incrementDic.percentDamageStats[element.Dark];
        temp.percentDamageStats[element.Neutral] = baseDic.percentDamageStats[element.Neutral] + incrementDic.percentDamageStats[element.Neutral];

        temp.fixedResStats[element.Fire] = baseDic.fixedResStats[element.Fire] + incrementDic.fixedResStats[element.Fire];
        temp.fixedResStats[element.Water] = baseDic.fixedResStats[element.Water] + incrementDic.fixedResStats[element.Water];
        temp.fixedResStats[element.Wind] = baseDic.fixedResStats[element.Wind] + incrementDic.fixedResStats[element.Wind];
        temp.fixedResStats[element.Earth] = baseDic.fixedResStats[element.Earth] + incrementDic.fixedResStats[element.Earth];
        temp.fixedResStats[element.Light] = baseDic.fixedResStats[element.Light] + incrementDic.fixedResStats[element.Light];
        temp.fixedResStats[element.Dark] = baseDic.fixedResStats[element.Dark] + incrementDic.fixedResStats[element.Dark];
        temp.fixedResStats[element.Neutral] = baseDic.fixedResStats[element.Neutral] + incrementDic.fixedResStats[element.Neutral];

        return temp;
    }
    public static DictionaryHolder MergeStats(DictionaryHolder baseDic, DictionaryHolder incrementDic, int incrementAmount)
    {
        DictionaryHolder temp = new DictionaryHolder();

        temp.health = baseDic.health + incrementDic.health * incrementAmount;
        temp.slime = baseDic.slime + incrementDic.slime * incrementAmount;
        temp.elementSlots = baseDic.elementSlots + incrementDic.elementSlots * incrementAmount;
        temp.actionPoints = baseDic.actionPoints + incrementDic.actionPoints * incrementAmount;
        temp.expPool = baseDic.expPool + incrementDic.expPool * incrementAmount;

        temp.fixedDamageStats[element.Fire] = baseDic.fixedDamageStats[element.Fire] + incrementDic.fixedDamageStats[element.Fire] * incrementAmount;
        temp.fixedDamageStats[element.Water] = baseDic.fixedDamageStats[element.Water] + incrementDic.fixedDamageStats[element.Water] * incrementAmount;
        temp.fixedDamageStats[element.Wind] = baseDic.fixedDamageStats[element.Wind] + incrementDic.fixedDamageStats[element.Wind] * incrementAmount;
        temp.fixedDamageStats[element.Earth] = baseDic.fixedDamageStats[element.Earth] + incrementDic.fixedDamageStats[element.Earth] * incrementAmount;
        temp.fixedDamageStats[element.Light] = baseDic.fixedDamageStats[element.Light] + incrementDic.fixedDamageStats[element.Light] * incrementAmount;
        temp.fixedDamageStats[element.Dark] = baseDic.fixedDamageStats[element.Dark] + incrementDic.fixedDamageStats[element.Dark] * incrementAmount;
        temp.fixedDamageStats[element.Neutral] = baseDic.fixedDamageStats[element.Neutral] + incrementDic.fixedDamageStats[element.Neutral] * incrementAmount;

        temp.percentDamageStats[element.Fire] = baseDic.percentDamageStats[element.Fire] + incrementDic.percentDamageStats[element.Fire] * incrementAmount;
        temp.percentDamageStats[element.Water] = baseDic.percentDamageStats[element.Water] + incrementDic.percentDamageStats[element.Water] * incrementAmount;
        temp.percentDamageStats[element.Wind] = baseDic.percentDamageStats[element.Wind] + incrementDic.percentDamageStats[element.Wind] * incrementAmount;
        temp.percentDamageStats[element.Earth] = baseDic.percentDamageStats[element.Earth] + incrementDic.percentDamageStats[element.Earth] * incrementAmount;
        temp.percentDamageStats[element.Light] = baseDic.percentDamageStats[element.Light] + incrementDic.percentDamageStats[element.Light] * incrementAmount;
        temp.percentDamageStats[element.Dark] = baseDic.percentDamageStats[element.Dark] + incrementDic.percentDamageStats[element.Dark] * incrementAmount;
        temp.percentDamageStats[element.Neutral] = baseDic.percentDamageStats[element.Neutral] + incrementDic.percentDamageStats[element.Neutral] * incrementAmount;

        temp.fixedResStats[element.Fire] = baseDic.fixedResStats[element.Fire] + incrementDic.fixedResStats[element.Fire] * incrementAmount;
        temp.fixedResStats[element.Water] = baseDic.fixedResStats[element.Water] + incrementDic.fixedResStats[element.Water] * incrementAmount;
        temp.fixedResStats[element.Wind] = baseDic.fixedResStats[element.Wind] + incrementDic.fixedResStats[element.Wind] * incrementAmount;
        temp.fixedResStats[element.Earth] = baseDic.fixedResStats[element.Earth] + incrementDic.fixedResStats[element.Earth] * incrementAmount;
        temp.fixedResStats[element.Light] = baseDic.fixedResStats[element.Light] + incrementDic.fixedResStats[element.Light] * incrementAmount;
        temp.fixedResStats[element.Dark] = baseDic.fixedResStats[element.Dark] + incrementDic.fixedResStats[element.Dark] * incrementAmount;
        temp.fixedResStats[element.Neutral] = baseDic.fixedResStats[element.Neutral] + incrementDic.fixedResStats[element.Neutral] * incrementAmount;

        return temp;
    }
    public static string ElementColor(DictionaryHolder.element attackElement)
    {
        string color = "black";

        //get color according to element
        switch (attackElement)
        {
            case DictionaryHolder.element.Fire:
                {
                    color = "red";
                    break;
                }
            case DictionaryHolder.element.Water:
                {
                    color = "blue";
                    break;
                }
            case DictionaryHolder.element.Earth:
                {
                    color = "brown";
                    break;
                }
            case DictionaryHolder.element.Wind:
                {
                    color = "green";
                    break;
                }
            case DictionaryHolder.element.Light:
                {
                    color = "yellow";
                    break;
                }
            case DictionaryHolder.element.Dark:
                {
                    color = "purple";
                    break;
                }
            case DictionaryHolder.element.Neutral:
                {
                    color = "gray";
                    break;
                }
        }
        return color;
    }
}
