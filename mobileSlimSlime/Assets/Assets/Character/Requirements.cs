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
    private Dictionary<Triggers, int> triggers=new Dictionary<Triggers, int>();
    private bool requirementMet;

    public void AddRequirement(Triggers trigger,int value)
    {
        triggers.Add(trigger, value);
    }
    public bool AreRequirementsMet()
    {
        return requirementMet;
    }
}