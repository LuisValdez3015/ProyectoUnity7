using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;

    [SerializeField] GameObject door;

    public AudioSource abrirPuerta;


    private void Start()
    {
        result = new int[] { 0, 0, 0, /*1 */};
        correctCombination = new int[] { 2, 1, 1, /*3*/ };
        LeverRotate.Rotated += CheckResults;
    }

    public void CheckResults(string leverName, int number)
    {
        switch (leverName)
        {
            case "Lever1":
                result[0] = number;
                break;
            case "Lever2":
                result[1] = number;
                break;
            case "Lever3":
                result[2] = number;
                break;
                //case "lever4": 
                //    result[3] = number; 
                //    break; 
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            door.transform.Rotate(new Vector3(0, 90, 0));
            abrirPuerta.Play();
        }
    }

    private void OnDestroy()
    {
        LeverRotate.Rotated -= CheckResults;
    }
}
