using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float targetingRate = 0.2f;
    public float projectilesPerSecond = 2;
    public GameObject projectPrefab;
    public GameObject bow;

    private Transform target;
    private CircleCollider2D detectionArea;

    private static List<Collider2D> colliders = new List<Collider2D>();
    private static ContactFilter2D contactFilter = new ContactFilter2D();

    // Start is called before the first frame update
    void Start()
    {
        detectionArea = GetComponent<CircleCollider2D>();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(LayerMask.GetMask("enemy"));
        StartCoroutine(TargetAndShoot());
    }
    IEnumerator TargetAndShoot()
    {

        while (true)
        {
            target = null;
            int numCollisions = detectionArea.OverlapCollider(contactFilter, colliders);
            if (numCollisions == 0)
            {
                yield return new WaitForSeconds(targetingRate);
            }
            else
            {
                target = colliders[0].gameObject.transform;
               
                Vector3 direction = target.position - transform.position;
                direction.z = 0;
                bow.transform.up = direction;
                GameObject j=Instantiate(projectPrefab, transform.position, bow.transform.rotation);
                if (gameObject.tag == "Wizard")
                {
                    j.GetComponent<WizardBullet>().enemy = colliders[0].gameObject;
                }
                yield return new WaitForSeconds(1 / projectilesPerSecond);
            }
        }

    }


}
