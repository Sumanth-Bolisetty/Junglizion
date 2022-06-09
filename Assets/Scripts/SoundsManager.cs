using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    static AudioSource auds;
    public static AudioClip Click,StepsHero,Zoom,ShootHero,ShootEnemy, environmentBG, treasureDisplay, GameOver,Appear,Collect,EnemyDeath, treasureOpen,stepsmainEnemy;
    // Start is called before the first frame update
    void Start()
    {
        auds = GetComponent<AudioSource>();

        Click = Resources.Load<AudioClip>("buttonClick");
        StepsHero = Resources.Load<AudioClip>("stepsHero");
        Zoom = Resources.Load<AudioClip>("zoom");
        ShootHero = Resources.Load<AudioClip>("shootHero");
        ShootEnemy = Resources.Load<AudioClip>("shootEnemy");
        environmentBG = Resources.Load<AudioClip>("environmentBg");
        treasureDisplay = Resources.Load<AudioClip>("treasuredisplay");
        GameOver = Resources.Load<AudioClip>("gameOver");
        treasureOpen = Resources.Load<AudioClip>("treasureopen");
        stepsmainEnemy = Resources.Load<AudioClip>("stepsMEnemy");
        EnemyDeath = Resources.Load<AudioClip>("enemyDeath");
        Appear = Resources.Load<AudioClip>("appear");
        Collect = Resources.Load<AudioClip>("collect");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "buttonClick":
                auds.PlayOneShot(Click);
                break;

            case "stepsHero":
                auds.PlayOneShot(StepsHero);
                break;
            case "zoom":
                auds.PlayOneShot(Zoom);
                break;
            case "shootHero":
                auds.PlayOneShot(ShootHero);
                break;
            case "shootEnemy":
                auds.PlayOneShot(ShootEnemy);
                break;
            case "treasuredisplay":
                auds.PlayOneShot(treasureDisplay);
                break;
            case "gameOver":
                auds.PlayOneShot(GameOver);
                break;
            case "treasureopen":
                auds.PlayOneShot(treasureOpen);
                break;
            case "stepsMEnemy":
                auds.PlayOneShot(stepsmainEnemy);
                break;
            case "enemyDeath":
                auds.PlayOneShot(EnemyDeath);
                break;
            case "appear":
                auds.PlayOneShot(Appear);
                break;
            case "collect":
                auds.PlayOneShot(Collect);
                break;

        }
    }
}
