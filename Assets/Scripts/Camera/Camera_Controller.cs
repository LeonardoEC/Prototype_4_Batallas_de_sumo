using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    float _cameraRotationSpeed = 50f;

    void SuscritionByManagerSignal()
    {
        if (Anchor_Manager.instance != null)
        {
            Anchor_Manager.instance.SetAnchor(transform);
        }
    }

    private void OnEnable()
    {
        SuscritionByManagerSignal();
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }


    void CameraRotation()
    {
        float _cameraHorizontal = -Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * _cameraRotationSpeed * Time.deltaTime * _cameraHorizontal);
    }
}
