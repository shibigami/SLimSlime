using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < InventorySystem.items.Count; i++)
        {
            
            if (InventorySystem.items[i].GetAmount() > 0)
            {
                if (!GameObject.Find(InventorySystem.items[i].GetName()))
                {
                    var item=Instantiate(InventorySystem.items[i].GetIcon(), transform);
                    item.name = InventorySystem.items[i].GetName();
                    item.SetActive(true);
                }
                GameObject.Find(InventorySystem.items[i].GetName()).GetComponentInChildren<Text>().text = "x" + InventorySystem.items[i].GetAmount().ToString();
                 
            }
        }
    }
}
