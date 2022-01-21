using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tobii.Gaming
{
    public class intro : MonoBehaviour
    {
        // Start is called before the first frame update
        public float stareTime = 1.0f;
        private Vector3 characterPos;
        private Vector3 characterScl;
        private Vector3 gaze;
        public GameObject buttonSound;


        void Start()
        {
            characterPos = this.gameObject.transform.position;
            characterScl = this.transform.localScale;
            stareTime = 1.0f;
        }

        void Update()
        {

            gaze = TrackEye.gazePositionWorld;
            float xMin = characterPos.x - 2f;
            float xMax = characterPos.x + 2f;
            float yMin = characterPos.y - 2f;
            float yMax = characterPos.y + 2f;



            if ((gaze.x >= xMin) && (gaze.x <= xMax) && (gaze.y >= yMin) && (gaze.y <= yMax))
            {
                stareTime -= Time.deltaTime;

            }
            else
            {
                stareTime = 1.0f;
            }

            if (stareTime <= 0)
            {
                buttonSound.GetComponent<AudioSource>().Play();

                SceneManager.LoadScene("Main");
            }


        }
    }
}
