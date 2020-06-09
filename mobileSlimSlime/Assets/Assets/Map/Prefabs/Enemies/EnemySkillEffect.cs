using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillEffect : MonoBehaviour
{
    public enum Effects
    {
        None,
        ResUp,
        AllResUp,
        ResDown,
        DamageUp,
        DamageDown,
        Burn,
        Bleed,
        Poison,
        Escape,
        Exp,
        Heal
    }

    public Effects currentEffect;
    private int dotTimer;
    public int amount,dotTimerTick;
    public DictionaryHolder.element element;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentEffect)
        {
            case Effects.ResUp:
                {
                    ResUp();
                    break;
                }
            case Effects.AllResUp:
                {
                    AllResUp();
                    break;
                }
            case Effects.ResDown:
                {
                    ResDown();
                    break;
                }
            case Effects.DamageDown:
                {
                    DamageDown();
                    break;
                }
            case Effects.DamageUp:
                {
                    DamageUp();
                    break;
                }
            case Effects.Poison:
                {
                    Poison();
                    break;
                }
            case Effects.Burn:
                {
                    Burn();
                    break;
                }
            case Effects.Bleed:
                {
                    Bleed();
                    break;
                }
            case Effects.Escape:
                {
                    Escape();
                    break;
                }
            case Effects.Exp:
                {
                    Exp();
                    break;
                }
            case Effects.Heal:
                {
                    Heal();
                    break;
                }
        }
    }

    public void UseSkillEffect(DictionaryHolder.element statElement)
    {
        switch (currentEffect)
        {
            case Effects.ResUp:
                {
                    var temp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.SetElement(statElement);
                    break;
                }
            case Effects.AllResUp:
                {
                    var temp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    break;
                }
            case Effects.ResDown:
                {
                    var temp = GameObject.FindGameObjectWithTag("Player").gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.SetElement(statElement);
                    break;
                }
            case Effects.DamageDown:
                {
                    var temp = GameObject.FindGameObjectWithTag("Player").gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.SetElement(statElement);
                    break;
                }
            case Effects.DamageUp:
                {
                    var temp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.SetElement(statElement);
                    break;
                }
            case Effects.Poison:
                {
                    var temp = GameObject.FindGameObjectWithTag("Player").gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.dotTimerTick = StoryProgressionManager.GetTimeHours()+7;
                    temp.dotTimer = StoryProgressionManager.GetTimeHours()+1;
                    break;
                }
            case Effects.Burn:
                {
                    var temp = GameObject.FindGameObjectWithTag("Player").gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.dotTimerTick = StoryProgressionManager.GetTimeHours() + 3;
                    temp.dotTimer = StoryProgressionManager.GetTimeHours()+1;
                    break;
                }
            case Effects.Bleed:
                {
                    var temp = GameObject.FindGameObjectWithTag("Player").gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.dotTimerTick = StoryProgressionManager.GetTimeHours() + 3;
                    break;
                }
            case Effects.Escape:
                {
                    var temp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    temp.dotTimerTick = StoryProgressionManager.GetTimeHours()+1;
                    temp.dotTimer = StoryProgressionManager.GetTimeHours();
                    break;
                }
            case Effects.Exp:
                {
                    var temp=GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    break;
                }
            case Effects.Heal:
                {
                    var temp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().enemy.gameObject.AddComponent<EnemySkillEffect>();
                    temp.SetAmount(amount);
                    temp.SetEffect(currentEffect);
                    break;
                }
        }
    }
    private void Bleed()
    {
        //timer
        if (dotTimerTick < StoryProgressionManager.GetTimeHours())
        {
            Debug.Log(dotTimer + "/" + dotTimerTick);
        }
        else
        {
            GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().WriteToInfoLabel(string.Format("<color=red>Bleeding</color>... <color=red>{0}</color>",
            gameObject.GetComponent<CharacterStats>().TakeDamage(amount, DictionaryHolder.element.Dark)));
            amount = 0;
        }
    }
    private void Poison()
    {
        //timer
        if ((dotTimerTick <= StoryProgressionManager.GetTimeHours()) && (dotTimer<=StoryProgressionManager.GetTimeHours()))
        {
            GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().WriteToInfoLabel(string.Format("<color=green>Poisoned</color>... <color=red>{0}</color>",
            gameObject.GetComponent<CharacterStats>().TakeDamage(amount, DictionaryHolder.element.Earth)));
            dotTimer++;
        }
    }
    private void Burn()
    {
        //timer
        if ((dotTimerTick < StoryProgressionManager.GetTimeHours())&& (dotTimer <= StoryProgressionManager.GetTimeHours()))
        {
            gameObject.GetComponent<CharacterStats>().TakeDamage(amount, DictionaryHolder.element.Fire);
            dotTimer++;
        }
    }
    private void ResUp()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, element, amount);
            amount = 0;
        }
    }
    private void DamageUp()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Damage, element, amount);
            amount = 0;
        }
    }
    private void ResDown()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<CharacterStats>().currentStats.ChangeStat(DictionaryHolder.statType.Res, element, amount);
            //amount = 0;
        }
    }
    private void DamageDown()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<CharacterStats>().currentStats.ChangeStat(DictionaryHolder.statType.Damage, element, amount);
            //amount = 0;
        }
    }
    private void Escape()
    {
        if (dotTimer >= dotTimerTick)
        {
            GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().EnemyEscape();
        }
        if (dotTimer < StoryProgressionManager.GetTimeHours())
        {
            dotTimer= StoryProgressionManager.GetTimeHours();
        }
    }
    private void Exp()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Enemy>().statsCurrent.expPool += amount;
            amount = 0;
        }
    }
    private void Heal()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Enemy>().Heal(amount);
            amount = 0;
        }
    }
    private void AllResUp()
    {
        if (amount > 0)
        {
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, amount);
            gameObject.GetComponent<Enemy>().statsCurrent.AddToStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, amount);
            amount = 0;
        }
    }

    public void SetAmount(int _amount)
    {
        amount = _amount;
    }
    public void SetEffect(Effects _effect)
    {
        currentEffect = _effect;
    }
    public void SetElement(DictionaryHolder.element _element)
    {
        element = _element;
    }
}
