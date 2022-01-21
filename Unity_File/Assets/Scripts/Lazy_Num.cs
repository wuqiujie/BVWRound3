using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lazy_Num : MonoBehaviour
{
    public Text UI_LazyNum;
    public int LazyNum=0; 

    public void Update()
    {
    //    UI_LazyNum.text = LazyNum.ToString();
        //  Increase_num();
    }
    public void Start()
    {
        LazyNum = 0;
    }
    public void Increase_num() 
    {
        LazyNum++;
        Debug.Log(LazyNum);
        UI_LazyNum.text = LazyNum.ToString();
        // UIManager.UpdateTimeUI(LazyNum);
    }
}
