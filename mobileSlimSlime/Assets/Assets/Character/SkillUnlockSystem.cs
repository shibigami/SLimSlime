using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUnlockSystem : MonoBehaviour
{
    private GameObject player;
    private CharacterSkillTree playerSkillTree;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSkillTree = player.GetComponent<CharacterSkillTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFireSkills() { UpdateSkills(DictionaryHolder.element.Fire); }
    public void UpdateWaterSkills() { UpdateSkills(DictionaryHolder.element.Water); }
    public void UpdateWindSkills() { UpdateSkills(DictionaryHolder.element.Wind); }
    public void UpdateEarthSkills() { UpdateSkills(DictionaryHolder.element.Earth); }
    public void UpdateLightSkills() { UpdateSkills(DictionaryHolder.element.Light); }
    public void UpdateDarkSkills() { UpdateSkills(DictionaryHolder.element.Dark); }
    public void UpdateNeutralSkills() { UpdateSkills(DictionaryHolder.element.Neutral); }

    public void UpdateSkills(DictionaryHolder.element element)
    {
        //go through active skills
        for (int i = 0; i < playerSkillTree.ActiveSkills().Count; i++)
        {
            //finds the ones that are the same element as the parameter
            if (playerSkillTree.ActiveSkills()[i]._element == element)
            {
                if (playerSkillTree.ActiveSkills()[i].unlockRequirements.AreRequirementsMet())
                {
                    playerSkillTree.activeSkills[i].Unlock();
                }
            }
        }
    }
}
