using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speedPerSecond = 2.0f;
    public float distanceThreshold = 0.1f;

    private WayPoints waypointReference;
    private Vector2 targetWaypoint;
    public int wayPointIndex=0;

    private SpriteRenderer sr;

    //Health related stuff
    public int maxHealth = 10;
    private int currentHealth;

    public Slider healthBar;

    public int damage = 1;

    public int enemyValue = 10;

    // Start is called before the first frame update
    void Start()
    {
      
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
