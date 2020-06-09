using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemySystem : MonoBehaviour
{
    private Dictionary<int, Item> displayItems;
    private List<GameObject> displayItemsIcons;
    private InventorySystem playerInventory;
    public GameObject[] rarity;
    public GameObject contentWindow, alchemyBar,makeButton,modifyButton;
    public Text alchemyBarLabel;
    private float alchemyBarValue,alchemyBarSizeMax,alchemyBarSize;
    private List<Item> pottedItems;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
        displayItems = new Dictionary<int, Item>();
        displayItemsIcons = new List<GameObject>();
        alchemyBarValue = 0;
        pottedItems = new List<Item>();
        alchemyBarSizeMax = alchemyBar.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplayItems();

        alchemyBarLabel.text = alchemyBarValue.ToString();
        AdjustAlchemyBar();
    }

    private void AdjustAlchemyBar()
    {
        alchemyBarSize = ((alchemyBarSizeMax*alchemyBarValue)/100);
        alchemyBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, alchemyBarSize);
    }
    public void UpdateDisplayItems()
    {
        //go through players full inventory list
        foreach (KeyValuePair<int, Item> valPair in playerInventory.itemList)
        {
            //if the amount is bigger than 0, add to list
            if (valPair.Value.GetAmount() > 0)
            {
                if (displayItems.ContainsKey(valPair.Key)) displayItems[valPair.Key] = valPair.Value;
                else displayItems.Add(valPair.Key, valPair.Value);
            }
        }

        CleanUpZeroAmountItems();
        InstantiateItemIcons();
    }
    public void CleanUpZeroAmountItems()
    {
        List<int> removeIndexes = new List<int>();
        //go through items display list
        foreach (KeyValuePair<int, Item> valPair in displayItems)
        {
            //gets keys where amount is 0
            if (valPair.Value.GetAmount() <= 0)
            {
                removeIndexes.Add(valPair.Key);
            }
        }
        //remove at keys
        for (int i=0; i<removeIndexes.Count;i++) displayItems.Remove(removeIndexes[i]);
    }
    public void InstantiateItemIcons()
    {
        if (displayItems.Count > 0)
        {
            //goes through display items
            foreach (KeyValuePair<int, Item> item in displayItems)
            {
                //ignore non items item
                if (item.Value.GetRarity() > 0)
                {
                    //and instantiates if it doesnt exist or update if it does
                    if (GameObject.Find(item.Value.GetName() + "Alchemy"))
                    {
                        GameObject.Find(item.Value.GetName() + "Alchemy").GetComponentInChildren<Text>().text = item.Value.GetAmount().ToString();
                    }
                    else
                    {
                        displayItemsIcons.Add(Instantiate(rarity[item.Value.GetRarity() - 1], contentWindow.transform));
                        displayItemsIcons[displayItemsIcons.Count-1].name = item.Value.GetName() + "Alchemy";
                        displayItemsIcons[displayItemsIcons.Count - 1].GetComponentInChildren<Text>().text = item.Value.GetAmount().ToString();
                        displayItemsIcons[displayItemsIcons.Count - 1].GetComponent<AlchemyItem>().SetItem(item.Value);
                    }
                }
            }
        }
    }
    public void DestroyZeroAmountIcons(Item _item)
    {
        //get rid of icon if 0 amount
        if (_item.GetAmount() <= 0)
        {
            //indexes to destroy objects
            List<int> indexesToDestroy = new List<int>();
            //goes through icon list
            for (int i = 0; i < displayItemsIcons.Count; i++)
            {
                //if name and rarity is the same as the item in the items icon
                if ((displayItemsIcons[i].GetComponent<AlchemyItem>().GetItem().GetName() == _item.GetName()) && (displayItemsIcons[i].GetComponent<AlchemyItem>().GetItem().GetRarity() == _item.GetRarity()))
                {
                    indexesToDestroy.Add(i);
                }
            }
            //destroy
            foreach (int index in indexesToDestroy)
            {
                Destroy(displayItemsIcons[index]);

                //if its the last element or the only one
                if (index == displayItemsIcons.Count - 1)
                {
                    displayItemsIcons.RemoveAt(index);
                }
                else
                {
                    //adjust list
                    for (int i = index; i < displayItemsIcons.Count - 1; i++)
                    {
                        displayItemsIcons[i] = displayItemsIcons[i + 1];
                    }
                    //remove last element
                    displayItemsIcons.RemoveAt(displayItemsIcons.Count - 1);
                }
            }
        }
    }
    public void AddToPot(Item item)
    {
        //check if item can be added to the pot
        if (alchemyBarValue < 100)
        {
            //goes through each item in player inventory
            foreach (KeyValuePair<int, Item> _item in playerInventory.itemList)
            {
                //if its the same name and rarity
                if (_item.Value.GetName() == item.GetName())
                {
                    //add to pot
                    alchemyBarValue += _item.Value.GetRarity();
                    //take item
                    _item.Value.TakeAmount(1);
                    DestroyZeroAmountIcons(_item.Value);
                }
            }
            //clamp max value
            alchemyBarValue = Mathf.Clamp(alchemyBarValue, 0, 100);
        }
    }
}