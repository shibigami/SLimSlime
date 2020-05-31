using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightWheel : MonoBehaviour
{
    private Quaternion pointAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //adjust angle
        if (gameObject.transform.rotation.z >= 360)
        {
            gameObject.transform.rotation = new Quaternion(0,0,0,0);
        }
        //update rotation
        Rotate();
    }

    private void Rotate()
    {
        //get angle per hour
        int exactAngle = (360 / 24) * StoryProgressionManager.GetCurrentTimeHours();
        //set location to achieve
        pointAngle = Quaternion.Euler(0,0,-exactAngle-180);
        //rotate
        transform.rotation = Quaternion.Lerp(transform.rotation, pointAngle, 0.01f);
    }
}
