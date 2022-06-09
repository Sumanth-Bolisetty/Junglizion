using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _startPos;
    private float _xRandomLength;
    private float _zRandomLength;
    public int health = 100;
    public GameObject Hero;
    private Animator enemyanim;
    public static bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        enemyanim = GetComponent<Animator>();

        _startPos = transform.position;
        _xRandomLength = Random.Range(8, 10);
        _zRandomLength = Random.Range(10, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > _startPos.x + _xRandomLength || transform.position.x < _startPos.x - _xRandomLength 
                       || transform.position.z > _startPos.z + _zRandomLength || transform.position.z < _startPos.z - _zRandomLength)
        {
            transform.Rotate(0, Random.Range(30,80) , 0);
        }

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
