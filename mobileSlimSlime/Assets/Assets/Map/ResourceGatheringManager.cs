using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatheringManager : MonoBehaviour
{
    private string resourceName;
    public int minAmount,maxAmount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void GetResourceRarity()
    {
        var charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

        switch (tag)
        {
            case "Chest":
                {
                    resourceName = "Gold";
                    break;
                }
            case "Farm":
                {
                    switch (charStats.Farming.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceName = "Wheat *";
                                break;
                            }
                        case var lvl when lvl >=10 && lvl<20:
                            {
                                resourceName = "Wheat **";
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceName = "Wheat ***";
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceName = "Wheat ****";
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceName = "Wheat *****";
                                break;
                            }
                    }

                    break;
                }
            case "River":
                {
                    switch (charStats.Fishing.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceName = "Fish *";
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceName = "Fish **";
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceName = "Fish ***";
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceName = "Fish ****";
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceName = "Fish *****";
                                break;
                            }
                    }

                    break;
                }
            case "Mine":
                {
                    switch (charStats.Mining.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceName = "Iron *";
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceName = "Iron **";
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceName = "Iron ***";
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceName = "Iron ****";
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceName = "Iron *****";
                                break;
                            }
                    }

                    break;
                }
            case "Forest":
                {
                    switch (charStats.WoodCutting.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceName = "Wood *";
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceName = "Wood **";
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceName = "Wood ***";
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceName = "Wood ****";
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceName = "Wood *****";
                                break;
                            }
                    }

                    break;
                }
        }
    }

    public void GetResourceRoll(out string resourcename,out int resourceamount)
    {
        GetResourceRarity();
        resourcename = resourceName;
        resourceamount = Random.Range(minAmount, maxAmount+1);
    }
}
