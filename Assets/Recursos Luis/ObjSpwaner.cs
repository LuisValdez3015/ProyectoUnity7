using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpwaner : MonoBehaviour
{
   
    [SerializeField] List<GameObject> prefabsToSpawn;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject pressG;
    [SerializeField] public int id;
    
    int obj;

    private void OnTriggerStay(Collider other)
    {
                if (Input.GetKey(KeyCode.G))
                {
                        if (GameObject.FindGameObjectsWithTag("Pullable").Length < 5)
                        {
                             Spawn();
                        }
                }        
    }

    public void Spawn()
    {
        obj = prefabsToSpawn.Count;
        foreach (GameObject Obj in prefabsToSpawn)
        {
            int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
            GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
            pts.transform.position = spawnPoint.transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        pressG.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pressG.gameObject.SetActive(false);
    }
}