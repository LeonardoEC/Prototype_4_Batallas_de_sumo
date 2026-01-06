using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public static Player_Manager instance { get; private set; }

    public System.Action<Transform> onplayerPosition;
    Transform _currentPlayerPosition;

    void InitaliceInstancePlayerManager()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Awake()
    {
        InitaliceInstancePlayerManager();
        TriggerPlayerPosition();
    }

    public void SetPlayerPosition(Transform position)
    {
        _currentPlayerPosition = position;
        TriggerPlayerPosition();
    }

    public void TriggerPlayerPosition()
    {
        if(_currentPlayerPosition != null)
        {
            onplayerPosition?.Invoke(_currentPlayerPosition);
        }
    }

    public Transform GetCurrentPlayerPosition()
    {
        if (_currentPlayerPosition == null)
        {
            Debug.LogWarning("Player transform no disponible");
        }

        return _currentPlayerPosition;
    }


}
