using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public bool fade;
    private float timerTick;

    // Start is called before the first frame update
    void Start()
    {
        fade = false;
        timerTick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            GetComponent<Image>().raycastTarget = true;
            var tempColor = GetComponent<Image>().color;
            tempColor.a += 0.4f;
            tempColor.a = Mathf.Clamp(tempColor.a, 0, 1f);
            GetComponent<Image>().color = tempColor;
            if (tempColor.a > 0.99f) fade = false;
        }
        else
        {
            if (timerTick <= 0)
            {
                var tempColor = GetComponent<Image>().color;
                tempColor.a -= 0.01f;
                tempColor.a = Mathf.Clamp(tempColor.a, 0, 1f);
                GetComponent<Image>().color = tempColor;
                if (tempColor.a < 0.01f) GetComponent<Image>().raycastTarget = false;
            }
            else
            {
                timerTick -= Time.deltaTime;
            }
        }
    }

    public void Fade(float time)
    {
        fade = true;
        timerTick = time;
    }
}
