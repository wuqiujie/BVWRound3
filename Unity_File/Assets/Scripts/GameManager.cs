using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager Instance;
    // List<LazyStaff> lazystaffs;
    public float gameTime = 180f;

    public GameObject LN;
    AsyncOperation asyn;

    public bool isEnd;

    private void Update()
    {
       
        if (LN != null)
        {
            if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                UIManager.UpdateTimeUI(gameTime);
            }
            else if(!isEnd)
            {
                isEnd = true;
                //FindALL();
                StartCoroutine("waitAni");

            }

            if (LN.GetComponent<Lazy_Num>().LazyNum >= 5 && !isEnd)
            {
                isEnd = true;
                //FindALL();
                StartCoroutine("waitAni");
            }

        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        //    lazystaffs = new List<LazyStaff>();
    }
    /*
     public static void RegisterLS(LazyStaff LS)
     {
         if (!Instance.lazystaffs.Contains(LS))
         {
             Instance.lazystaffs.Add(LS);
         }
         UIManager.UpdateLSUI(Instance.lazystaffs.Count);
     }

     public static void PlayerFindLS(LazyStaff LS)
     {
         if (!Instance.lazystaffs.Contains(LS))
         {
             return;
         }
         Instance.lazystaffs.Remove(LS);
         if(Instance.lazystaffs.Count == 0)
         {
             FindALL();
         }
         UIManager.UpdateLSUI(Instance.lazystaffs.Count);
     } 
    */
    public static void FindALL()
    {
       // Instance.Invoke("EndScene", 2f);
        SceneManager.LoadScene("End");
    }

    void EndScene()
    {
        SceneManager.LoadScene("End");
    }
    


    IEnumerator waitAni()
    {
        //asyn = Application.LoadLevelAsync("End");
        //yield return asyn;
       
        yield return new WaitForSeconds(3.0f);
        FindALL();
    }
    
}
