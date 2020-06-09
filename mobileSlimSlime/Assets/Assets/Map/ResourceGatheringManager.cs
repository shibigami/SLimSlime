using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGatheringManager : MonoBehaviour
{
    private int resourceId;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void GetResourceID()
    {
        var charStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();

        switch (tag)
        {
            case "Chest":
                {
                    resourceId = 0;
                    break;
                }
            case "River":
                {
                    switch (charStats.Fishing.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceId = 1;
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceId = 2;
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceId = 3;
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceId = 4;
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceId = 5;
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
                                resourceId = 6;
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceId = 7;
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceId = 8;
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceId = 9;
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceId = 10;
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
                                resourceId = 11;
                                break;
                            }
                        case var lvl when lvl >= 10 && lvl < 20:
                            {
                                resourceId = 12;
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceId = 13;
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceId = 14;
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceId = 15;
                                break;
                            }
                    }

                    break;
                }
            case "Farm":
                {
                    switch (charStats.Farming.GetLevel())
                    {
                        case var lvl when lvl < 10:
                            {
                                resourceId = 16;
                                break;
                            }
                        case var lvl when lvl >=10 && lvl<20:
                            {
                                resourceId = 17;
                                break;
                            }
                        case var lvl when lvl >= 20 && lvl < 30:
                            {
                                resourceId = 18;
                                break;
                            }
                        case var lvl when lvl >= 30 && lvl < 40:
                            {
                                resourceId = 19;
                                break;
                            }
                        case var lvl when lvl >= 40:
                            {
                                resourceId = 20;
                                break;
                            }
                    }

                    break;
                }
        }
    }

    public void GetResourceRoll(CharacterJobClass.JobList job,out int resourceID,out int resourceamount)
    {
        CharacterStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        GetResourceID();
        resourceID = resourceId;

        switch (job)
        {
            case CharacterJobClass.JobList.Farmer:
                {
                    resourceamount = Random.Range(player.Farming.GetMinGather(), player.Farming.GetMaxGather() + 1);
                    break;
                }
            case CharacterJobClass.JobList.Fisherman:
                {
                    resourceamount = Random.Range(player.Fishing.GetMinGather(), player.Fishing.GetMaxGather() + 1);
                    break;
                }
            case CharacterJobClass.JobList.Miner:
                {
                    resourceamount = Random.Range(player.Mining.GetMinGather(), player.Mining.GetMaxGather() + 1);
                    break;
                }
            case CharacterJobClass.JobList.WoodCutter:
                {
                    resourceamount = Random.Range(player.WoodCutting.GetMinGather(), player.WoodCutting.GetMaxGather() + 1);
                    break;
                }
            case CharacterJobClass.JobList.None:
                {
                    resourceamount = 1;
                    break;
                }
            default:
                {
                    resourceamount = 0;
                    break;
                }
        }
    }
}
