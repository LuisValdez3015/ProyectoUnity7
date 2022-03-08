using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeightType
{
    Light = 2,
    Medium =5,
    Heavy=8,
    Superheavy=50
}

public class WeigthObject : MonoBehaviour
{
    [SerializeField] protected WeightType type = WeightType.Medium;

    public WeightType Type => type;
}

