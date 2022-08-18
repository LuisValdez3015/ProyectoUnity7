using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeighingMachine : MonoBehaviour
{
    [SerializeField] private int requiredWeight = 10;
    [SerializeField] private UnityEvent onWeightComplete = default;
    [SerializeField] private UnityEvent onWeightLose = default;
    private List<WeigthObject> weigthObjects;
    private bool alredyCompleted;
    public AudioSource cortinaDeHierro;



    private void Awake()
    {
        weigthObjects = new List<WeigthObject>();

    }

    private void OnTriggerEnter(Collider other)
    {
        var weightObject = other.GetComponent<WeigthObject>();
        if (weightObject == null)
        {
            return;
        }

        if (weigthObjects.Contains(weightObject)) return;

        weigthObjects.Add(weightObject);

        if (IsFull() && !alredyCompleted)
        {
            alredyCompleted = true;
            cortinaDeHierro.Play();
            onWeightComplete?.Invoke();
            Destroy(cortinaDeHierro, 2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var weightObject = other.GetComponent<WeigthObject>();
        if (weightObject == null)
        {
            return;
        }
        weigthObjects.Remove(weightObject);

        if (!IsFull() && alredyCompleted)
        {
            alredyCompleted = false;
            onWeightLose?.Invoke();
        }
    }

    public int CalculateCurrentWeight()
    {
        int currentWeight = 0;
        for (int i = 0; i < weigthObjects.Count; i++)
        {
            var weightObject = weigthObjects[i];
            currentWeight += (int)weightObject.Type;
        }
        return currentWeight;
    }
    private bool IsFull()
    {
        
        return CalculateCurrentWeight() >= requiredWeight;
    }
}
