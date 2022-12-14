using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "level2")
        {
            lifes = DataCarrier.Data.life;
            money = DataCarrier.Data.money;
            if(money <= 200)
            {
                money = 200;
            }
        }
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
        if (Input.GetAxis("Cancel") > 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); //does not work in the editor, it works when you compile
#endif
        }
    /*    if (lifes <= 0)
        {
            SceneManager.LoadScene("Lose");      currently commented out do to the game state of unwinableness untill upgrade are added to the game
        }
    */
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
