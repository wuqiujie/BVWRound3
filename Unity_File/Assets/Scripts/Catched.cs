using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tobii.Gaming
{

    public class Catched : MonoBehaviour
    {
        // Start is called before the first frame update
        public float stareTime = 2.0f;
        private Vector3 characterPos;
        private Vector3 characterScl;
        private Vector3 gaze;
        public GameObject num;
        public GameObject circle;
        public GameObject reaction;
        public GameObject audioManager;

        void Start()
        {
            characterPos = this.gameObject.transform.position;
            characterScl = this.transform.localScale;
            stareTime = 2.0f;
        }

        void Update()
        {
        
            gaze = TrackEye.gazePositionWorld;
            float xMin = characterPos.x - 0.7f;
            float xMax = characterPos.x + 0.7f;
            float yMin = characterPos.y - 1.2f;
            float yMax = characterPos.y + 1.2f;
            
            if ((gaze.x >= xMin) && (gaze.x <= xMax) && (gaze.y >= yMin) && (gaze.y <= yMax))
            {
                stareTime -= Time.deltaTime;
                circle.gameObject.SetActive(true);
            }
            else
            {
                stareTime = 2.0f;
                circle.gameObject.SetActive(false);
                circle.GetComponent<UI_5sec>().ResetTime();

            }

            if (stareTime <= 0)
            {
                num.GetComponent<Lazy_Num>().Increase_num();
                audioManager.GetComponent<AudioManager>().successed();
               
                gameObject.SetActive(false);
                circle.gameObject.SetActive(false);
                reaction.gameObject.SetActive(true);
                reaction.GetComponent<AudioSource>().Play();
                circle.GetComponent<UI_5sec>().ResetTime();
            }


        }
        
    }
}
