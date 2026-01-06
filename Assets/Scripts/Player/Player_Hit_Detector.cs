using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit_Detector : MonoBehaviour
{

    public System.Func<float> onHit;

    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInChildren<Enemy_Controller>().SetHit(onHit, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInChildren<Enemy_Controller>().StopHit();
        }
    }
}
