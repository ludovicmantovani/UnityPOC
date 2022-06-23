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
    [SerializeField] private GameObject _enclosureGO;
    [SerializeField] private List<LevelScriptableObject> _levels;
    [SerializeField] private TMP_Text _levelInfo;


    private bool _doTransaction = false;

    private int _levelIndex = 0;
    private int _sequenceIndex = 0;
    private TransactionScriptableObject _currentTransaction;

    void Start()
    {
        if (_enclosureGO)
        {
            _enclosureGO.SetActive(false);
        }
        if (_playerInventory)
        {
            _playerInventory.Graine = 5;
            _playerInventory.Fruit = 0;
            _playerInventory.Laine = 0;
            _playerInventory.Tissu = 0;
            _playerInventory.Argent = 0;
        }

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
        MakeTransaction(transaction.zone);
        if (transaction.outputItem == Item.enclos)
        {
            if (_enclosureGO)
            {
                _enclosureGO.SetActive(true);
            }
        }
    }

    private void MakeTransaction(Zone typeZone)
    {
        switch (typeZone)
        {
            case Zone.FRUTS:
                _playerInventory.Fruit += _playerInventory.Graine;
                _playerInventory.Graine = 0;
                break;
            case Zone.WOOL:
                _playerInventory.Laine += _playerInventory.Fruit;
                _playerInventory.Fruit = 0;
                break;
            case Zone.TISSUE:
                _playerInventory.Tissu += _playerInventory.Laine;
                _playerInventory.Laine = 0;
                break;
            case Zone.SALE:
                _playerInventory.Argent += _playerInventory.Laine;
                _playerInventory.Argent += _playerInventory.Tissu;
                _playerInventory.Argent += _playerInventory.Fruit;
                _playerInventory.Laine = 0;
                _playerInventory.Tissu = 0;
                _playerInventory.Fruit = 0;
                break;
            case Zone.PURCHASE:
                _playerInventory.Graine += _playerInventory.Argent;
                _playerInventory.Argent = 0;
                break;
            default:
                Debug.Log("Default");
                break;
        }
    }
}
