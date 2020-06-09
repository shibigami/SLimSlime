using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUnlockSystem : MonoBehaviour
{
    private GameObject player;
    private CharacterSkillTree playerSkillTree;
    public GameObject fireButton, waterButton, earthButton, windButton, lightButton, darkButton, neutralButton;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSkillTree = player.GetComponent<CharacterSkillTree>();
    }

    // Update is called once per frame
    void Update()
    {
        fireButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Fire));
        waterButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Water));
        windButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Wind));
        earthButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Earth));
        lightButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Light));
        darkButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Dark));
        neutralButton.SetActive(CanUpdateSkills(DictionaryHolder.element.Neutral));
    }

    public void UpdateFireSkills() { UpdateSkills(DictionaryHolder.element.Fire); StoryProgressionManager.AddTime(6); }
    public void UpdateWaterSkills() { UpdateSkills(DictionaryHolder.element.Water); StoryProgressionManager.AddTime(6); }
    public void UpdateWindSkills() { UpdateSkills(DictionaryHolder.element.Wind); StoryProgressionManager.AddTime(6); }
    public void UpdateEarthSkills() { UpdateSkills(DictionaryHolder.element.Earth); StoryProgressionManager.AddTime(6); }
    public void UpdateLightSkills() { UpdateSkills(DictionaryHolder.element.Light); StoryProgressionManager.AddTime(6); }
    public void UpdateDarkSkills() { UpdateSkills(DictionaryHolder.element.Dark); StoryProgressionManager.AddTime(6); }
    public void UpdateNeutralSkills() { UpdateSkills(DictionaryHolder.element.Neutral); StoryProgressionManager.AddTime(6); }

    public void UpdateSkills(DictionaryHolder.element element)
    {
        //go through active skills
        for (int i = 0; i < playerSkillTree.ActiveSkills().Count; i++)
        {
            //finds the ones that are the same element as the parameter
            if (playerSkillTree.ActiveSkills()[i]._element == element)
            {
                if (playerSkillTree.ActiveSkills()[i].unlockRequirements.AreRequirementsMet(StoryProgressionManager.currentRequirementProgress))
                {
                    playerSkillTree.activeSkills[i].Unlock();
                }
            }
        }
        //go through passive skills
        for (int i = 0; i < playerSkillTree.PassiveSkills().Count; i++)
        {
            //finds the ones that are the same element as the parameter
            if (playerSkillTree.PassiveSkills()[i]._element == element)
            {
                if (playerSkillTree.PassiveSkills()[i].unlockRequirements.AreRequirementsMet(StoryProgressionManager.currentRequirementProgress))
                {
                    playerSkillTree.passiveSkills[i].Unlock();
                }
            }
        }
    }

    private bool CanUpdateSkills(DictionaryHolder.element element)
    {
        bool canupgrade = false;
        //go through active skills
        for (int i = 0; i < playerSkillTree.ActiveSkills().Count; i++)
        {
            //finds the ones that are the same element as the parameter
            if (playerSkillTree.ActiveSkills()[i]._element == element)
            {
                if (playerSkillTree.ActiveSkills()[i].unlockRequirements.AreRequirementsMet(StoryProgressionManager.currentRequirementProgress))
                {
                    canupgrade = true;
                }
            }
        }
        //go through passive skills
        for (int i = 0; i < playerSkillTree.PassiveSkills().Count; i++)
        {
            //finds the ones that are the same element as the parameter
            if (playerSkillTree.PassiveSkills()[i]._element == element)
            {
                if (playerSkillTree.PassiveSkills()[i].unlockRequirements.AreRequirementsMet(StoryProgressionManager.currentRequirementProgress))
                {
                    canupgrade = true;
                }
            }
        }

        return canupgrade;
    }
}
