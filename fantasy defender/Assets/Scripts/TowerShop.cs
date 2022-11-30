using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public List <GameObject> Towers = new List<GameObject>();
    public List <int> towerCost = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ArcherTower()
    {
        Debug.Log("Nothing selected.");
        if (GameManger.selectedTowerBase == null)
        {
            Debug.Log("Nothing selected.");
            return;
        }
        if (towerCost[0] > GameManger.gameMangerInstance.money)
        {
            return;
        }
        GameManger.gameMangerInstance.money -= towerCost[0];
        if (GameManger.selectedTowerBase.transform.childCount > 0)
        {
            Destroy(GameManger.selectedTowerBase.transform.GetChild(0).gameObject);
        }
        GameObject newTower = Instantiate(Towers[0], GameManger.selectedTowerBase.transform.position, Quaternion.identity);
        newTower.transform.parent = GameManger.selectedTowerBase.transform;

        GameManger.ChangeSelectedTower(null);
    }
    public void WizardTower()
    {
        Debug.Log("Nothing selected.");
        if (GameManger.selectedTowerBase == null)
        {
            Debug.Log("Nothing selected.");
            return;
        }
        if (towerCost[1] > GameManger.gameMangerInstance.money)
        {
            return;
        }
        GameManger.gameMangerInstance.money -= towerCost[1];
        if (GameManger.selectedTowerBase.transform.childCount > 0)
        {
            Destroy(GameManger.selectedTowerBase.transform.GetChild(0).gameObject);
        }
        GameObject newTower = Instantiate(Towers[1], GameManger.selectedTowerBase.transform.position, Quaternion.identity);
        newTower.transform.parent = GameManger.selectedTowerBase.transform;

        GameManger.ChangeSelectedTower(null);
    }
}
