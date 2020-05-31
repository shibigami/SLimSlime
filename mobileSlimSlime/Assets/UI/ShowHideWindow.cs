using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideWindow : MonoBehaviour
{
    public GameObject showHideObject;
    public bool showHide;
    // Start is called before the first frame update
    void Start()
    {

        showHide = false;
    }

    // Update is called once per frame
    void Update()
    {
        //show hide
        showHideObject.SetActive(showHide);
    }

    public void ShowHide()
    {
        showHide = !showHide;
    }
}