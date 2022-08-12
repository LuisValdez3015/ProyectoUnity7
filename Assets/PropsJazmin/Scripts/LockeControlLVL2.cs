using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockeControlLVL2 : MonoBehaviour
{
    [SerializeField] GameObject siguienteLvl;
    [SerializeField] GameObject desactivarPared;

    private int[] result, correctCombination;

    private void Start()
    {
        result = new int[] { 0, 0, 0, 0};
        correctCombination = new int[] { 0, 1, 1, 1};
        LeverRotateLVL2.Rotated += CheckResults;
    }

    public void CheckResults(string leverName, int number)
    {
        switch (leverName)
        {
            case "Leever1":
                result[0] = number;
                break;
            case "Leever2":
                result[1] = number;
                break;
            case "Leever3":
                result[2] = number;
                break;
            case "Leever4":
                result[3] = number;
                break;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            desactivarPared.SetActive(false);
            siguienteLvl.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        LeverRotateLVL2.Rotated -= CheckResults;
    }
}
