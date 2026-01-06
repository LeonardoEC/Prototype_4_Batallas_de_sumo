using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : MonoBehaviour
{
    Rigidbody _enemyRigidBody;

    Enemy_Controller _enemyController;
    Enemy_Detector _enemyDetector;

    void LoadEnemyComponentes()
    {
        if(_enemyRigidBody == null)
        {
            _enemyRigidBody = GetComponent<Rigidbody>();
        }
        if(_enemyController == null)
        {
            _enemyController = GetComponentInChildren<Enemy_Controller>();
        }
        if( _enemyDetector == null)
        {
            _enemyDetector = GetComponentInChildren<Enemy_Detector>();
        }
    }

    void ExplicitsSuscription()
    {
        if(_enemyRigidBody != null)
        {
            _enemyController.enemyRigidBody = _enemyRigidBody;
        }
    }

    void SuscriptionBySignas()
    {
    }

    void SuscriptionByManager()
    {
        if(Player_Manager.instance != null)
        {
            _enemyController.playerTransform = Player_Manager.instance.GetCurrentPlayerPosition();
        }
    }

    void OnSuscritionByManager()
    {

    }

    void OnSinglarExternalReception()
    {

    }

    private void OnEnable()
    {
        LoadEnemyComponentes();
        ExplicitsSuscription();
        SuscriptionBySignas();
        SuscriptionByManager();
    }

    private void Update()
    {
        _enemyController.EnemyLife();
    }

    private void FixedUpdate()
    {
        _enemyController.EnemyMovemente();
    }
}
