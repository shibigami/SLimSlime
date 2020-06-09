using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipPanel : MonoBehaviour
{
    public Text _name, _description, _comboString, _stats, _cost, _exp;
    public CharacterSkill skill;
    public Button increaseLevel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(skill!=null) UpdateToolTip();
    }

    public void UpdateToolTip()
    {
        _name.text = skill.Name();
        _description.text = skill.EffectDescription();
        _cost.text = string.Format("SP: {0}", skill.spCost);

        //combo string
        _comboString.text = "";
        if (skill._passive)
        {
            _comboString.text = "Passive";
            _cost.gameObject.SetActive(false);
        }
        else
        {
            _cost.gameObject.SetActive(true);
            for (int i = 0; i < skill.comboStr.Length; i++)
            {
                if (i > 0) _comboString.text += " + ";
                switch (skill.comboStr[i])
                {
                    case '1':
                        {
                            _comboString.text += "<color=red>Fire</color>";
                            break;
                        }
                    case '2':
                        {
                            _comboString.text += "<color=blue>Water</color>";
                            break;
                        }
                    case '3':
                        {
                            _comboString.text += "<color=brown>Earth</color>";
                            break;
                        }
                    case '4':
                        {
                            _comboString.text += "<color=green>Wind</color>";
                            break;
                        }
                    case '5':
                        {
                            _comboString.text += "<color=yellow>Light</color>";
                            break;
                        }
                    case '6':
                        {
                            _comboString.text += "<color=black>Dark</color>";
                            break;
                        }
                    case '7':
                        {
                            _comboString.text += "<color=gray>Neutral</color>";
                            break;
                        }
                }
            }
        }

        //stats
        _stats.text = "";

        #region StatsDisplay

        if (skill.statsCurrent.expPool > 0)
        {
            _stats.text += string.Format("Exp pool + {0}\n", skill.statsCurrent.expPool);
        }
        if (skill.statsCurrent.actionPoints > 0)
        {
            _stats.text += string.Format("Ap + {0}\n", skill.statsCurrent.actionPoints);
        }
        if (skill.statsCurrent.elementSlots > 0)
        {
            _stats.text += string.Format("Element slots + {0}\n", skill.statsCurrent.elementSlots);
        }
        if (skill.statsCurrent.health > 0)
        {
            _stats.text += string.Format("Health + {0}\n", skill.statsCurrent.health);
        }
        if (skill.statsCurrent.slime > 0)
        {
            _stats.text += string.Format("Slime + {0}\n", skill.statsCurrent.slime);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Fire] > 0)
        {
            _stats.text += string.Format("<color=red>Fire</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Fire]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Water] > 0)
        {
            _stats.text += string.Format("<color=blue>Water</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Water]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Wind] > 0)
        {
            _stats.text += string.Format("<color=green>Wind</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Wind]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Earth] > 0)
        {
            _stats.text += string.Format("<color=brown>Earth</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Earth]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Light] > 0)
        {
            _stats.text += string.Format("<color=yellow>Light</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Light]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Dark] > 0)
        {
            _stats.text += string.Format("<color=black>Dark</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Dark]);
        }
        if (skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Neutral] > 0)
        {
            _stats.text += string.Format("<color=gray>Neutral</color> damage + {0}\n", skill.statsCurrent.fixedDamageStats[DictionaryHolder.element.Neutral]);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Fire] > 0)
        {
            _stats.text += string.Format("<color=red>Fire</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Fire] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Water] > 0)
        {
            _stats.text += string.Format("<color=blue>Water</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Water] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Wind] > 0)
        {
            _stats.text += string.Format("<color=green>Wind</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Wind] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Earth] > 0)
        {
            _stats.text += string.Format("<color=brown>Earth</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Earth] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Light] > 0)
        {
            _stats.text += string.Format("<color=yellow>Light</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Light] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Dark] > 0)
        {
            _stats.text += string.Format("<color=black>Dark</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Dark] * 100);
        }
        if (skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Neutral] > 0)
        {
            _stats.text += string.Format("<color=gray>Neutral</color> damage + {0}%\n", skill.statsCurrent.percentDamageStats[DictionaryHolder.element.Neutral] * 100);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Fire] > 0)
        {
            _stats.text += string.Format("<color=red>Fire</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Fire]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Water] > 0)
        {
            _stats.text += string.Format("<color=blue>Water</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Water]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Earth] > 0)
        {
            _stats.text += string.Format("<color=brown>Earth</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Earth]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Wind] > 0)
        {
            _stats.text += string.Format("<color=green>Wind</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Wind]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Light] > 0)
        {
            _stats.text += string.Format("<color=yellow>Light</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Light]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Dark] > 0)
        {
            _stats.text += string.Format("<color=black>Dark</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Dark]);
        }
        if (skill.statsCurrent.fixedResStats[DictionaryHolder.element.Neutral] > 0)
        {
            _stats.text += string.Format("<color=gray>Neutral</color> resistance + {0}\n", skill.statsCurrent.fixedResStats[DictionaryHolder.element.Neutral]);
        }

        #endregion

        //decrease and increase exp buttons
        increaseLevel.interactable = (((GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().expPoolCurrent >= skill.LevelExp()) && (skill.CurrentLevel() < skill.MaxLevel()) && (!skill._alchemy)) ? true : false);

        //exp
        _exp.text = (string.Format("{0}", skill.LevelExp().ToString()));
    }
    public void Hide()
    {
            Empty();
    }
    public void SetToolTip(ToolTipPanel tooltip)
    {
        _name.text = tooltip._name.text;
        _description.text = tooltip._description.text;
        _comboString.text = tooltip._comboString.text;
        _stats.text = tooltip._stats.text;
        _cost.text = tooltip._cost.text;
        skill = tooltip.skill;
    }
    public void Empty()
    {
        _name.text = null;
        _description.text = null;
        _comboString.text = null;
        _stats.text = null;
        _cost.text = null;
        skill = null;
        increaseLevel.interactable = false;
        _exp.text = null;
    }
    public void AddExpToSkill()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().expPoolCurrent >= skill.LevelExp())
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterSkillTree>().ChangeSkillExp(skill,skill.LevelExp());
        }
    }
    public void TakeExpFromSkill()
    {
        if (skill != null)
        {
            if (skill.CurrentExp() > 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterSkillTree>().ChangeSkillExp(skill, -1);
            }
        }
    }
}
