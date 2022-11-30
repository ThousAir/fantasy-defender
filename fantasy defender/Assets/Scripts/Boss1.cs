using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss1 : MonoBehaviour
{
    public GameObject child;
    public float speedPerSecond = 0.25f;
    public float distanceThreshold = 0.1f;

    private WayPoints waypointReference;
    private Vector2 targetWaypoint;
    public int wayPointIndex;

    private SpriteRenderer sr;

    //Health related stuff
    public int maxHealth = 500;
    public int currentHealth = 500;

    public Slider healthBar;

    public int damage = 100;

    public int enemyValue = 200;
    public int stage = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        wayPointIndex = 0;
        targetWaypoint = WayPoints.staticWaypoint[wayPointIndex];

        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Slider>();

    }
    public void DoDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / (float)maxHealth;
        if (currentHealth <= 0)
        {
            GameManger.gameMangerInstance.money += enemyValue;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector2 directionToMove = targetWaypoint - (Vector2)transform.position;
        float distance = directionToMove.magnitude;
        if (distance < distanceThreshold)
        {
            if (wayPointIndex == WayPoints.staticWaypoint.Count - 1)
            {
                return;
            }
            targetWaypoint = WayPoints.staticWaypoint[++wayPointIndex];
            directionToMove = targetWaypoint - (Vector2)transform.position;
        }
        directionToMove.Normalize();
        transform.Translate(directionToMove * speedPerSecond * Time.deltaTime);


        if (directionToMove.x > 0.01)
        {
            sr.flipX = true;
        }
        else
            sr.flipX = false;


        if(currentHealth <= 400)
        {
            Stages(1);
        }
        if (currentHealth <= 300)
        {
            Stages(2);
        }
        if (currentHealth <= 200)
        {

            Stages(3);
        }
        if (currentHealth <= 100)
        {
            Stages(4);
        }
          
    }
    public void Stages(int i)
    {
        if (stage < 1)
        {
            if (i == 1)
            {
                GameObject j;
                j=Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                stage = 1;
            }
        }
        else if (stage < 2)
        {
            if (i == 2)
            {
                GameObject j;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                stage = 2;
            }
        }
        else if (stage < 3)
        {
            if (i == 3)
            {
                GameObject j;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex; 
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                stage = 3;
            }
        }
        else if(stage < 4)
        {
            if (i == 4)
            {
                GameObject j;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex; 
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex; 
                j = Instantiate(child, gameObject.transform.position, Quaternion.identity);
                j.GetComponent<Enemy>().wayPointIndex = wayPointIndex;
                stage = 4;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Home")
        {
            GameManger.gameMangerInstance.lifes -= enemyValue;
            GameManger.checkLife();
            Destroy(gameObject);
        }

    }
    
}
