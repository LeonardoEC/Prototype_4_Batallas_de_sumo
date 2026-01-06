using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [HideInInspector]public Rigidbody enemyRigidBody;
    [HideInInspector]public Transform playerTransform;

    float enemySpeed = 2.0f;
    bool isHit;
    float hitforce;

    public void SetHit(System.Func<float> hitForceFunc, bool playerHit)
    {
        if (hitForceFunc != null)
        {
            isHit = playerHit;
            hitforce = hitForceFunc(); // se invoca en el contexto del receptor
        }
    }

    public void StopHit()
    {
        isHit=false;
    }

    public void EnemyMovemente()
    {
        if (playerTransform != null && isHit == false)
        {
            Debug.Log("Me estoy moviendo");
            enemyRigidBody.AddForce((playerTransform.position - transform.parent.position).normalized * enemySpeed);
        }
        else if(isHit == true)
        {
            Debug.Log("Me estan golpeando " + hitforce);
            enemyRigidBody.AddForce((transform.parent.position - playerTransform.position).normalized * hitforce, ForceMode.Impulse);
            // isHit = false;
        }
    }

    public void EnemyLife()
    {
        if(transform.parent.position.y < -10)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }

    // No funciona por que solo desactiva el mesh, era solo una prueba
    /*
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    */
}
