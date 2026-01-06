using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [HideInInspector] public Rigidbody playerRigidBody;
    [HideInInspector] public Transform anchorTransoform;
    [HideInInspector] public bool powerUpActive;

    float _verticalInpunt;
    float _playerVelocitie = 0.2f;
    Coroutine _powerUpRountine;

    public GameObject powerUPEfect;

    public void HandleInpunts()
    {
        _verticalInpunt = Input.GetAxis("Vertical");
    }

    // resolver bug... el por mas que haya tomado el powerup el primer golpe siempre es 0 a partir del segundo y se aplica bien
    public float hitForces()
    {
        if(powerUpActive)
        {
            return 5f;
        }
        return 0f;
    }

    public void playerMovement()
    {
        if(anchorTransoform != null)
        {
            Vector3 direction = anchorTransoform.forward * _verticalInpunt * _playerVelocitie;
            playerRigidBody.AddForce(direction, ForceMode.Impulse);
        }
    }

    public IEnumerator PowerUPTimeOut()
    {
        if(powerUpActive)
        {
            powerUPEfect.gameObject.SetActive(true);
            yield return new WaitForSeconds(10f);
            powerUpActive = false;
            powerUPEfect.gameObject.SetActive(false);
        }
    }

    public void ActivatePowerUp()
    {
        powerUpActive = true;
        if(_powerUpRountine != null) StopCoroutine(_powerUpRountine);
        _powerUpRountine = StartCoroutine(PowerUPTimeOut());
    }
}
