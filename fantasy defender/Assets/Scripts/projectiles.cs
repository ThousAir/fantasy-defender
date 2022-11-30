using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class projectiles : MonoBehaviour
{
    public int damage = 5;
    public float speed = 5;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DoDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss1")
        {
            collision.gameObject.GetComponent<Boss1>().DoDamage(damage);
            if (collision.gameObject.GetComponent<Boss1>().currentHealth <= 0)
            {
                Destroy(collision.gameObject);
                Debug.Log("boss is " );

                DataCarrier.Data.life = GameManger.gameMangerInstance.lifes;
                DataCarrier.Data.money = GameManger.gameMangerInstance.money;

                SceneManager.LoadScene("level2");
            }
            Destroy(gameObject);

        }
    }
}
