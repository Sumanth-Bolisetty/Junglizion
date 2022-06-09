using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public GameObject Hero;
    private Animator enemyanim;
    private bool isfiring = false;
    public int gunDamage = 1;
    public float fireRate = 2;
    public float weaponRange = 50f;
    public Transform gunEnd;
    public static bool isAlive = true;
   

    public static RaycastHit hit;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;
    private float nextFire;
    public GameObject gemPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyanim = GetComponent<Animator>();

        laserLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameOver == false && isAlive)
        {
            if (Time.time > nextFire)
            {
                if (Hero.transform.position.x - transform.position.x < 20 && Hero.transform.position.z - transform.position.z < 20 &&
                    Hero.transform.position.x - transform.position.x > -20 && Hero.transform.position.z - transform.position.z > -20)
                {
                    transform.LookAt(Hero.transform.position);
                    enemyanim.SetTrigger("ShootingTrigger");
                    nextFire = Time.time + fireRate;
                    StartCoroutine(ShotEffect());
                    Vector3 rayOrigin = gunEnd.transform.position;
                    laserLine.SetPosition(0, gunEnd.position);
                    if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit, weaponRange))
                    {
                        laserLine.SetPosition(1, hit.point);
                        AttackingController.IDamage("Player");
                    }
                    else
                    {
                        laserLine.SetPosition(1, rayOrigin + (gunEnd.transform.forward * weaponRange));
                    }
                    isfiring = true;
                }
                else
                    isfiring = false;
            }
            if (isAlive && isfiring==false)
            {
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                enemyanim.SetTrigger("Walking Trigger");
            }
        }
        if (health <=0)
        {
            SoundsManager.PlaySound("enemyDeath");
            isAlive = false;
            isfiring = false; 
            enemyanim.SetTrigger("DeathTrigger");
            StartCoroutine(DeathTime());
        }
    }
    private IEnumerator DeathTime()
    {
        
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
        isAlive = true;
        Instantiate(gemPrefab, new Vector3(transform.position.x, 3, transform.position.z), gemPrefab.transform.rotation);
        SoundsManager.PlaySound("appear");
    }
     private IEnumerator ShotEffect()
    {
        SoundsManager.PlaySound("shootEnemy");
        laserLine.enabled = true;
       yield return shotDuration;
       laserLine.enabled = false;
    }

}
