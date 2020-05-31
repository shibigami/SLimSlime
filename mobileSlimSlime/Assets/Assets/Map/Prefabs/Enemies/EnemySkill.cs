using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill
{
    private string _name;
    DictionaryHolder.element _element;
    private int _cost;
    public DictionaryHolder stats;
    public EnemySkillEffect _effect;

    public EnemySkill(string name, int damage,int cost, DictionaryHolder.element element)
    {
        stats = new DictionaryHolder();
        _effect = new EnemySkillEffect();
        _name = name;
        _element = element;
        stats.fixedDamageStats[element] = damage;
        _cost = cost;
    }
    public EnemySkill(string name, int damage,int cost, DictionaryHolder.element element,EnemySkillEffect.Effects effectStat,int amount)
    {
        stats = new DictionaryHolder();
        _effect = new EnemySkillEffect();
        _element = new DictionaryHolder.element();
        _name = name;
        _element = element;
        stats.fixedDamageStats[element] = damage;
        _cost = cost;
        _effect.amount = amount;
        _effect.currentEffect = effectStat;    
    }
    public string GetName()
    {
        return _name;
    }
    public DictionaryHolder.element GetElement()
    {
        return _element;
    }
    public int GetDamage()
    {
        return stats.fixedDamageStats[_element];
    }
    public int GetCost()
    {
        return _cost;
    }
    public void UseEffect()
    {
        _effect.UseSkillEffect(_element);
    }
}
