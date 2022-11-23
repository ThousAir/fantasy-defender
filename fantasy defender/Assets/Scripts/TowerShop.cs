using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public GameObject archerTower;
    public int archerTowerCost = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ArcherTower()
    {
        if (GameManger.selectedTowerBase == null)
        {
            Debug.Log("Nothing selected.");
            return;
        }
        if (archerTowerCost > GameManger.gameMangerInstance.money)
        {
            return;
        }
        GameManger.gameMangerInstance.money -= archerTowerCost;
        if (GameManger.selectedTowerBase.transform.childCount > 0)
        {
            Destroy(GameManger.selectedTowerBase.transform.GetChild(0).gameObject);
        }
        GameObject newTower = Instantiate(archerTower, GameManger.selectedTowerBase.transform.position, Quaternion.identity);
        newTower.transform.parent = GameManger.selectedTowerBase.transform;

        GameManger.ChangeSelectedTower(null);
    }
}
