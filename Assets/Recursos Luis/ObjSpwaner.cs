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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerStay(Collider other)
    {
        

        
            
            
                pressG.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.G))
                {
                        if (GameObject.FindGameObjectsWithTag("Pullable").Length < 5)
                        {
                             Spawn();
                        }
                }
            
            
        
        
        //if (GameObject.FindGameObjectsWithTag("Spawneable").Length < 10) 
        //{
        //    Spawn();
        //}
        
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
}