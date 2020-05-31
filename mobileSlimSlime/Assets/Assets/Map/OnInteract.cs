using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Interact))]
[RequireComponent(typeof(ResourceGatheringManager))]

public class OnInteract : MonoBehaviour
{
    public GameObject progressbarText, progressbarImage;
    private GameObject _progressBarText, _progressBarImage;
    private float timer,loadBarMaxWidth;
    public float resourceTimer;
    public bool interacting;
    private GameObject player;
    public int GatheringExpGained;
    

    // Start is called before the first frame update
    void Start()
    {
        interacting = false;
        timer = 0;
        loadBarMaxWidth = progressbarImage.GetComponent<RectTransform>().sizeDelta.x;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((interacting)&& (timer == 0))
        {
            try
            {
                _progressBarImage = Instantiate(progressbarImage, GameObject.FindGameObjectWithTag("Canvas").transform);
                _progressBarImage.GetComponent<RectTransform>().position = new Vector3((Screen.currentResolution.width / 2) - (_progressBarImage.GetComponent<RectTransform>().sizeDelta.x / 2), Screen.currentResolution.height - _progressBarImage.GetComponent<RectTransform>().sizeDelta.y - 50, 0);
                _progressBarText = Instantiate(progressbarText, _progressBarImage.transform);
                _progressBarText.GetComponent<RectTransform>().position = new Vector3(_progressBarImage.transform.position.x, _progressBarImage.transform.position.y, -1);
                timer += 0.001f;
            }
            catch
            {
                throw new System.Exception("Error instantiating progress bar.");
            }
        }

        //interaction
        if ((timer > 0)&&(timer<=resourceTimer))
        {
            timer += Time.deltaTime;

            //ui display
            _progressBarText.GetComponent<Text>().text = (resourceTimer-timer).ToString("0.00")+" s";
            _progressBarImage.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, loadBarMaxWidth*(1 - (timer / resourceTimer)));
        }
        
        //gather resource and cleanup
        if (timer >= resourceTimer)
        {
            string item="";
            int amount=0;
            //interaction case
            switch (tag)
            {
                case "Farm":
                    {
                        GetComponent<ResourceGatheringManager>().GetResourceRoll(out item, out amount);
                        player.GetComponent<CharacterStats>().Farming.AddExp(GatheringExpGained);
                        break;
                    }
                case "Forest":
                    {
                        GetComponent<ResourceGatheringManager>().GetResourceRoll(out item, out amount);
                        player.GetComponent<CharacterStats>().WoodCutting.AddExp(GatheringExpGained);
                        break;
                    }
                case "Mine":
                    {
                        GetComponent<ResourceGatheringManager>().GetResourceRoll(out item, out amount);
                        player.GetComponent<CharacterStats>().Mining.AddExp(GatheringExpGained);
                        break;
                    }
                case "River":
                    {
                        GetComponent<ResourceGatheringManager>().GetResourceRoll(out item, out amount);
                        player.GetComponent<CharacterStats>().Fishing.AddExp(GatheringExpGained);
                        break;
                    }
                case "Chest":
                    {
                        GetComponent<ResourceGatheringManager>().GetResourceRoll(out item, out amount);
                        break;
                    }
                case "Monster":
                    {
                        //show window
                        GameObject.FindGameObjectWithTag("FightWindow").GetComponent<ShowHideWindow>().showHide = true;
                        //start fight state
                        GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().StartFight(gameObject.GetComponent<Enemy>());

                        break;
                    }
                case "Boss":
                    {
                        //set enemy
                        //show window
                        GameObject.FindGameObjectWithTag("FightWindow").GetComponent<ShowHideWindow>().showHide = true;
                        //start fight state
                        GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>().StartFight(gameObject.GetComponent<Enemy>());

                        break;
                    }
            }
            if (item != "")
            {
                //add to inventory
                InventorySystem.AddItem(item, amount);
                //take ap
                player.GetComponent<CharacterStats>().actionPointsCurent --;
            }


            //stop all interaction
            timer = -1;
            GetComponent<Interact>().interacted = true;
            interacting = false;

            //destroy
            Destroy(_progressBarImage);
            Destroy(_progressBarText);

            interacting = false;

            //advance time
            StoryProgressionManager.AddTime(1);
        }
    }
}