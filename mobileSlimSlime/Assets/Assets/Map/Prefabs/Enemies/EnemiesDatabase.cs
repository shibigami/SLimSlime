using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemiesDatabase 
{
    public static string name;
    public static DictionaryHolder baseStats;
    public static List<EnemySkill> skills;

    public enum enemy
    {
        Fish,
        Lizzard,
        Cat,
        Scorpion,
        Slime,
        Fox,
        Boar,
        Wolf,
        Bear,
        Goblin,
        LandFish,
        LizardMan,
        Eagle,
        Kappa,
        ArmoredBoar,
        Pixie,
        FireFox,
        Frog,
        Panda,
        Golem
    }

    public static List<EnemySkill> EnemySkill(enemy enemy)
    {
        skills = new List<EnemySkill>();
        switch (enemy)
        {
            case enemy.Fish:
                {
                    //skills
                    skills.Add(new EnemySkill("Splash", 0, 2, DictionaryHolder.element.Water, EnemySkillEffect.Effects.ResUp, 1));

                    break;
                }
            case enemy.Lizzard:
                {
                    //skills

                    break;
                }
            case enemy.Cat:
                {
                    //skills
                    skills.Add(new EnemySkill("Scratch", 1, 0, DictionaryHolder.element.Dark, EnemySkillEffect.Effects.DamageUp, 1));

                    break;
                }
            case enemy.Scorpion:
                {
                    //skills
                    skills.Add(new EnemySkill("Sting", 2, 3, DictionaryHolder.element.Fire, EnemySkillEffect.Effects.Burn, 5));

                    break;
                }
            case enemy.Slime:
                {
                    //skills
                    skills.Add(new EnemySkill("Slime", 1, 1, DictionaryHolder.element.Neutral, EnemySkillEffect.Effects.Exp, 1));

                    break;
                }
            case enemy.Fox:
                {
                    //skills
                    skills.Add(new EnemySkill("Unknown growling", 0, 1, DictionaryHolder.element.Wind));
                    skills.Add(new EnemySkill("Bite",2,3,DictionaryHolder.element.Fire));

                    break;
                }
            case enemy.Boar:
                {
                    //skills
                    skills.Add(new EnemySkill("Tackle", 3, 0, DictionaryHolder.element.Neutral));
                    skills.Add(new EnemySkill("Boulder throw", 4, 4, DictionaryHolder.element.Earth));

                    break;
                }
            case enemy.Wolf:
                {
                    //skills
                    skills.Add(new EnemySkill("Fang", 5, 3, DictionaryHolder.element.Dark));
                    skills.Add(new EnemySkill("Rip", 2, 5, DictionaryHolder.element.Dark, EnemySkillEffect.Effects.Bleed, 15));

                    break;
                }
            case enemy.Bear:
                {
                    //skills
                    skills.Add(new EnemySkill("Claw", 4, 0, DictionaryHolder.element.Light));
                    skills.Add(new EnemySkill("Bite", 3, 0, DictionaryHolder.element.Neutral));
                    skills.Add(new EnemySkill("Dense honey", 0, 7, DictionaryHolder.element.Light, EnemySkillEffect.Effects.Heal, 20));

                    break;
                }
            case enemy.Goblin:
                {
                    //skills
                    skills.Add(new EnemySkill("Slap", 5, 3, DictionaryHolder.element.Neutral));
                    skills.Add(new EnemySkill("Ominous aura", 0, 5, DictionaryHolder.element.Dark, EnemySkillEffect.Effects.DamageUp, 5));
                    skills.Add(new EnemySkill("Evil punch", 10, 10, DictionaryHolder.element.Dark));
                    skills.Add(new EnemySkill("Shadow hold", 25, 15, DictionaryHolder.element.Dark, EnemySkillEffect.Effects.ResDown, 15));
                    break;
                }
            case enemy.LandFish:
                {
                    skills.Add(new EnemySkill("S(la)plash", 1, 3, DictionaryHolder.element.Water));
                    skills.Add(new EnemySkill("Dry", 0, 5, DictionaryHolder.element.Fire, EnemySkillEffect.Effects.ResDown, 10));
                    break;
                }
            case enemy.LizardMan:
                {
                    skills.Add(new EnemySkill("Javelin throw", 10, 0, DictionaryHolder.element.Neutral));
                    skills.Add(new EnemySkill("Lick", 0, 8, DictionaryHolder.element.Earth, EnemySkillEffect.Effects.Poison, 15));
                    break;
                }
            case enemy.Eagle:
                {
                    skills.Add(new EnemySkill("Screech", 8, 5, DictionaryHolder.element.Wind));
                    skills.Add(new EnemySkill("Cocoon", 0, 10, DictionaryHolder.element.Light, EnemySkillEffect.Effects.AllResUp, 10));
                    skills.Add(new EnemySkill("Pressure point", 15, 9, DictionaryHolder.element.Neutral));
                    break;
                }
            case enemy.Kappa:
                {
                    skills.Add(new EnemySkill("Sake bowl", 0, 5, DictionaryHolder.element.Water, EnemySkillEffect.Effects.Heal, 50));
                    skills.Add(new EnemySkill("Stare intently", 0, 10, DictionaryHolder.element.Wind, EnemySkillEffect.Effects.Exp, 100));
                    skills.Add(new EnemySkill("Run", 0, 9, DictionaryHolder.element.Neutral, EnemySkillEffect.Effects.Escape, 0));
                    break;
                }
            case enemy.ArmoredBoar:
                {
                    skills.Add(new EnemySkill("Head bash", 15, 10, DictionaryHolder.element.Earth));
                    skills.Add(new EnemySkill("Fix armor", 0, 2, DictionaryHolder.element.Neutral, EnemySkillEffect.Effects.AllResUp, 15));
                    skills.Add(new EnemySkill("Snort", 1, 0, DictionaryHolder.element.Earth, EnemySkillEffect.Effects.DamageUp, 15));
                    break;
                }
            case enemy.Pixie:
                {
                    skills.Add(new EnemySkill("Heal", 0, 0, DictionaryHolder.element.Light, EnemySkillEffect.Effects.Heal, 70));
                    skills.Add(new EnemySkill("Fly away", 0, 10, DictionaryHolder.element.Neutral, EnemySkillEffect.Effects.Escape, 0));
                    skills.Add(new EnemySkill("Pixie dust", 0, 20, DictionaryHolder.element.Light, EnemySkillEffect.Effects.Exp, 200));
                    break;
                }
            case enemy.FireFox:
                {
                    skills.Add(new EnemySkill("Tail swipe", 18, 10, DictionaryHolder.element.Fire, EnemySkillEffect.Effects.DamageUp, 10));
                    skills.Add(new EnemySkill("Spirit lantern", 0, 5, DictionaryHolder.element.Fire, EnemySkillEffect.Effects.Burn, 20));
                    skills.Add(new EnemySkill("Unknown growling", 0, 1, DictionaryHolder.element.Wind));
                    skills.Add(new EnemySkill("Envelop", 25, 15, DictionaryHolder.element.Fire));
                    break;
                }
            case enemy.Frog:
                {
                    skills.Add(new EnemySkill("Whip slash", 13, 0, DictionaryHolder.element.Neutral));
                    skills.Add(new EnemySkill("Bubble wrap", 0, 20, DictionaryHolder.element.Water, EnemySkillEffect.Effects.AllResUp, 20));
                    break;
                }
            case enemy.Panda:
                {
                    skills.Add(new EnemySkill("Endanger", 50, 25, DictionaryHolder.element.Neutral, EnemySkillEffect.Effects.DamageUp, 50));
                    skills.Add(new EnemySkill("Holy bamboo!!", 0, 20, DictionaryHolder.element.Light, EnemySkillEffect.Effects.Heal, 150));
                    break;
                }
            case enemy.Golem:
                {
                    skills.Add(new EnemySkill("Tuck & jump", 15, 5, DictionaryHolder.element.Earth, EnemySkillEffect.Effects.AllResUp, 10));
                    skills.Add(new EnemySkill("Rock roll", 20, 25, DictionaryHolder.element.Earth, EnemySkillEffect.Effects.AllResUp, 35));
                    skills.Add(new EnemySkill("Shadow strangle", 40, 20, DictionaryHolder.element.Dark));
                    skills.Add(new EnemySkill("Mini black hole", 70, 100, DictionaryHolder.element.Dark, EnemySkillEffect.Effects.DamageUp, 100));
                    break;
                }
        }

        return skills;
    }
    public static DictionaryHolder EnemyStats(enemy enemy)
    {
        baseStats = new DictionaryHolder();

        switch (enemy)
        {
            case enemy.Fish:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 1);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 1);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 1);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 10);
                    break;
                }
            case enemy.Lizzard:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 2);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 2);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 1);

                    break;
                }
            case enemy.Cat:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 5);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 9);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 3);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 5);
                    break;
                }
            case enemy.Scorpion:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 7);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 7);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 7);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 7);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 7);
                    break;
                }
            case enemy.Slime:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 2);
                    
                    break;
                }
            case enemy.Fox:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 5);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 10);
                    break;
                }
            case enemy.Boar:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 12);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 5);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 5);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 10);
                    break;
                }
            case enemy.Wolf:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 30);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 10);
                    break;
                }
            case enemy.Bear:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, 25);
                    break;
                }
            case enemy.Goblin:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 200);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 250);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 12);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 12);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 6);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 10);
                    break;
                }
            case enemy.LandFish:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 2);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 40);
                    break;
                }
            case enemy.LizardMan:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 70);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 125);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 20);
                    break;
                }
            case enemy.Eagle:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 80);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 75);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 30);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, 30);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 30);
                    break;
                }
            case enemy.Kappa:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 200);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 75);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 500);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 10);
                    break;
                }
            case enemy.ArmoredBoar:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 80);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 150);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 35);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, 20);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 35);
                    break;
                }
            case enemy.Pixie:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 125);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 300);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 75);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 35);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 70);
                    break;
                }
            case enemy.FireFox:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 130);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 110);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 30);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 1);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 10);
                    break;
                }
            case enemy.Frog:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 75);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 200);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 200);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 25);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 10);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 60);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 20);
                    break;
                }
            case enemy.Panda:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 150);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 300);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 500);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 40);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 100);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 40);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 15);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 30);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 70);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 65);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Light, 100);
                    break;
                }
            case enemy.Golem:
                {
                    //stats
                    baseStats.ChangeStat(DictionaryHolder.statType.ExpPool, 500);
                    baseStats.ChangeStat(DictionaryHolder.statType.Health, 500);
                    baseStats.ChangeStat(DictionaryHolder.statType.Slime, 750);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 50);
                    baseStats.ChangeStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 40);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Dark, 125);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Neutral, 125);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Fire, 125);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Water, 75);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Wind, 150);
                    baseStats.ChangeStat(DictionaryHolder.statType.Res, DictionaryHolder.element.Earth, 150);
                    break;
                }
        }

        return baseStats;
    }
    public static string GenerateName(enemy enemy)
    {

        name = enemy.ToString();
        return name;
    }
}
