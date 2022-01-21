using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject success;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void successed()
    {
        success.GetComponent<AudioSource>().Play();
    }
}
