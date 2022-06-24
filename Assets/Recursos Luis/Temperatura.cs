using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperatura : MonoBehaviour
{
    [SerializeField] public float TemperatureOnPoint = 0;
    [SerializeField] int TemperatureMax = 1;
    public Animator OpenGate;
    float randomNumber;
    float lastNumber;
    [SerializeField] GameObject barra;
    private void Update()
    {

        NewRandomNumber();
        if (TemperatureOnPoint >= 2.60 && TemperatureOnPoint <= 2.70)
        {
            OpenGate.SetBool("Nombre de la animacion ", true);
        }

        barra.transform.localScale = new Vector3(1,1,TemperatureOnPoint);
        

    }
    void NewRandomNumber()
    {
        randomNumber = Random.Range(0.1f, 0.2f);
        if (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(0.1f, 0.2f);
        }
        lastNumber = randomNumber;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Pressed");
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        if (tag == "MasTemperatura")
        {
            if (Input.GetKey(KeyCode.G) && TemperatureOnPoint <= 3)
            {
                Calculo();
            }
        }


    }
    void Calculo()
    {
        TemperatureOnPoint = TemperatureOnPoint + randomNumber;
    }


}
