using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    //대상과 거리
    public Transform target;
    public float dist = 10f;

    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;

    private float x, y = 0.0f;

    private float CamX = 0.0f;
    public float yMinLimit = 20f;
    public float yMaxLimit = 90f;

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
        
    }

    private Transform cam;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Horizontal") * xSpeed * 0.02f;
            y -= Input.GetAxis("Vertical") * ySpeed * 0.02f;
            
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0.0f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

            transform.rotation = rotation;
            transform.position = position;

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (y != 90.0f)
                {
                    CamX = y;
                    y = 90.0f;
                }
                else
                {
                    y = CamX;
                }
            }
        }
    }
}
