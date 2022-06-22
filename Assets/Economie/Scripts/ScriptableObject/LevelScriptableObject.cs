using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Economy/Level", order = 2)]
public class LevelScriptableObject : ScriptableObject
{
    public int level;
    public List<TransactionScriptableObject> _sequence;
}
