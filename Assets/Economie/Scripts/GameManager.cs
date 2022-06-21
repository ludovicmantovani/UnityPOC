using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;

    void Start()
    {
        if (_playerInventory)
        {
            _playerInventory.Graine = 5;
        }
    }

    void Update()
    {
        
    }
}
