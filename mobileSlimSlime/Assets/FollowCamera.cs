using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, cameraSpeed);
        tempPos.z = transform.position.z;
        transform.position = tempPos;

    }
}
