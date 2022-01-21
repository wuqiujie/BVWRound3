using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class UI_5sec : MonoBehaviour
{
   
    public Image ImgTime;
    public float waitTime = 2.0f;

    private void Start()
    {
        waitTime = 2.0f;
        ImgTime.fillAmount = 0;
    }
    void Update()
    {
        ImgTime.fillAmount += 1.0f / waitTime * Time.deltaTime;
    }

    public void ResetTime() {
        ImgTime.fillAmount = 0;
    }
}