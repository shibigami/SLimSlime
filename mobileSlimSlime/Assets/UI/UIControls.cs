using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public float movementSpeed, moveDistance;
    private bool movedRight;
    public GameObject interactButton,moveLeftButton,moveRightButton,decreaseMapButton,increaseMapButton;
    private Vector3 moveCast;
    private GameObject player;
    private Collider2D[] colliders;

    public void MoveToEntrance()
    {
        moveCast.x = GameObject.FindGameObjectWithTag("Entrance").transform.position.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveCast = player.transform.position;
        interactButton.SetActive(false);
        movedRight = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        //if its not where its supposed to be
        if (moveCast.x != player.transform.position.x)
        {
            //disable controls and interaction button
            ControlsEnabled(false);
            InteractionEnabled(false);
            //make player move towards move cast
            player.transform.position = Vector3.MoveTowards(player.transform.position, moveCast, movementSpeed);
        }
        else
        {
            //interact
            colliders = Physics2D.OverlapCircleAll(player.transform.position, 0.3f);
            if (colliders != null)
            {
                foreach (Collider2D col in colliders)
                {
                    if (col != GameObject.FindGameObjectWithTag("Player"))
                    {
                        //if its colliding can move
                        ControlsEnabled(true);
                    }

                    //check if its a wall
                    if (col.gameObject.tag == "Wall")
                    {
                        if (movedRight)
                        {
                            moveRightButton.SetActive(false);
                        }
                        else
                        {
                            moveLeftButton.SetActive(false);
                        }
                    }
                    //not a wall? can move
                    else
                    {
                        ControlsEnabled(true);
                    }

                    //check if not interacted
                    if (col.GetComponent<Interact>())
                    {
                        //disable interaction button
                        if ((col.GetComponent<Interact>().interacted) || (col.GetComponent<OnInteract>().interacting))
                        {
                            InteractionEnabled(false);
                        }
                        //show interaction button
                        else
                        {
                            InteractionEnabled(true);

                            //update increase/decrease map button
                            UpdateInDeCreaseMapSizeButtons();
                        }
                        //if its interacting disable controls
                        //otherwise enable controls
                        ControlsEnabled(!col.GetComponent<OnInteract>().interacting);
                    }
                }
            }
            //if colliders are not present
            else
            {
                //disable interaction button
                InteractionEnabled(false);
            }
        }
    }

    public void MoveLeft()
    {
        moveCast = new Vector3(-moveDistance, 0, 0);
        moveCast += player.transform.position;
        movedRight = false;
        ControlsEnabled(false);

        //advance time
        StoryProgressionManager.AddTime(1);
    }
    public void MoveRight()
    {
        moveCast = new Vector3(moveDistance, 0, 0);
        moveCast += player.transform.position;
        movedRight = true;
        ControlsEnabled(false);

        //advance time
        StoryProgressionManager.AddTime(1);
    }
    public void Up()
    {
        foreach (Collider2D col in colliders)
        {
            if (col.GetComponent<OnInteract>())
            {
                if (!col.GetComponent<OnInteract>().interacting)
                {
                    col.GetComponent<OnInteract>().interacting = true;
                }
            }
        }
    }
    public void ControlsEnabled(bool value)
    {
        moveLeftButton.SetActive(value);
        moveRightButton.SetActive(value);
    }
    public void InteractionEnabled(bool value)
    {
        interactButton.SetActive(value);
    }
    public void MoveTo(Vector2 moveToPoint)
    {
        moveCast = moveToPoint;
    }
    public string GetInteractableObjectTag() 
    {
        try
        {
            if (colliders.Length > 1) return colliders[1].tag;
            else return "";
        }
        catch
        {
            Debug.Log("error in colliders");
            return "";
        }
    }
    public bool IsNearDoor()
    {
        if (colliders[1].tag == "Door") return true;
        else return false;
    }
    public bool IsNearSkillUnlockStation()
    {
        if (colliders[1].tag == "SkillUnlockStation") return true;
        else return false;
    }
    public bool IsNearAlchemyStation()
    {
        if (colliders[1].tag == "AlchemyStation") return true;
        else return false;
    }
    public void IncreaseMapSize()
    {
        StoryProgressionManager.IncrementMapSize(1);
    }
    public void DecreaseMapSize()
    {
        StoryProgressionManager.IncrementMapSize(-1);
    }
    private void UpdateInDeCreaseMapSizeButtons()
    {
        increaseMapButton.GetComponent<Button>().interactable=((StoryProgressionManager.GetMapSize() + 1 > StoryProgressionManager.GetMapSizeMaxUnlocked()) ? false : true);
        decreaseMapButton.GetComponent<Button>().interactable = ((StoryProgressionManager.GetMapSize() - 1 <=0) ? false : true);
    }
    public void ReturnHome()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().actionPointsCurent = 0;
    }
}
