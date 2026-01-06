using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor_Manager : MonoBehaviour
{
    public static Anchor_Manager instance { get; private set; }

    public System.Action<Transform> anchorTransform;
    Transform _currentAnchorTransform;

    void InitialicezedAnchorManager()
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
        InitialicezedAnchorManager();
        TriggerAnchorTransform();
    }

    public void SetAnchor(Transform anchor)
    {
        _currentAnchorTransform = anchor;
        TriggerAnchorTransform();
    }

    public void TriggerAnchorTransform()
    {
        if (_currentAnchorTransform != null)
        {
            anchorTransform?.Invoke(_currentAnchorTransform);
        }
    }

}
