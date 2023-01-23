using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableListSO<T> : ScriptableObject
{
    public List<T> items = new List<T>();
}
