using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private IAPlayerController _iAPlayerController;
    [SerializeField] private GameObject _laineProdGO;
    [SerializeField] private GameObject _tissuProdGO;
    [SerializeField] private List<LevelScriptableObject> _levels;
    [SerializeField] private TMP_Text _levelInfo;


    private bool _doTransaction = false;

    private int _levelIndex = 0;
    private int _sequenceIndex = 0;
    private TransactionScriptableObject _currentTransaction;

    void Start()
    {
        if (_laineProdGO)
        {
            _laineProdGO.SetActive(false);
        }
        if (_tissuProdGO)
        {
            _tissuProdGO.SetActive(false);
        }
        /*if (_playerInventory)
        {
            _playerInventory.inventory[Item.graine] = 5;
            _playerInventory.inventory[Item.fruit] = 0;
            _playerInventory.inventory[Item.laine] = 0;
            _playerInventory.inventory[Item.tissu] = 0;
            _playerInventory.inventory[Item.argent] = 0;
        }*/

        if (_levels != null && _levels.Count > 0)
        {
            DisplayLevelInfo(_levels[0]);
            if (_levels[0].sequence.Count > 0)
            {
                _currentTransaction = _levels[0].sequence[0];
                _doTransaction = true;
            }
        }



        /*for (int i = 0; i < _levels.Count; i++)
        {
            LevelScriptableObject _level = _levels[i];

            
            for (int x = 0; x < _level.sequence.Count; x++)
            {
                TransactionScriptableObject transaction = _level.sequence[x];
                // Si la destination du joueur 
            }
        }*/
    }



    void Update()
    {
        if (_doTransaction && _currentTransaction)
        {
            if (_iAPlayerController != null &&
                _currentTransaction.zone != _iAPlayerController.CurrentZone)
            {
                _iAPlayerController.CurrentZone = _currentTransaction.zone;
            }
        }
    }

    private void DisplayLevelInfo(LevelScriptableObject level)
    {
        if (_levelInfo)
        {
            string levelText = "Niveau " + level.nbr.ToString();
            _levelInfo.text = levelText;
            Debug.Log(levelText);
        }
    }
    public void OnZoneEnter(Zone typeZone)
    {
        /**if (_lastTypeZone == Zone.NONE || _lastTypeZone != typeZone)
        {
            _lastTypeZone = typeZone;
            Debug.Log("Entree en zone " + Enum.GetName(typeof(Zone), typeZone));
            MakeTransaction(typeZone);
        }**/

        if (typeZone == _currentTransaction.zone)
        {
            MakeTransaction(_currentTransaction);
            _doTransaction = NextTransaction();
            if (_doTransaction && typeZone == _currentTransaction.zone)
            {
                OnZoneEnter(typeZone);
            }
        }
    }

    private bool NextTransaction()
    {
        if (_levels[_levelIndex].sequence.Count > _sequenceIndex + 1)
        {
            _sequenceIndex++;
        }
        else if (_levels.Count > _levelIndex + 1 &&
            _levels[_levelIndex + 1].sequence.Count > 0)
        {
            _sequenceIndex = 0;
            _levelIndex++;
            DisplayLevelInfo(_levels[_levelIndex]);
        }
        else
        {
            return false;
        }
        _currentTransaction = _levels[_levelIndex].sequence[_sequenceIndex];
        return true;
    }

    private void MakeTransaction(TransactionScriptableObject transaction)
    {
        //MakeTransaction(transaction.zone);
        
        // Si l'utilisateur a ce qu'il faut d'item d'entre
        if (_playerInventory.inventory[transaction.inputItem] >= transaction.inputQuantity)
        {
            //On lui retire l'item
            _playerInventory.inventory[transaction.inputItem] -= transaction.inputQuantity;

            if (transaction.outputItem == Item.enclos)
            {
                if (_laineProdGO)
                {
                    _laineProdGO.SetActive(true);
                }
            }
            else if (transaction.outputItem != Item.NONE)
            {
                //On lui ajoute l'item
                _playerInventory.inventory[transaction.outputItem] += transaction.outputQuantity;
            }
        }
    }

    
}
