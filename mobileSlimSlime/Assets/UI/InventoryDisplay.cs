using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public GameObject[] rarity = new GameObject[5];
    public GameObject goldIcon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<int, Item> item in GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>().itemList)
        {
            //gold
            if(item.Key==0) GameObject.Find(item.Value.GetName()).GetComponentInChildren<Text>().text = item.Value.GetAmount().ToString();
            //not gold
            else
            {
                if (item.Value.GetAmount() > 0)
                {
                    //update text
                    if (GameObject.Find(item.Value.GetName())) GameObject.Find(item.Value.GetName()).GetComponentInChildren<Text>().text = item.Value.GetAmount().ToString();
                    //instantiate
                    else
                    {
                        var tempItem = Instantiate(rarity[item.Value.GetRarity() - 1], transform);
                        //set name
                        tempItem.name = item.Value.GetName();
                        //and show
                        tempItem.SetActive(true);
                    }
                }
                else
                {
                    //remove 0 amount items
                    if ((GameObject.Find(item.Value.GetName())) && (item.Key != 0)) Destroy((GameObject.Find(item.Value.GetName())));
                }
            }
        }
    }
}
