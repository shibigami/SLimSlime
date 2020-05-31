using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterSkillTree))]
[RequireComponent(typeof(DataManager))]
[RequireComponent(typeof(InventorySystem))]

[Serializable]

public class CharacterStats : MonoBehaviour
{
    private DataManager datamanager;

    //name
    public string playerName;

    //job classes
    public CharacterJobClass WoodCutting, Farming, Mining, Fishing;

    //dynamic stats
    public int actionPointsCurent, healthCurrent, slimeCurrent, expPoolCurrent;

    //stats
    public DictionaryHolder currentStats, modifierStats,baseStats;


    // Start is called before the first frame update
    void Start()
    {
        //name
        playerName = "Slimey";

        //save load manager
        datamanager = GetComponent<DataManager>();

        //story progression
        StoryProgressionManager.Initialize();

        //stats
        currentStats = new DictionaryHolder();
        modifierStats = new DictionaryHolder();
        baseStats = new DictionaryHolder();
        baseStats.ChangeStat(DictionaryHolder.statType.Health, 10);
        baseStats.ChangeStat(DictionaryHolder.statType.Slime, 10);
        baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 1);

        //gathering levels
        Farming = new CharacterJobClass("Farming", 1,20);
        Fishing = new CharacterJobClass("Fishing", 1,20);
        Mining = new CharacterJobClass("Mining", 1,20);
        WoodCutting = new CharacterJobClass("WoodCutting", 1,20);

        //modified stats
        actionPointsCurent = baseStats.actionPoints;
        healthCurrent = baseStats.health;
        slimeCurrent = baseStats.slime;
        expPoolCurrent = 0;

        /*
        //try load
        datamanager.Load();

        //try save
        datamanager.Save();
        */
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    //add stats per passive skills
    public void UpdateStats()
    {
        modifierStats.Clear();
        //merger each skill passive with modifier stats
        for (int i = 0; i < gameObject.GetComponent<CharacterSkillTree>().AvailablePassiveSkills().Count; i++)
        {
            modifierStats = DictionaryHolder.MergeStats(modifierStats, GetComponent<CharacterSkillTree>().AvailablePassiveSkills()[i].statsCurrent);
        }

        currentStats = DictionaryHolder.MergeStats(baseStats, modifierStats, 1);
    }
    public void RefillHealthToMax()
    {
        healthCurrent = Mathf.RoundToInt(currentStats.health);
    }
    public void RefillSPToMax()
    {
        slimeCurrent = Mathf.RoundToInt(currentStats.slime);
    }
    public void RefillActionPoints()
    {
        actionPointsCurent = Mathf.RoundToInt(currentStats.actionPoints);
    }
    public int TakeDamage(int damage,DictionaryHolder.element element)
    {
        healthCurrent -= Mathf.Clamp(damage-currentStats.fixedResStats[element],0,int.MaxValue);
        return healthCurrent;
    }
    public void GainExp(int exp)
    {
        expPoolCurrent += exp;
        if (expPoolCurrent > currentStats.expPool)
        {
            expPoolCurrent = currentStats.expPool;
        }
    }
    public int ChangeExpP(int exp)
    {
        if (((expPoolCurrent >= exp) && (exp > 0)) || (exp < 0))
        {
            expPoolCurrent -= exp;
            return exp;
        }
        else return 0;
    }
}
