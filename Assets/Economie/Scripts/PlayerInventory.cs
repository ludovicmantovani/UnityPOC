using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text _graineUI;
    [SerializeField] private TMP_Text _fruitUI;
    [SerializeField] private TMP_Text _laineUI;
    [SerializeField] private TMP_Text _tissuUI;
    [SerializeField] private TMP_Text _argentUI;

    private int _graine = 0;
    private int _fruit = 0;
    private int _laine = 0;
    private int _tissu = 0;
    private int _argent = 0;

    public int Graine
    {
        get => _graine;
        set
        {
            _graine = value;
            if (_graineUI)
            {
                _graineUI.text = value.ToString();
            }
        }
    }
    public int Fruit
    {
        get => _fruit;
        set
        {
            _fruit = value;
            if (_fruitUI)
            {
                _fruitUI.text = value.ToString();
            }
        }
    }
    public int Laine 
    {
        get => _laine;
        set
        {
            _laine = value;
            if (_laineUI)
            {
                _laineUI.text = value.ToString();
            }
        }
    }
    public int Tissu 
    {
        get => _tissu;
        set
        {
            _tissu = value;
            if (_tissuUI)
            {
                _tissuUI.text = value.ToString();
            }
        }
    }
    public int Argent 
    { 
        get => _argent;
        set
        {
            _argent = value;
            if (_argentUI)
            {
                _argentUI.text = value.ToString();
            }
        }
    }

    void Start()
    {
        _graineUI.text = _graine.ToString();
        _fruitUI.text = _fruit.ToString();
        _laineUI.text = _laine.ToString();
        _tissuUI.text = _tissu.ToString();
        _argentUI.text = _argent.ToString();
}

    void Update()
    {
        
    }
}
