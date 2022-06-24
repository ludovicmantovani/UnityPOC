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
    [SerializeField] private TMP_Text _seedInfo;
    [SerializeField] private TMP_Text _enclosureInfo;
    [SerializeField] private TMP_Text _frutsInfo;
    [SerializeField] private TMP_Text _woolInfo;
    [SerializeField] private TMP_Text _tissuInfo;


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

        if (_levels != null && _levels.Count > 0)
        {
            DisplayLevelInfo(_levels[0]);
            if (_levels[0].sequence.Count > 0)
            {
                _currentTransaction = _levels[0].sequence[0];
                _doTransaction = true;
            }
        }
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

        if (_seedInfo && level.seedUnitPrice > 0)
        {
            _seedInfo.text = level.seedUnitPrice.ToString() + "€ / graine";
        }
        else
        {
            _seedInfo.text = "";
        }


        if (_enclosureInfo && level.enclosureUnitPrice > 0)
        {
            _enclosureInfo.text = level.enclosureUnitPrice.ToString() + "€ / enclos";
        }
        else
        {
            _enclosureInfo.text = "";
        }

        if (_frutsInfo && level.frutsUnitPrice > 0)
        {
            _frutsInfo.text = level.frutsUnitPrice.ToString() + "€ / fruit";
        }
        else
        {
            _frutsInfo.text = "";
        }

        if (_woolInfo && level.woolUnitPrice > 0)
        {
            _woolInfo.text = level.woolUnitPrice.ToString() + "€ / laine";
        }
        else
        {
            _woolInfo.text = "";
        }

        if (_tissuInfo && level.tissuUnitPrice > 0)
        {
            _tissuInfo.text = level.tissuUnitPrice.ToString() + "€ / tissu";
        }
        else
        {
            _tissuInfo.text = "";
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
            if (_levels[_levelIndex].nbr == 3)
            {
                if (_tissuProdGO)
                {
                    _tissuProdGO.SetActive(true);
                }
            }
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
        if (transaction.inputItem == Item.NONE ||
            _playerInventory.inventory[transaction.inputItem] >= transaction.inputQuantity)
        {
            if (transaction.inputItem != Item.NONE)
            {
                //On lui retire l'item
                _playerInventory.inventory[transaction.inputItem] -= transaction.inputQuantity;
            }
            
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
