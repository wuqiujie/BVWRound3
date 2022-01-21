using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tobii.Gaming;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    int scrollThresholdX;

    [SerializeField]
    int scrollThresholdY;

    [SerializeField]
    float turnSpeed ;

    [SerializeField]
    float minPosition_x = -10;

    [SerializeField]
    float maxPosition_x = 20;

    [SerializeField]
    float minPosition_y = -7;

    [SerializeField]
    float maxPosition_y = 10;

    private void Update()
    {
        GazePoint gaze = TobiiAPI.GetGazePoint();
        if (gaze.IsValid)
        {
           float eyeX = gaze.Viewport.x - 0.5f;
           float eyeY = gaze.Viewport.y - 0.5f;

            float xPos = eyeX * canvas.renderingDisplaySize.x / canvas.scaleFactor;
            float yPos = eyeY * canvas.renderingDisplaySize.y / canvas.scaleFactor;
           
            // Handling head rotation
            float xPotation = mainCamera.transform.position.x;
            float yPotation = mainCamera.transform.position.y;

          
            
            if (yPos <= -(canvas.renderingDisplaySize.y / 2) / canvas.scaleFactor + scrollThresholdY)
            {

                yPotation -= turnSpeed * Time.deltaTime;
            }

            if (yPos >= (canvas.renderingDisplaySize.y / 2) / canvas.scaleFactor - scrollThresholdY)
            {
                yPotation += turnSpeed * Time.deltaTime;
            }

            if(xPos <= -(canvas.renderingDisplaySize.x / 2) / canvas.scaleFactor + scrollThresholdX)
            {
                xPotation -= turnSpeed * Time.deltaTime;
            }

            if(xPos >= (canvas.renderingDisplaySize.x / 2) / canvas.scaleFactor - scrollThresholdX)
            {
                xPotation += turnSpeed * Time.deltaTime;
            }
            /*
            //down
            if (yPotation >= eyeY )
            {
                yPotation -= turnSpeed;
            }
            //up
            if (yPotation <= eyeY+10 )
            {
                yPotation += turnSpeed;
            }

            //right
            if (xPotation <= eyeX )
            {
                xPotation += turnSpeed;
            }

            //left
            if (xPotation >= eyeX )
            {
                xPotation -= turnSpeed;
            }
            */

            if (xPotation > maxPosition_x) xPotation = maxPosition_x;
            if (xPotation < minPosition_x) xPotation = minPosition_x;
            if (yPotation > maxPosition_y) yPotation = maxPosition_y;
            if (yPotation < minPosition_y) yPotation = minPosition_y;

          //  xPotation = Mathf.Clamp(xPotation, minPosition_x, maxPosition_x);
            yPotation = Mathf.Clamp(yPotation, minPosition_y, maxPosition_y);

            mainCamera.transform.position = new Vector3 (xPotation, yPotation, 0);
        }
    }
}
