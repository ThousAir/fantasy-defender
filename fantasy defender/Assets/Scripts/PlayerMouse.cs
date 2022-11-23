using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    Vector3 mouseWorldPoint;

    private bool clickReleased = true;

    private bool mouseOverUI = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPoint.z = 0;
        transform.position = mouseWorldPoint;
        bool mouseClicked = Input.GetAxis("Fire1") == 1;
        if (!mouseClicked && !clickReleased)
        {
            clickReleased = true;
        }
        if (mouseClicked && clickReleased && !mouseOverUI)
        {
           GameManger.ChangeSelectedTower(null);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShopPanel")
        {
            mouseOverUI = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShopPanel")
        {
            mouseOverUI = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (!clickReleased || mouseOverUI)
        {
            return;
        }
        if (Input.GetAxis("Fire1") == 1)
        {
           
            switch (collision.gameObject.tag)
            {
                
                case "TowerBase":
                    
                    GameManger.ChangeSelectedTower(collision.gameObject);
                    break;
        
                default:
                 
                    break;
            }
            clickReleased = false;

        }
    }

}
