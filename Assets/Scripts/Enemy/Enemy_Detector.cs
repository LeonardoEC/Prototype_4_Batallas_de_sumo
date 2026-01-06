using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Detector : MonoBehaviour
{
    public System.Action<Transform> hitDirection;
    private void OnTriggerEnter(Collider other)
    {
    }
}
