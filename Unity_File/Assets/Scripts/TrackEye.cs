using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tobii.Gaming
{
    public class TrackEye : MonoBehaviour
    {
        public static Vector3 gazePositionWorld = Vector3.zero;
        private Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            if (gazePoint.IsValid)
            {
                Vector2 gazePosition = gazePoint.Screen;
                gazePositionWorld = cam.ScreenToWorldPoint(new Vector3(gazePosition.x, gazePosition.y, cam.nearClipPlane));
            }
        }
    }
}
