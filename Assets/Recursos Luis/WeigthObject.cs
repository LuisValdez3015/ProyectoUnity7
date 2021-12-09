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
    [SerializeField] private WeightType type = WeightType.Medium;

    public WeightType Type => type;
}
