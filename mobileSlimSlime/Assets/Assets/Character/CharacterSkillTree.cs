using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkillTree : MonoBehaviour
{
    private List<CharacterSkill> passiveSkills,availablePassiveSkills,availableActiveSkills;
    public List<CharacterSkill> activeSkills;
    public List<GameObject> passiveSkillButtons, activeSkillButtons;
    public GameObject skillButton;
    private bool showingCur, showingOld;

    // Start is called before the first frame update
    void Start()
    {
        showingCur = false;
        showingOld = false;

        //buttons
        passiveSkillButtons = new List<GameObject>();
        activeSkillButtons = new List<GameObject>();

        //available skills list
        availableActiveSkills = new List<CharacterSkill>();
        availablePassiveSkills = new List<CharacterSkill>();

        //list of character skills
        passiveSkills = new List<CharacterSkill>();
        activeSkills = new List<CharacterSkill>();

        #region skill list

        //skill lists need to be filled from fire to neutral and from 1 slot up to 7
        //skill lists need to be fully filled per slot - all 1 slots>all 2 slots>all 3 slots>etc..

        #region passives

        //Element Discharge - dictates the amount of element slots a player can have during battle
        passiveSkills.Add(new CharacterSkill("Element Discharge", "Amount of elemental slots.", 1, 500,4,DictionaryHolder.element.Neutral));
        passiveSkills[passiveSkills.Count-1].AddSkillStat(DictionaryHolder.statType.ElementSlots,1);

        //Slimergy - dictates the max amount of ap a player has
        passiveSkills.Add(new CharacterSkill("Slimergy", "Amount of action points.", 1, 300, 5, DictionaryHolder.element.Neutral));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.ActionPoints,1);

        //Slimology - dictates the amount of base slime exp pool
        passiveSkills.Add(new CharacterSkill("Slimology", "Maximum Slime Exp Pool.", 10, 100, 100, DictionaryHolder.element.Neutral));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.ExpPool, 10);

        //Moe - adds fire damage
        passiveSkills.Add(new CharacterSkill("Moeh", "Heat up with burning passion.", 0, 100, 20, DictionaryHolder.element.Fire));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 1);

        //Sweat - adds water damage
        passiveSkills.Add(new CharacterSkill("Sweat", "Sweat from non-existant sweat glands.", 0, 100,20, DictionaryHolder.element.Water));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 1);

        //Stone finger - adds earth damage
        passiveSkills.Add(new CharacterSkill("Stone finger", "Hardens that slime finger.", 0, 100, 20, DictionaryHolder.element.Earth));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage,DictionaryHolder.element.Earth, 1);

        //B.O. - adds wind damage
        passiveSkills.Add(new CharacterSkill("B.O.", "Emanate some B.O..", 0, 100, 20, DictionaryHolder.element.Wind));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 1);

        //Glow - adds light damage
        passiveSkills.Add(new CharacterSkill("Glow", "You look radiant.", 0, 100, 20, DictionaryHolder.element.Light));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 1);

        //Tan - adds dark damage
        passiveSkills.Add(new CharacterSkill("Tan", "Darkened with light.", 0, 100, 20, DictionaryHolder.element.Dark));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 1);

        //Slimy - adds neutral damage
        passiveSkills.Add(new CharacterSkill("Slimy", "Just slightly more viscous.", 1, 100, 20, DictionaryHolder.element.Neutral));
        passiveSkills[passiveSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 1);

        #endregion

        #region actives

        #region 1Slot

        //Spark - 1 slot fire attack
        activeSkills.Add(new CharacterSkill("Spark", "Basic fire magic.", 0, 10,10,1, DictionaryHolder.element.Fire, "1"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage,DictionaryHolder.element.Fire,1);

        //Droplet - 1 slot water attack
        activeSkills.Add(new CharacterSkill("Droplet", "Basic water magic.", 0, 10, 10, 1, DictionaryHolder.element.Water, "2"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 1);

        //Stone - 1 slot earth attack
        activeSkills.Add(new CharacterSkill("Stone", "Basic earth magic.", 0, 10, 10, 1, DictionaryHolder.element.Earth, "3"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 1);

        //Blow - 1 slot wind attack
        activeSkills.Add(new CharacterSkill("Blow", "Basic wind magic.", 0, 10, 10, 1, DictionaryHolder.element.Wind, "4"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 1);

        //Flash - 1 slot light attack
        activeSkills.Add(new CharacterSkill("Flash", "Basic light magic.", 0, 10, 10, 1, DictionaryHolder.element.Light, "5"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 1);

        //Shadow - 1 slot dark attack
        activeSkills.Add(new CharacterSkill("Shadow", "Basic dark magic.", 0, 10, 10, 1, DictionaryHolder.element.Dark, "6"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 1);

        //Whip - 1 slot neutral attack
        activeSkills.Add(new CharacterSkill("Whip", "Basic neutral magic.", 1, 10, 10, 1, DictionaryHolder.element.Neutral, "7"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 1);

        #endregion
        #region 2Slots

        //Ember - 2 slot fire attack
        activeSkills.Add(new CharacterSkill("Ember", "Less basic fire magic.", 0, 10, 20, 1, DictionaryHolder.element.Fire, "11"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 2);

        //Fire Force - 2 slot fire attack
        activeSkills.Add(new CharacterSkill("Fire Force", "A fiery push.", 0, 10, 20, 1, DictionaryHolder.element.Fire, "17"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 1);
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 1);

        //Puddle - 2 slot water attack
        activeSkills.Add(new CharacterSkill("Puddle", "Less basic water magic.", 0, 10, 20, 1, DictionaryHolder.element.Water, "22"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 2);

        //Rock - 2 slot earth attack
        activeSkills.Add(new CharacterSkill("Rock", "Less basic earth magic.", 0, 10, 20, 1, DictionaryHolder.element.Earth, "33"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 2);

        //Pass the gas - 2 slot wind attack
        activeSkills.Add(new CharacterSkill("Pass the gas", "Less basic wind magic.", 0, 10, 20, 1, DictionaryHolder.element.Wind, "44"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 2);

        //Reflection - 2 slot light attack
        activeSkills.Add(new CharacterSkill("Reflection", "Less basic light magic.", 0, 10, 20, 1, DictionaryHolder.element.Light, "55"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 2);

        //Darken - 2 slot dark attack
        activeSkills.Add(new CharacterSkill("Darken", "Less basic dark magic.", 0, 10, 20, 1, DictionaryHolder.element.Dark, "66"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 2);

        //Scorched shadow - 2 slot dark attack
        activeSkills.Add(new CharacterSkill("Scorched shadow", "Where did it get that tan?", 0, 10, 20, 1, DictionaryHolder.element.Dark, "61"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 1);
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 1);

        //Slash - 2 slot neutral attack
        activeSkills.Add(new CharacterSkill("Slash", "Less basic neutral magic.", 0, 10, 20, 1, DictionaryHolder.element.Neutral, "77"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 2);

        #endregion
        #region 3Slots

        //Ball of fire - 3 slot fire attack
        activeSkills.Add(new CharacterSkill("Ball of fire", "Even less basic fire magic.", 0, 10, 30, 1, DictionaryHolder.element.Fire, "111"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Fire, 3);

        //Spit - 3 slot water attack
        activeSkills.Add(new CharacterSkill("Spit", "Even less basic water magic.", 0, 10, 30, 1, DictionaryHolder.element.Water, "222"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Water, 3);

        //Boulder - 3 slot earth attack
        activeSkills.Add(new CharacterSkill("Boulder", "Even less basic earth magic.", 0, 10, 30, 1, DictionaryHolder.element.Earth, "333"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Earth, 3);

        //Breeze - 3 slot wind attack
        activeSkills.Add(new CharacterSkill("Breeze", "Even less basic wind magic.", 0, 10, 30, 1, DictionaryHolder.element.Wind, "444"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Wind, 3);

        //Light string - 3 slot light attack
        activeSkills.Add(new CharacterSkill("Light string", "Even less basic light magic.", 0, 10, 30, 1, DictionaryHolder.element.Light, "555"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Light, 3);

        //Darkened shadow - 3 slot dark attack
        activeSkills.Add(new CharacterSkill("Darkened shadow", "Even less basic dark magic.", 0, 10, 30, 1, DictionaryHolder.element.Dark, "666"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Dark, 3);

        //Boke - 3 slot neutral attack
        activeSkills.Add(new CharacterSkill("Bokeh", "Even less basic neutral magic.", 0, 10, 30, 1, DictionaryHolder.element.Neutral, "777"));
        activeSkills[activeSkills.Count - 1].AddSkillStat(DictionaryHolder.statType.Damage, DictionaryHolder.element.Neutral, 3);

        #endregion

        #endregion
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //need to find a way to update this every once in a while
        CreateSkillButtons();
        UpdateSkillButtons();
    }

    public void UpdateUnlockedSkillsList()
    {
        //clear lists
        availableActiveSkills.Clear();
        availablePassiveSkills.Clear();

        //save amount of available skills
        //active
        if(activeSkills.Count>0)
        foreach (CharacterSkill skill in activeSkills)
        {
            if (skill._unlocked)
            {
                availableActiveSkills.Add(skill);
            }
        }
        //passive
        if(passiveSkills.Count>0)
        foreach (CharacterSkill skill in passiveSkills)
        {
            if (skill._unlocked)
            {
                availablePassiveSkills.Add(skill);
            }
        }
    }
    public void CreateSkillButtons()
    {
        UpdateUnlockedSkillsList();

        //attach skills to skill buttons
        try
        {
            //go through passives
            for (int i = 0; i < availablePassiveSkills.Count; i++)
            {
                //is there a button for it yet?
                if (GameObject.Find(availablePassiveSkills[i].Name()) == null)
                {
                    //set each button in the view they belong in
                    GameObject temp = Instantiate(skillButton, GameObject.FindGameObjectWithTag(availablePassiveSkills[i]._element.ToString() + "SkillView").transform);

                    //set object name(just cause I can)
                    temp.name = availablePassiveSkills[i].Name();

                    //set skill
                    temp.GetComponent<SkillInfoDisplay>().charSkill = availablePassiveSkills[i];

                    //add instantiated object to list
                    passiveSkillButtons.Add(temp);
                }
            }
            //go through actives
            for (int i = 0; i < availableActiveSkills.Count; i++)
            {
                //is there a button for it yet?
                if (GameObject.Find(availableActiveSkills[i].Name()) == null)
                {
                    //set each button in the view they belong in
                    GameObject temp = Instantiate(skillButton, GameObject.FindGameObjectWithTag(availableActiveSkills[i]._element.ToString() + "SkillView").transform);

                    //set object name(just cause I can)
                    temp.name = availableActiveSkills[i].Name();

                    //set skill
                    temp.GetComponent<SkillInfoDisplay>().charSkill = availableActiveSkills[i];

                    //add instantiated object to list
                    activeSkillButtons.Add(temp);
                }
            }
        }
        catch { }
    }
    public void UpdateSkillButtons()
    {
        //update once when opened, only
        try
        {
            showingCur = GameObject.FindGameObjectWithTag("SkillsView").activeSelf;
        }
        catch
        {
            showingCur = false;
        }

        //if skill panel is showing
        if (GameObject.FindGameObjectWithTag("SkillsView"))
        {
            //update skill button skill info by setting the character skills to each buttons skillinfodisplay script
            for (int passButInd = 0; passButInd < passiveSkillButtons.Count; passButInd++)
            {
                for (int passInd = 0; passInd < availablePassiveSkills.Count; passInd++)
                {
                    if (AvailablePassiveSkills()[passInd].Name() == passiveSkillButtons[passButInd].GetComponent<SkillInfoDisplay>().charSkill.Name())
                    {
                        passiveSkillButtons[passButInd].GetComponent<SkillInfoDisplay>().charSkill = availablePassiveSkills[passButInd];
                        //update info
                        if (showingOld != showingCur)
                        {
                            passiveSkillButtons[passButInd].GetComponent<SkillInfoDisplay>().UpdateInfoDisplay();
                        }
                    }
                }
            }
            for (int actButInd = 0; actButInd < activeSkillButtons.Count; actButInd++)
            {
                for (int actInd = 0; actInd < availableActiveSkills.Count; actInd++)
                {
                    if (AvailableActiveSkills()[actInd].Name() == activeSkillButtons[actButInd].GetComponent<SkillInfoDisplay>().charSkill.Name())
                    {
                        activeSkillButtons[actButInd].GetComponent<SkillInfoDisplay>().charSkill = availableActiveSkills[actInd];
                        //update info
                        if (showingOld != showingCur)
                        {
                            activeSkillButtons[actButInd].GetComponent<SkillInfoDisplay>().UpdateInfoDisplay();
                        }
                    }
                }
            }
        }

        //for checking if it should update/has been updated
        showingOld = showingCur;
    }
    public List<CharacterSkill> PassiveSkills()
    {
        return passiveSkills;
    }
    public List<CharacterSkill> AvailablePassiveSkills()
    {
        UpdateUnlockedSkillsList();
        return availablePassiveSkills;
    }
    public List<CharacterSkill> ActiveSkills()
    {
        return activeSkills;
    }
    public List<CharacterSkill> AvailableActiveSkills()
    {
        UpdateUnlockedSkillsList();
        return availableActiveSkills;
    }
    public bool ChangeSkillExp(CharacterSkill charskill,int amount)
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().ChangeExpP(amount)!=0) {
            for(int i=0;i<availableActiveSkills.Count;i++)
            {
                if (charskill == availableActiveSkills[i])
                {
                    availableActiveSkills[i].ChangeExp(amount);
                    UpdateSkillButtons();
                }
            }
            for (int i = 0; i < availablePassiveSkills.Count; i++)
            {
                if (charskill == availablePassiveSkills[i])
                {
                    availablePassiveSkills[i].ChangeExp(amount);
                    UpdateSkillButtons();
                }
            }
            return true;
        } else return false;
    }
}
