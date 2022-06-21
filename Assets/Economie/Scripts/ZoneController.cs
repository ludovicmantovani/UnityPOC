using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    [SerializeField] private Zones _zoneType;
    [SerializeField] private GameManager _gameManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_gameManager)
            {
                _gameManager.OnZoneEnter(_zoneType);
            }
        }
    }
}
