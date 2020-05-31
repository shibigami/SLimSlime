using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOutputs : MonoBehaviour
{
    public Text actionPoints, gold, playerName, expPool,minerExpLabel,lumberjackExpLabel,fisherExpLabel,farmerExpLabel,
        miner,lumber,fisher,farmer,stats1,stats2,stats3,stats4,doorSize,clock;
    public GameObject expBar,minerExpBar,lumberjackExpBar,fisherExpBar,farmerExpBar,doorLabel,skillUnlockStationLabel;
    private GameObject player;
    private CharacterStats playerStats;

    private struct ExperienceBar
    {
        public Vector2 expbarSize;
        public float width, Maxwidth;
    }

    private ExperienceBar exp, minerExp, lumberExp, fisherExp, farmerExp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<CharacterStats>();

        //set up dimensions of each bar
        exp.expbarSize = expBar.GetComponent<RectTransform>().sizeDelta;
        exp.Maxwidth = exp.expbarSize.x;
        minerExp.expbarSize = minerExpBar.GetComponent<RectTransform>().sizeDelta;
        minerExp.Maxwidth = minerExp.expbarSize.x;
        lumberExp.expbarSize = lumberjackExpBar.GetComponent<RectTransform>().sizeDelta;
        lumberExp.Maxwidth = lumberExp.expbarSize.x;
        fisherExp.expbarSize = fisherExpBar.GetComponent<RectTransform>().sizeDelta;
        fisherExp.Maxwidth = fisherExp.expbarSize.x;
        farmerExp.expbarSize = farmerExpBar.GetComponent<RectTransform>().sizeDelta;
        farmerExp.Maxwidth = farmerExp.expbarSize.x;
    }

    // Update is called once per frame
    void Update()
    {
        //ap
        actionPoints.text = "AP:" + GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().actionPointsCurent.ToString();

        //clock
        clock.text = string.Format("{0}Y {1}M {2}D {3}H",StoryProgressionManager.GetTimeYears(),StoryProgressionManager.GetTimeMonths(),StoryProgressionManager.GetTimeDays(),StoryProgressionManager.GetCurrentTimeHours());

        //door size
        if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIControls>().IsNearDoor())
        {
            doorLabel.SetActive(true);
            doorSize.text = StoryProgressionManager.GetMapSize().ToString();
        }
        else doorLabel.SetActive(false);

        //skill Unlock Interface
        if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIControls>().IsNearSkillUnlockStation())
        {
            skillUnlockStationLabel.SetActive(true);
        }
        else skillUnlockStationLabel.SetActive(false);

        //gold
        gold.text = InventorySystem.items[0].GetAmount().ToString();
        //player name
        playerName.text = player.GetComponent<CharacterStats>().playerName;
        //exp
        expPool.text = string.Format("{0}/{1}", player.GetComponent<CharacterStats>().expPoolCurrent, player.GetComponent<CharacterStats>().currentStats.expPool);
        exp.width = AdjustBarSize(exp.Maxwidth, player.GetComponent<CharacterStats>().expPoolCurrent, player.GetComponent<CharacterStats>().currentStats.expPool);
        expBar.GetComponent<RectTransform>().sizeDelta = new Vector2(exp.width, exp.expbarSize.y);

        //jobs
        lumber.text = string.Format("WoodCutting Lvl.{0}",playerStats.WoodCutting.GetLevel());
        farmer.text = string.Format("Farming Lvl.{0}", playerStats.Farming.GetLevel());
        fisher.text = string.Format("Fishing Lvl.{0}", playerStats.Fishing.GetLevel());
        miner.text = string.Format("Mining Lvl.{0}", playerStats.Mining.GetLevel());

        //farmer
        farmerExpLabel.text = string.Format("{0}/{1}", player.GetComponent<CharacterStats>().Farming.GetExp(), player.GetComponent<CharacterStats>().Farming.GetExpToLevel());
        farmerExp.width = AdjustBarSize(farmerExp.Maxwidth, player.GetComponent<CharacterStats>().Farming.GetExp(), player.GetComponent<CharacterStats>().Farming.GetExpToLevel());
        farmerExpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(farmerExp.width, farmerExp.expbarSize.y);
        //lumberman
        lumberjackExpLabel.text = string.Format("{0}/{1}", player.GetComponent<CharacterStats>().WoodCutting.GetExp(), player.GetComponent<CharacterStats>().WoodCutting.GetExpToLevel());
        lumberExp.width = AdjustBarSize(lumberExp.Maxwidth, player.GetComponent<CharacterStats>().WoodCutting.GetExp(), player.GetComponent<CharacterStats>().WoodCutting.GetExpToLevel());
        lumberjackExpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(lumberExp.width, lumberExp.expbarSize.y);
        //fisher
        fisherExpLabel.text = string.Format("{0}/{1}", player.GetComponent<CharacterStats>().Fishing.GetExp(), player.GetComponent<CharacterStats>().Fishing.GetExpToLevel());
        fisherExp.width = AdjustBarSize(fisherExp.Maxwidth, player.GetComponent<CharacterStats>().Fishing.GetExp(), player.GetComponent<CharacterStats>().Fishing.GetExpToLevel());
        fisherExpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(fisherExp.width, fisherExp.expbarSize.y);
        //miner
        minerExpLabel.text = string.Format("{0}/{1}", player.GetComponent<CharacterStats>().Mining.GetExp(), player.GetComponent<CharacterStats>().Mining.GetExpToLevel());
        minerExp.width = AdjustBarSize(minerExp.Maxwidth, player.GetComponent<CharacterStats>().Mining.GetExp(), player.GetComponent<CharacterStats>().Mining.GetExpToLevel());
        minerExpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(minerExp.width, minerExp.expbarSize.y);

        //stats
        stats1.text = string.Format(
            "Health: {0}/{1}\n" +
            "Slime: {2}/{3}\n" +
            "Element Slots: {4}\n" +
            "Action Points: {5}/{6}",
            playerStats.healthCurrent.ToString(), playerStats.currentStats.health.ToString(),
            playerStats.slimeCurrent.ToString(), playerStats.currentStats.slime.ToString(),
            playerStats.currentStats.elementSlots.ToString(),
            playerStats.actionPointsCurent.ToString(), playerStats.currentStats.actionPoints.ToString());
        stats2.text = string.Format(
            "Res:\n" +
            "Fire    - {0}\n" +
            "Water   - {1}\n" +
            "Earth   - {2}\n" +
            "Wind    - {3}\n" +
            "Light   - {4}\n" +
            "Dark    - {5}\n" +
            "Neutral - {6}",
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Water].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Earth].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Wind].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Dark].ToString(),
            playerStats.currentStats.fixedDamageStats[DictionaryHolder.element.Neutral].ToString());
        stats3.text = string.Format(
            "Damage:\n" +
            "Fire    - {0}\n" +
            "Water   - {1}\n" +
            "Earth   - {2}\n" +
            "Wind    - {3}\n" +
            "Light   - {4}\n" +
            "Dark    - {5}\n" +
            "Neutral - {6}",
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Water].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Earth].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Wind].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Dark].ToString(),
            playerStats.currentStats.percentDamageStats[DictionaryHolder.element.Neutral].ToString());
        stats4.text = string.Format(
            "Damage(%):\n" +
            "Fire    - {0}%\n" +
            "Water   - {1}%\n" +
            "Earth   - {2}%\n" +
            "Wind    - {3}%\n" +
            "Light   - {4}%\n" +
            "Dark    - {5}%\n" +
            "Neutral - {6}%",
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Water].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Earth].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Wind].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Fire].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Dark].ToString(),
            playerStats.currentStats.fixedResStats[DictionaryHolder.element.Neutral].ToString());
    }

    //get the current correct bar size according to current and max value
    private float AdjustBarSize(float maxWidth, int value, int maxValue)
    {
        float size=(maxWidth*value) / maxValue;
        return size;
    }
}
