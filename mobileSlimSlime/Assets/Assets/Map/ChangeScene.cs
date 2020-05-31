using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Interact))]

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Interact>().interacted)
        {
            SceneManager.LoadScene(sceneName);
        }   
    }
}
