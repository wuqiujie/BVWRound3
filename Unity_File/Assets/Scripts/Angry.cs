using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tobii.Gaming
{

    public class Angry : MonoBehaviour
    {
        // Start is called before the first frame update
        public float stareTime = 2.0f;
        private float appearTime = 3.0f;
        private bool isAngry = false;

        private Vector3 characterPos;
        private Vector3 gaze;
     

        public GameObject reaction;

        void Start()
        {
            characterPos = this.gameObject.transform.position;
            stareTime = 3.0f;
        }

        void Update()

        {

            gaze = TrackEye.gazePositionWorld;
            float xMin = characterPos.x - 0.6f;
            float xMax = characterPos.x + 0.6f;
            float yMin = characterPos.y - 1.2f;
            float yMax = characterPos.y + 1.2f;
          

            if ((gaze.x >= xMin) && (gaze.x <= xMax) && (gaze.y >= yMin) && (gaze.y <= yMax))
            {
                stareTime -= Time.deltaTime;
            }
            else
            {
                stareTime = 2.0f;
               

            }

            if (stareTime <= 0)
            {
                                
                reaction.gameObject.SetActive(true);
                isAngry = true;
                //reaction.GetComponent<AudioSource>().Play();

            }

            if (isAngry)
            {
                appearTime -= Time.deltaTime;
                if(appearTime <= 0)
                {
                    reaction.gameObject.SetActive(false);
                    isAngry = false;
                    appearTime = 3.0f;
                }
            }


        }

    }
}
