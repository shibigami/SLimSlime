using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    private Vector3 originalPosition,downPosition,upPosition;
    public float activationDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        upPosition = transform.position + new Vector3(0, 2, 0);
        transform.position -= new Vector3(0, 2, 0);
        downPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if its within activation distance
        if (((GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x) < activationDistance)
            && ((GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x) > -activationDistance))
        {
            //move towards walkable position
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, 0.5f);
        }
        //outside of activation distance
        else
        {
            //if it has Interact script
            if (GetComponent<Interact>())
            {
                //and has not been interacted with
                if (!GetComponent<Interact>().interacted)
                {
                    //go back down
                    transform.position = Vector3.MoveTowards(transform.position, downPosition, 0.5f);
                }
                //and has been interacted with
                else
                {
                    //go up
                    transform.position = Vector3.MoveTowards(transform.position, upPosition, 0.5f);
                }
            }
        }
    }
}
