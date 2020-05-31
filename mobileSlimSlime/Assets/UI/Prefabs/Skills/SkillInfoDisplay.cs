using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillInfoDisplay : MonoBehaviour
{
    public Text lvl, currentExp, passive;
    public List<Image> comboStringImageList;
    public List<Sprite> elementIcons;
    public CharacterSkill charSkill;
    public GameObject tooltip;

    // Start is called before the first frame update
    void Start()
    {
        tooltip = Instantiate(tooltip, transform);
        tooltip.GetComponent<ToolTipPanel>().skill = charSkill;
        tooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tooltip.GetComponent<ToolTipPanel>().UpdateToolTip();
        UpdateInfoDisplay();
    }

    public void UpdateInfoDisplay()
    {
        //if its unlocked
        if (charSkill._unlocked)
        {
            //tooltip update
            tooltip.GetComponent<ToolTipPanel>().skill = charSkill;
            //show
            gameObject.SetActive(true);
            //show lvl
            lvl.text = string.Format("Lvl.{0}", charSkill.CurrentLevel().ToString());
            //show exp
            currentExp.text = string.Format("{0}/{1}", charSkill.CurrentExp(), charSkill.LevelExp());
            //show passive
            if (charSkill._passive)
            {
                passive.text = "Passive";

                //disable excess combo string images
                for (int i = 0; i < comboStringImageList.Count; i++)
                {
                    comboStringImageList[i].gameObject.SetActive(false);
                }
            }
            else
            {
                passive.text = "";

                //temp for cicling through combo string images
                int combImage = 0;
                //combo string panel show icons
                for (int i = 0; i < charSkill.comboStr.Length; i++)
                {
                    if (charSkill.comboStr[i] =='1') comboStringImageList[combImage].sprite = elementIcons[0];
                    if (charSkill.comboStr[i] =='2') comboStringImageList[combImage].sprite = elementIcons[1];
                    if (charSkill.comboStr[i] =='3') comboStringImageList[combImage].sprite = elementIcons[2];
                    if (charSkill.comboStr[i] =='4') comboStringImageList[combImage].sprite = elementIcons[3];
                    if (charSkill.comboStr[i] =='5') comboStringImageList[combImage].sprite = elementIcons[4];
                    if (charSkill.comboStr[i] =='6') comboStringImageList[combImage].sprite = elementIcons[5];
                    if (charSkill.comboStr[i] =='7') comboStringImageList[combImage].sprite = elementIcons[6];
                    combImage++;
                }

                //disable excess images
                for (int i = 0; i < comboStringImageList.Count; i++)
                {
                    if (i >= charSkill.comboStr.Length)
                    {
                        comboStringImageList[i].gameObject.SetActive(false);
                    }
                    else
                    {
                        comboStringImageList[i].gameObject.SetActive(true);
                    }
                }
            }
        }
        else
        {
            //hide
            gameObject.SetActive(false);
        }
    }
    public void DisplayToolTip()
    {
        GameObject.FindGameObjectWithTag("SkillsToolTip").GetComponent<ToolTipPanel>().SetToolTip(tooltip.GetComponent<ToolTipPanel>());
    }
}