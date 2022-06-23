using System;
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


    public Dictionary<Item, int> inventory;

    void Start()
    {
        inventory = new Dictionary<Item, int>();

        inventory.Add(Item.fruit, 0);
        inventory.Add(Item.graine, 5);
        inventory.Add(Item.laine, 0);
        inventory.Add(Item.tissu, 0);
        inventory.Add(Item.argent, 0);
}

    void Update()
    {
        _graineUI.text = inventory[Item.graine].ToString() + " graine";
        _fruitUI.text = inventory[Item.fruit].ToString() + " fruit";
        _laineUI.text = inventory[Item.laine].ToString() + " laine";
        _tissuUI.text = inventory[Item.tissu].ToString() + " tissu";
        _argentUI.text = inventory[Item.argent].ToString() + " graine";
    }
}
