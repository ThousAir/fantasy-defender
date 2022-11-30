using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WizardBullet : MonoBehaviour
{
    public int damage = 5;
    public int hp = 5;
    public float speed = 5;
    private List <GameObject> hitEnemy = new List<GameObject>();
    private List<GameObject> emptyList = new List<GameObject>();
    private bool enemyHit;
    public GameObject enemy;
    public float trackTime = 1.0f;
    private float lastTracked = 0.0f;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.velocity = transform.up * speed;
        lastTracked = Time.time;
    }
    private void Update()
    {
        if(lastTracked + trackTime > Time.time)
        {
            Vector3 direction = enemy.transform.position - transform.position;
            direction.z = 0;
            gameObject.transform.up = direction;
            rb.velocity = transform.up * speed/2;
            hitEnemy = emptyList;
        }
     
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
            foreach(GameObject obj in hitEnemy)
            {
                if(collision.gameObject.tag == obj.tag)
                {
                    enemyHit = true;
                    break;
                }
            }
            if (!enemyHit)
            {
                collision.gameObject.GetComponent<Enemy>().DoDamage(damage);
                hitEnemy.Add(collision.gameObject);
            }

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Boss1")
        {
            collision.gameObject.GetComponent<Boss1>().DoDamage(damage);
            if (collision.gameObject.GetComponent<Boss1>().currentHealth <= 0)
            {
                Destroy(collision.gameObject);
                Debug.Log("boss is ");

                DataCarrier.Data.life = GameManger.gameMangerInstance.lifes;
                DataCarrier.Data.money = GameManger.gameMangerInstance.money;

                SceneManager.LoadScene("level2");
            }
            Destroy(gameObject);

        }
    }
}
