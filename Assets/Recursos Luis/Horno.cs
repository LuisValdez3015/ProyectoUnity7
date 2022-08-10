using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horno : MonoBehaviour
{
    [SerializeField] public int TemperatureOnPoint = 0;
    [SerializeField] GameObject barra;
    public bool Completado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barra.transform.localScale = new Vector3(1, 1, TemperatureOnPoint);

        //if (TemperatureOnPoint == 3)
        //{
        //    Debug.Log("Humo");
        //}
    }

    

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Pullable"))
        {
            Destroy(other.gameObject);
            Calculo();
        }
    }

    void Calculo()
    {
        TemperatureOnPoint = TemperatureOnPoint + 1;
    }
}
