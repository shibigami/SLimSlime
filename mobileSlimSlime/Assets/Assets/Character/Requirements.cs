using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirements
{
    public enum Triggers
    {
        FireEnemies,
        WaterEnemies,
        WindEnemies,
        EarthEnemies,
        LightEnemies,
        DarkEnemies,
        NeutralEnemies,
        Hours,
        Days,
        Months,
        Years,
        WoodCuttingLvl,
        FishingLvl,
        FarmingLvl,
        MiningLvl
    }
    public Dictionary<Triggers, int> triggers = new Dictionary<Triggers, int>();
    private bool requirementMet;

    public void FullInitialize()
    {
        triggers.Add(Triggers.FireEnemies, 0);
        triggers.Add(Triggers.WaterEnemies, 0);
        triggers.Add(Triggers.EarthEnemies, 0);
        triggers.Add(Triggers.WindEnemies, 0);
        triggers.Add(Triggers.LightEnemies, 0);
        triggers.Add(Triggers.DarkEnemies, 0);
        triggers.Add(Triggers.NeutralEnemies, 0);
        triggers.Add(Triggers.Hours, 0);
        triggers.Add(Triggers.Days, 0);
        triggers.Add(Triggers.Months, 0);
        triggers.Add(Triggers.Years, 0);
        triggers.Add(Triggers.WoodCuttingLvl, 0);
        triggers.Add(Triggers.FishingLvl, 0);
        triggers.Add(Triggers.FarmingLvl, 0);
        triggers.Add(Triggers.MiningLvl, 0);
    }
    public void AddRequirement(Triggers trigger,int value)
    {
        triggers.Add(trigger, value);
    }
    public Dictionary<Triggers,int> GetRequirements()
    {
        return triggers;
    }
    public bool AreRequirementsMet(Requirements playerProgress)
    {
        //goes through each element in the requirements dictionary
        foreach (KeyValuePair<Triggers, int> keyValue in triggers)
        {
            //checks if it can find if the comparison skill has the same key requirement as story progress
            if (playerProgress.GetRequirements().ContainsKey(keyValue.Key))
            {
                //gets current progress value
                int temp1;
                playerProgress.GetRequirements().TryGetValue(keyValue.Key, out temp1);
                //checks the values
                if (temp1 >= keyValue.Value)
                {
                    requirementMet = true;
                }
                else
                {
                    requirementMet = false;
                    //break away if one requirement is not met
                    return requirementMet;
                }
            }
        }
        return requirementMet;
    }
    public void ChangeRequirementValue(Triggers trigger, int amount)
    {
        triggers[trigger] += amount;
    }
    public void ChangeRequirementValue(DictionaryHolder.element enemyElement, int amount)
    {
        switch (enemyElement)
        {
            case (DictionaryHolder.element.Fire):
                {
                    triggers[Triggers.FireEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Water):
                {
                    triggers[Triggers.WaterEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Wind):
                {
                    triggers[Triggers.WindEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Earth):
                {
                    triggers[Triggers.EarthEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Light):
                {
                    triggers[Triggers.LightEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Dark):
                {
                    triggers[Triggers.DarkEnemies] += amount;
                    break;
                }
            case (DictionaryHolder.element.Neutral):
                {
                    triggers[Triggers.NeutralEnemies] += amount;
                    break;
                }
        }
    }
}