using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public Text moneyText;
    public Text lifesText;

    public static GameObject selectedTowerBase;

    public int lifes=100;
    public int money=100;


    public static GameManger gameMangerInstance;
    // Start is called before the first frame update
    void Start()
    {
        if (gameMangerInstance == null)
        {
            gameMangerInstance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + money;
        lifesText.text = "Lifes: " + lifes;
    }
    public static void checkLife()
    {
        //update later
    }
    public static void ChangeSelectedTower(GameObject tower)
    {
        
        //If I am clicking on the currently selected one: nothing to do
        if (selectedTowerBase == tower)
        {
            return;
        }
        //Deselect the current one, if there is one
        if (selectedTowerBase != null)
        {
            Debug.Log("null");
            selectedTowerBase.GetComponent<SpriteRenderer>().color = Color.white;
            selectedTowerBase = null;
        }

        //Select a new tower, if any
        if (tower != null)
        {
            selectedTowerBase = tower;
            selectedTowerBase.GetComponent<SpriteRenderer>().color = Color.green;

        }
    }
}
