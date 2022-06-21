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
            Debug.Log("La player est entré dans la zone " + gameObject.transform.parent.gameObject.name);
        }
    }
}
