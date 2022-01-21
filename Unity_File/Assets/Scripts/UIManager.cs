using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public Text LazyStaffText, timeText;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    public static void UpdateLSUI(int LSnum)
    {
        instance.LazyStaffText.text = LSnum.ToString();

    }
    public static void UpdateTimeUI(float time)
    {
        int min = (int)(time / 60);
        int sec = (int)(time % 60);
        instance.timeText.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
