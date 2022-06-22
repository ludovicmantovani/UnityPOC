using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New transaction", menuName = "Economy/Transaction", order = 1)]
public class TransactionScriptableObject : ScriptableObject
{
    public Zone zone = Zone.NONE;
    public Item inputItem = Item.NONE;
    public int inputQuantity = 0;
    public Item outputItem = Item.NONE;
    public int unitPrice = 0;
}
