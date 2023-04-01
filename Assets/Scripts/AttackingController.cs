using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingController : MonoBehaviour
{
    [SerializeField] GameObject mainEnemy;
    [SerializeField] GameObject treasureBox;
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(mainEnemy.GetComponent<MainEnemyController>().health ==20)
        {
            treasureBox.SetActive(true);
        }

    }
    public static void IDamage(string character)
    {
        if(character=="Enemy")
        {
            RayCastHit.hit.collider.gameObject.GetComponent<EnemyController>().health -= 25;         
        }
        if(character=="Player")
        {
            EnemyController.hit.collider.gameObject.GetComponent<PlayerController>().health -= 2;
            
        }
        if (character == "MainEnemy")
        {
            RayCastHit.hit.collider.gameObject.GetComponent<MainEnemyController>().health -= 50;
            SoundsManager.PlaySound("shootHero");
        }
    }
}
