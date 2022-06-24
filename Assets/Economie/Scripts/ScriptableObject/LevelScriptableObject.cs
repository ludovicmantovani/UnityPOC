using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Economy/Level", order = 2)]
public class LevelScriptableObject : ScriptableObject
{
    public int nbr;
    public List<TransactionScriptableObject> sequence;
    public int seedUnitPrice;
    public int enclosureUnitPrice;
    public int frutsUnitPrice;
    public int woolUnitPrice;
    public int tissuUnitPrice;
}
