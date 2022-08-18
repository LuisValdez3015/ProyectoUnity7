using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpwaner : MonoBehaviour
{
   
    [SerializeField] List<GameObject> prefabsToSpawn;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject pressG;
    [SerializeField] GameObject needToolbag;
    [SerializeField] public int id;
    
    int obj;

    private void OnTriggerStay(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        if (playercontroller.playerId == 1)
        {
            if (Input.GetKey(KeyCode.G))
            {
                if (GameObject.FindGameObjectsWithTag("Pullable").Length < 5)
                {
                    Spawn();
                }
            }
        }
        else if(playercontroller.playerId == 2)
        {
            needToolbag.SetActive(true);
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    var playercontroller = other.gameObject.GetComponent<PlayerController>();
    //    if (playercontroller == null)
    //        return;
    //    if (playercontroller.playerId == 1)
    //    {
    //        pressG.gameObject.SetActive(true);
    //    }
    //    else if (playercontroller.playerId == 2)
    //    {
    //        needToolbag.SetActive(true);
    //    }

    //}

    private void OnTriggerExit(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        if (playercontroller.playerId == 1)
        {
            pressG.gameObject.SetActive(false);
        }
        else if (playercontroller.playerId == 2)
        {
            needToolbag.SetActive(false);
        }
    }
}