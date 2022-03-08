using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    protected bool isActive;
    public virtual bool IsBeingUse { get; protected set; }

    public void SetActive(bool value)
    {
        isActive = value;
    }
}
