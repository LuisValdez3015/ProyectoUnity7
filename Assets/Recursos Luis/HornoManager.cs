using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornoManager : MonoBehaviour
{
    [SerializeField] Horno horno1;
    [SerializeField] Horno horno2;
    [SerializeField] Horno horno3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (horno1.TemperatureOnPoint == 3 && horno2.TemperatureOnPoint == 3 && horno3.TemperatureOnPoint == 3)
        {
            Debug.Log("Humo");
            //Animacion De Humo

        }
        else
        {
            return;
        }
    }
}
