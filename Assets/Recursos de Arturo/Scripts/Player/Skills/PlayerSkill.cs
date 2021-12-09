using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    protected bool isActive;

    public void SetActive(bool value)
    {
        isActive = value;
    }
}
