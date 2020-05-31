using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FightManager : MonoBehaviour
{
    public GameObject[] elementChoiceSlots, elementChoices;
    public Sprite[] elementIcons;
    public Text infoLabel, hpLabel, spLabel, enemyHpLabel, enemySpLabel,enemyName;
    public GameObject hpBar, spBar, enemyHpBar, enemySpBar, executeButton;
    public Enemy enemy;
    private float hpBarMaxWidth, spBarMaxWidth, enemyHpBarMaxWidth, enemySpBarMaxWidth;
    private int elementChoicesCounter, maxElementChoiceSlots;
    public bool chooseElements;
    private GameObject player;
    private List<string> infoForLabel;
    private List<CharacterSkill> skillQueue;


    private enum FightFlow
    {
        Start,
        ChooseElements,
        Attack,
        Defend,
        Resolve,
        End,
        OutsideFight
    }

    private FightFlow fightState;
    private float labelTimer, labelTimerTick, waitForReadTick, waitForReadTimer;

    private void ResetFight()
    {
        //fight flow control
        elementChoicesCounter = 0;
        chooseElements = false;

        //player
        player = GameObject.FindGameObjectWithTag("Player");
        skillQueue = new List<CharacterSkill>();

        //info label
        infoForLabel = new List<string>();
        labelTimer = 0;
        labelTimerTick = 3f;
        waitForReadTimer = 0;
        waitForReadTick = 5f;

        //hp and sp bar
        hpBarMaxWidth = hpBar.GetComponent<RectTransform>().sizeDelta.x;
        spBarMaxWidth = spBar.GetComponent<RectTransform>().sizeDelta.x;

        //enemy hp and sp bar
        enemyHpBarMaxWidth = enemyHpBar.GetComponent<RectTransform>().sizeDelta.x;
        enemySpBarMaxWidth = enemySpBar.GetComponent<RectTransform>().sizeDelta.x;

    }

    // Start is called before the first frame update
    void Start()
    {
        ResetFight();

        fightState = FightFlow.OutsideFight;
    }

    // Update is called once per frame
    void Update()
    {
        #region Health/SPUpdate

        //set hp
        var temp = hpBar.GetComponent<RectTransform>();
        temp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (player.GetComponent<CharacterStats>().healthCurrent * hpBarMaxWidth) / player.GetComponent<CharacterStats>().currentStats.health);
        hpLabel.text = player.GetComponent<CharacterStats>().healthCurrent.ToString() + "/" + player.GetComponent<CharacterStats>().currentStats.health.ToString();

        //set sp - slime points
        temp = spBar.GetComponent<RectTransform>();
        temp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (player.GetComponent<CharacterStats>().slimeCurrent * spBarMaxWidth) / player.GetComponent<CharacterStats>().currentStats.slime);
        spLabel.text = player.GetComponent<CharacterStats>().slimeCurrent.ToString() + "/" + player.GetComponent<CharacterStats>().currentStats.slime.ToString();

        //error fixing
        try
        {
            if (enemy != null)
            {
                //set enemy hp
                temp = enemyHpBar.GetComponent<RectTransform>();
                temp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (enemy.GetHealth() * enemyHpBarMaxWidth) / enemy.GetHealthMax());
                enemyHpLabel.text = enemy.GetHealth().ToString() + "/" + enemy.GetHealthMax().ToString();

                //set enemy sp - slime points
                temp = enemySpBar.GetComponent<RectTransform>();
                temp.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (enemy.GetSP() * spBarMaxWidth) / enemy.GetSPMax());
                enemySpLabel.text = enemy.GetSP().ToString() + "/" + enemy.GetSPMax().ToString();
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Enemy not set. Error: " + ex.ToString());
        }

        #endregion

        #region FightFlow

        //continuous label update
        UpdateInfoLabel();

        //fight flow
        switch (fightState)
        {
            case FightFlow.Start:
                {
                    ResetFight();

                    //label write
                    WriteToInfoLabel(string.Format("<color=purple>{0}</color> encountered!", enemy.GetEnemyType()));

                    #region UISetUp

                    enemyName.text = enemy.GetEnemyName();

                    //set element choice slots
                    maxElementChoiceSlots = player.GetComponent<CharacterStats>().currentStats.elementSlots;

                    //disable/enable elemental slots
                    for (int i = 0; i < elementChoiceSlots.Length; i++)
                    {
                        //skill[0] dictates the amount of elemental slots a player can have
                        if (i < maxElementChoiceSlots)
                        {
                            elementChoiceSlots[i].SetActive(true);
                        }
                        else
                        {
                            elementChoiceSlots[i].SetActive(false);
                        }
                    }

                    //set elements available according to lvl 1 skills
                    for (int i = 0; i < elementIcons.Length; i++)
                    {
                        if (player.GetComponent<CharacterSkillTree>().ActiveSkills()[i].CurrentLevel() > 0)
                        {
                            elementChoices[i].SetActive(true);
                        }
                        else
                        {
                            elementChoices[i].SetActive(false);
                        }
                    }

                    #endregion

                    //move to next phase
                    fightState = FightFlow.ChooseElements;

                    break;
                }
            case FightFlow.ChooseElements:
                {
                    //check death
                    if (player.GetComponent<CharacterStats>().healthCurrent <= 0)
                    {
                        //write death
                        WriteToInfoLabel("You're too weak to continue...");

                        //advance time
                        StoryProgressionManager.AddTime(24);

                        //end fight
                        fightState = FightFlow.End;
                    }

                    //enable element choosing
                    chooseElements = true;

                    //if at least one elements has been chosen
                    if (elementChoicesCounter > 0)
                    {
                        executeButton.SetActive(true);
                    }
                    else
                    {
                        executeButton.SetActive(false);
                    }

                    break;
                }
            case FightFlow.Attack:
                {
                    //disable element choosing
                    chooseElements = false;

                    //attack
                    AttackRoutine();

                    //clear element choice slots
                    ClearChosenSlots();

                    //change phase
                    if (enemy.GetHealth() > 0)
                    {
                        fightState = FightFlow.Defend;
                    }
                    else
                    {
                        //end
                        fightState = FightFlow.Resolve;
                    }

                    break;
                }
            case FightFlow.Defend:
                {
                    //enemy attack
                    DefendRoutine();

                    //advance time
                    StoryProgressionManager.AddTime(1);

                    //check death
                    if (player.GetComponent<CharacterStats>().healthCurrent <= 0)
                    {
                        //write death
                        WriteToInfoLabel("You're too weak to continue...");

                        //advance time
                        StoryProgressionManager.AddTime(24);

                        //end fight
                        fightState = FightFlow.End;
                    }
                    else
                    {
                        //attack again
                        fightState = FightFlow.ChooseElements;
                    }

                    break;
                }
            case FightFlow.Resolve:
                {
                    //write exp given
                    WriteToInfoLabel(string.Format("Battle end... Obtained <color=yellow>{0}</color> exp.", enemy.GetExp()));

                    //give exp
                    player.GetComponent<CharacterStats>().GainExp(enemy.GetExp());

                    //end
                    fightState = FightFlow.End;

                    break;
                }
            case FightFlow.End:
                {
                    //remove enemy skill effects
                    foreach (EnemySkillEffect skillEffect in player.GetComponents<EnemySkillEffect>()) Destroy(skillEffect);

                    //wait for read
                    if (!WaitingForRead())
                    {
                        //check death
                        if (player.GetComponent<CharacterStats>().healthCurrent <= 0)
                        {
                            player.GetComponent<CharacterStats>().actionPointsCurent = 0;
                        }
                        else
                        {
                            //take ap
                            player.GetComponent<CharacterStats>().actionPointsCurent--;
                        }

                        fightState = FightFlow.OutsideFight;
                    }

                    break;
                }

            case FightFlow.OutsideFight:
                {
                    //keep window hidden
                    GetComponent<ShowHideWindow>().showHide = false;
                    infoLabel.text = "";
                    break;
                }
        }

        #endregion
    }

    public void WriteToInfoLabel(string info)
    {
        //set line carriage
        info += "\n";
        //adds string to list of shown strings
        infoForLabel.Add(info);
        //output to label
        infoLabel.text = "";
        foreach (string str in infoForLabel)
        {
            infoLabel.text += str;
        }
    }
    private void UpdateInfoLabel()
    {
        //update if there is content
        if (infoForLabel.Count > 0)
        {
            if (labelTimer >= labelTimerTick)
            {
                //remove top line
                for (int i = 0; i < infoForLabel.Count - 1; i++)
                {
                    infoForLabel[i] = infoForLabel[i + 1];
                }
                //remove last item
                infoForLabel.RemoveAt(infoForLabel.Count - 1);

                //set list back to label
                infoLabel.text = "";
                foreach (string str in infoForLabel)
                {
                    infoLabel.text += str;
                }

                //reset timer
                labelTimer = 0;
            }
            else
            {
                labelTimer += Time.deltaTime;
            }
        }
    }
    private bool WaitingForRead()
    {
        if (waitForReadTimer >= waitForReadTick)
        {
            waitForReadTimer = 0;
            return false;
        }
        else
        {
            waitForReadTimer += Time.deltaTime;
            return true;
        }
    }
    public void AddElementToQueue(string element)
    {
        //if there is still space in the element queue and can choose elements
        if ((elementChoicesCounter < maxElementChoiceSlots) && (chooseElements) && (fightState == FightFlow.ChooseElements))
        {
            switch (element)
            {
                case "Fire":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[0];
                        elementChoiceSlots[elementChoicesCounter].tag = "Fire";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Water":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[1];
                        elementChoiceSlots[elementChoicesCounter].tag = "Water";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Earth":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[2];
                        elementChoiceSlots[elementChoicesCounter].tag = "Earth";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Wind":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[3];
                        elementChoiceSlots[elementChoicesCounter].tag = "Wind";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Light":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[4];
                        elementChoiceSlots[elementChoicesCounter].tag = "Light";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Dark":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[5];
                        elementChoiceSlots[elementChoicesCounter].tag = "Dark";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
                case "Neutral":
                    {
                        elementChoiceSlots[elementChoicesCounter].GetComponent<Image>().sprite = elementIcons[6];
                        elementChoiceSlots[elementChoicesCounter].tag = "Neutral";
                        //add to counter
                        elementChoicesCounter++;
                        break;
                    }
            }
        }
    }
    public void StartFight(Enemy enemySelected)
    {
        enemy = enemySelected;
        enemy.statsCurrent = enemySelected.statsCurrent;
        fightState = FightFlow.Start;
    }
    public void ExecuteAttack()
    {
        if (fightState == FightFlow.ChooseElements)
        {
            fightState = FightFlow.Attack;
            executeButton.SetActive(false);
        }
    }
    private void ClearChosenSlots()
    {
        for (int i = 0; i < maxElementChoiceSlots; i++)
        {
            elementChoiceSlots[i].tag = "Untagged";
            elementChoiceSlots[i].GetComponent<Image>().sprite = null;
        }
    }
    private void AttackRoutine()
    {
        //create temp variable for attack pattern
        string attack = "";
        string stopString = "";

        for (int i = 0; i < maxElementChoiceSlots; i++)
        {
            stopString += "0";
        }

        //set attack pattern
        for (int i = 0; i < maxElementChoiceSlots; i++)
        {
            switch (elementChoiceSlots[i].tag)
            {
                case "Fire":
                    {
                        attack += "1";
                        break;
                    }
                case "Water":
                    {
                        attack += "2";
                        break;
                    }
                case "Earth":
                    {
                        attack += "3";
                        break;
                    }
                case "Wind":
                    {
                        attack += "4";
                        break;
                    }
                case "Light":
                    {
                        attack += "5";
                        break;
                    }
                case "Dark":
                    {
                        attack += "6";
                        break;
                    }
                case "Neutral":
                    {
                        attack += "7";
                        break;
                    }
            }
        }


        List<CharacterSkill> tempAvailableSkills = player.GetComponent<CharacterSkillTree>().AvailableActiveSkills();
        bool breakFromCheck = false;

        //goes through skill tree unlocked active skills and checks each possible combo
        //starting with the longer strings
        do
        {
            for (int i = tempAvailableSkills.Count - 1; i >= 0; i--)
            {
                //if the attack string contains the largest string -> shortest
                if (attack.Contains(tempAvailableSkills[i].comboStr))
                {
                    //add the skill to the list of skills to use
                    skillQueue.Add(tempAvailableSkills[i]);
                    //takes the combo int out of the pattern string
                    attack = attack.Replace(tempAvailableSkills[i].comboStr, "0");

                    if (attack == stopString)
                    {
                        breakFromCheck = true;
                    }
                }
            }
        } while (!breakFromCheck);

        //goes through queue and uses skills
        foreach (CharacterSkill skill in skillQueue)
        {
            //if player has sp
            if (skill.spCost <= player.GetComponent<CharacterStats>().slimeCurrent)
            {
                //deduct sp
                player.GetComponent<CharacterStats>().slimeCurrent -= skill.spCost;

                //deal dmg
                enemy.GetComponent<Enemy>().TakeDamage(CalculateSkillDamage(skill), skill._element);

                WriteToInfoLabel(string.Format("Consumed <color=blue>{0}</color> sp to use <color="+DictionaryHolder.ElementColor(skill._element)+">{1}</color>: <color=red>{2}</color> damage.",skill.spCost.ToString(), skill.Name(), CalculateSkillDamage(skill)));
            }
        }
        //clear queue
        skillQueue.Clear();

        //clear counter
        elementChoicesCounter = 0;
    }
    private int CalculateSkillDamage(CharacterSkill skillUsed)
    {
        //base dmg
        int calculatedDamage = skillUsed.statsCurrent.fixedDamageStats[skillUsed._element] + player.GetComponent<CharacterStats>().currentStats.fixedDamageStats[skillUsed._element];
        //plus percent
        calculatedDamage = Mathf.RoundToInt(calculatedDamage * (1 + ((skillUsed.statsCurrent.percentDamageStats[skillUsed._element] + player.GetComponent<CharacterStats>().currentStats.percentDamageStats[skillUsed._element]) / 100)));
        return calculatedDamage;
    }
    private void DefendRoutine()
    {
        //randomizes between -1(basic attack) and skill count
        int randomSkill = 0;
        randomSkill = Random.Range(-1, EnemiesDatabase.EnemySkill(enemy.GetEnemyType()).Count);

        //deal damage
        if (randomSkill < 0)
        {
            //damage
            player.GetComponent<CharacterStats>().TakeDamage(enemy.BasicAttack(), DictionaryHolder.element.Neutral);

            //basic
            WriteToInfoLabel(string.Format("<color=purple>{0}</color> used Basic Attack. <color=red>{1}</color> damage.", enemy.GetComponent<Enemy>().GetEnemyName(),enemy.BasicAttack().ToString()));
        }
        else
        {
            if (enemy.CanUseSkill(EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill]))
            {
                //damage
                player.GetComponent<CharacterStats>().TakeDamage(enemy.GetComponent<Enemy>().SkillDamage(EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill]),EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill].GetElement());

                //skill
                WriteToInfoLabel(string.Format("<color=purple>{0}</color> uses <color="+DictionaryHolder.ElementColor(EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill].GetElement())+">{1}</color> and deals <color=red>{2}</color> damage.", enemy.GetComponent<Enemy>().GetEnemyName(), EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill].GetName(), enemy.GetComponent<Enemy>().SkillDamage(EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill]).ToString()));

                //skill effect
                EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill].UseEffect();
            }
            else
            {
                //damage
                player.GetComponent<CharacterStats>().TakeDamage(enemy.BasicAttack(),DictionaryHolder.element.Neutral);

                //basic
                WriteToInfoLabel(string.Format("<color=purple>{0}</color> tried to use <color=gray>{1}</color>.\n<color=purple>{2}</color> used Basic Attack. <color=red>{3}</color> damage.", enemy.GetComponent<Enemy>().GetEnemyName(), EnemiesDatabase.EnemySkill(enemy.GetEnemyType())[randomSkill].GetName(), enemy.GetComponent<Enemy>().GetEnemyName(), enemy.BasicAttack().ToString()));
            }
        }
        
    }
    public void EnemyEscape()
    {
        fightState = FightFlow.End;
    }
}