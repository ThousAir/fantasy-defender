using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpotManger : MonoBehaviour
{
    public GameObject towerSelector;
    public GameObject archerTower;
    public Vector3 towerSpawnPostition;
    public Quaternion towerSpawnRotation;
    public void spawnSelector()
    {
        Debug.Log("clicked selector");
        towerSpawnPostition= gameObject.transform.position;
        GameObject sel = Instantiate(towerSelector);
        sel.GetComponent<BuildSpotManger>().towerSpawnPostition = towerSpawnPostition;
       
    }
    public void spawnArrowTower()
    {
        towerSpawnRotation = gameObject.transform.localRotation;
        Debug.Log("clicked Tower");
        
        GameObject.Instantiate(archerTower, towerSpawnPostition,towerSpawnRotation);
    }


}
