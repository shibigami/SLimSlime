using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public string element;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QueueElement()
    {
        var fightwindowTemp = GameObject.FindGameObjectWithTag("FightWindow").GetComponent<FightManager>();
        //queue if queue phase
        if (fightwindowTemp.chooseElements)
        {
            fightwindowTemp.AddElementToQueue(element);
        }
    }
}
