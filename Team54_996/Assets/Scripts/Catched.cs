using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tobii.Gaming
{

    public class Catched : MonoBehaviour
    {
        // Start is called before the first frame update
        public float stareTime = 5.0f;
        private Vector3 characterPos;
        private Vector3 characterScl;
        private Vector3 gaze;
        void Start()
        {
            characterPos = this.gameObject.transform.position;
            Debug.Log(characterPos.x);
            characterScl = this.transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {
            gaze = TrackEye.gazePositionWorld;

            Debug.Log(stareTime);
            float xMin = characterPos.x - characterScl.x;
            float xMax = characterPos.x + characterScl.x;
            float yMin = characterPos.y - characterScl.y;
            float yMax = characterPos.y + characterScl.y;

            if ((gaze.x >= xMin) && (gaze.x <= xMax) && (gaze.y >= yMin) && (gaze.y <= yMax))
            {
                stareTime -= Time.deltaTime;
            }
            else
            {
                stareTime = 5;
            }

            if(stareTime <= 0)
            {
                stareTime = 100;
            }


        }
    }
}
