using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemiesDatabase.enemy type;
    private string _name;
    private int healthMax, healthCurrent, spellPointsCurrent, spellPointsMax, expGiven;

    //enemy stats
    public DictionaryHolder statsCurrent,statsBase;
    private int totalDamage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SetEnemy(EnemiesDatabase.enemy enemyType)
    {
        type = enemyType;
        _name = EnemiesDatabase.GenerateName(enemyType);

        statsBase = new DictionaryHolder();
        statsCurrent = new DictionaryHolder();
        statsBase = EnemiesDatabase.EnemyStats(enemyType);
        statsCurrent = statsBase;
        healthMax = statsCurrent.health;
        healthCurrent = healthMax;
        spellPointsMax = statsCurrent.slime;
        spellPointsCurrent = spellPointsMax;

        expGiven = statsCurrent.expPool;
    }
    public string GetEnemyName()
    {
        return _name;
    }
    public EnemiesDatabase.enemy GetEnemyType()
    {
        return type;
    }
    public int GetHealth()
    {
        return healthCurrent;
    }
    public int Heal(int amount)
    {
        healthCurrent =Mathf.Clamp(healthCurrent+ amount,0,GetHealthMax());
        return healthCurrent;
    }
    public void TakeDamage(int damage, DictionaryHolder.element element)
    {
        //calculate damage dealt TO enemy after resistence
        healthCurrent -= Mathf.RoundToInt(Mathf.Clamp(damage - statsCurrent.fixedResStats[element],0,float.MaxValue));
    }
    public int BasicAttack()
    {
        return DictionaryHolder.AverageFixedDamageNonZero(statsCurrent);
    }
    public int SkillDamage(EnemySkill skill)
    {

        int damage = 0;

        if (CanUseSkill(skill))
        {
            damage = skill.stats.fixedDamageStats[skill.GetElement()] + statsCurrent.fixedDamageStats[skill.GetElement()];
            TakeSP(skill.GetCost());
        }
        else
        {
            //returns basic if cant use skill
            return BasicAttack();
        }

        return damage;
    }
    public bool CanUseSkill(EnemySkill skill)
    {
        if (spellPointsCurrent >= skill.GetCost())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int GetHealthMax()
    {
        return healthMax;
    }
    public int GetSP()
    {
        return spellPointsCurrent;
    }
    public int TakeSP(int spCost)
    {
        spellPointsCurrent -= spCost;
        return spellPointsCurrent;
    }
    public int GetSPMax()
    {
        return spellPointsMax;
    }
    public int GetExp()
    {
        expGiven = statsCurrent.expPool;
        return expGiven;
    }
}
