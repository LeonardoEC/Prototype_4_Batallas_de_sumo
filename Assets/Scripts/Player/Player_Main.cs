using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    // Componentes
    Rigidbody _playerRigdBody;
    // Scirpt
    Player_Controller _playerController;
    Player_Detector _playerDectero;
    Player_Hit_Detector _playerHit;

    void LoadComponentes()
    {
        if(_playerRigdBody == null)
        {
            _playerRigdBody = GetComponent<Rigidbody>();
        }
        if(_playerController == null)
        {
            _playerController = GetComponentInChildren<Player_Controller>();
        }
        if (_playerDectero == null)
        {
            _playerDectero = GetComponentInChildren<Player_Detector>();
        }
        if( _playerHit == null)
        {
            _playerHit = GetComponentInChildren<Player_Hit_Detector>();
        }
    }


    void ExplicitsSuscription()
    {
        if(_playerController != null)
        {
            _playerController.playerRigidBody = _playerRigdBody;
        }
    }

    void SuscriptionBySignal()
    {
        if(_playerDectero != null )
        {
            // agregar array para guardar diferentes powerUP
            // aun mejor los powerups seran objetos contra los cuales colicionaremos
            // el detectro ejecutara una funcion que estara en modo escucha y recibira el powerup
            // lo almacenara en un array y los ira ejecutando
            // pero el efecto llega directamente desde el power up 
            // el player deberia de saber como usarlo ? o solo suscribir al cambio ?
            _playerDectero.hasowerUP = (bool active) =>
            {
                if (active) _playerController.ActivatePowerUp();
            };
        }
        
        if(_playerHit != null )
        {
            _playerHit.onHit = () => _playerController.hitForces();
        }
    }

    void SuscriptionByManagers()
    {
        if(Anchor_Manager.instance != null)
        {
            Anchor_Manager.instance.anchorTransform += (Transform anchor) =>
            {
                _playerController.anchorTransoform = anchor;
            };
        }

    }

    void PlayerDataEmiter()
    {
        if(Player_Manager.instance != null)
        {
            Player_Manager.instance.SetPlayerPosition(transform);
        }
    }

    void DeletPlayerDataEmiter()
    {
        if(Player_Manager.instance != null)
        {
            Player_Manager.instance.SetPlayerPosition(null);
        }
    }

    private void OnEnable()
    {
        LoadComponentes();
        SuscriptionByManagers();
        SuscriptionBySignal();
        ExplicitsSuscription();
        PlayerDataEmiter();
    }

    private void OnDisable()
    {
        DeletPlayerDataEmiter();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerController.HandleInpunts();
    }

    private void FixedUpdate()
    {
        _playerController.playerMovement();
    }
}
