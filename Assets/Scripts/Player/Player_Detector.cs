using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detector : MonoBehaviour
{
    public System.Action<bool> hasowerUP;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power_UP"))
        {
            hasowerUP?.Invoke(true);
            other.gameObject.SetActive(false);
        }
    }
}
