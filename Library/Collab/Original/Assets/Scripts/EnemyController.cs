using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public GameObject Hero;
    private Animator enemyanim;
    public static bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        enemyanim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if ((Hero.transform.position.x - transform.position.x < 10 && Hero.transform.position.z - transform.position.z < 10
            && Hero.transform.position.x - transform.position.x > -10 && Hero.transform.position.z - transform.position.z > -10 )|| isAttacking)
        {
            transform.LookAt(Hero.transform.position);
            enemyanim.SetTrigger("ShootingTrigger");
        }
        else
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        if(health <=0)
        {
            enemyanim.SetTrigger("DeathTrigger");
            Destroy(gameObject, 5f);
        }
    }

}
