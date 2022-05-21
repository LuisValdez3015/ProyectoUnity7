using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLever : MonoBehaviour
{

    int codeLength;
    int placeInCode;

    public string code = "";
    public string attempedCode;

    public Transform toOpen;

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attempedCode == code)
        {
            toOpen.Rotate(new Vector3(90, 0, 0), Space.World);
        }
        else
        {
            Debug.Log("Wrong Code");
        }
    }


    public void SetValue (string value)
    {
        placeInCode++;

        if(placeInCode <= codeLength)
        {
            attempedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attempedCode = "";
            placeInCode = 0;
        }    
    }

}
