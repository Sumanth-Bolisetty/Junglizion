using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHit : MonoBehaviour
{
    public float fireRate = 0.25f;
    public float weaponRange = 100f;
    public Transform gunEnd;
    public static RaycastHit hit;
    public Camera fps;
    public WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    public LineRenderer laserLine;
    private float nextFire;

    void Start()
    { 
        laserLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine("ShotEffect"); 

            Vector3 rayOrigin = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fps.transform.forward, out hit, weaponRange))

            {
                laserLine.SetPosition(1, hit.point);
                if (hit.collider.CompareTag("Enemy"))
                {

                    AttackingController.IDamage("Enemy");
                }
                if (hit.collider.CompareTag("MainEnemy"))
                {
                    AttackingController.IDamage("MainEnemy");
                }

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fps.transform.forward * weaponRange));
            }
        }
    }


    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}

