using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Balance : MonoBehaviour
{
    [SerializeField] private WeighingMachine leftMachine = default;
    [SerializeField] private WeighingMachine rigthMachine = default;

    [SerializeField] private UnityEvent onEqualWeight;
    [SerializeField] private UnityEvent onRightWeight;
    [SerializeField] private UnityEvent onLeftWeight;

    public void Update()
    {
        Evaluate();
    }

    public void Evaluate()
    {
        int leftValue = leftMachine.CalculateCurrentWeight();
        int rigthValue = rigthMachine.CalculateCurrentWeight();


        if (leftValue == rigthValue)
        {
            //Animar la balanza para que este a la misma altura
            onEqualWeight.Invoke();

        }
        else if (leftValue > rigthValue)
        {
            //Animar la balanza izq para que este abajo porque es la mas pesada
            onLeftWeight.Invoke();


        }
        else if (rigthValue > leftValue)
        {
            //Animar la balanza derecha para que este abajo porque es la mas pesada
            onRightWeight.Invoke();


        }
    }
}
