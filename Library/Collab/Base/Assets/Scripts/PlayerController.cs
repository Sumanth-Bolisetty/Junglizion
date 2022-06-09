using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playeranim;
    public static bool _isKneeling = false;
    public GameObject playerCharacter;
    public GameObject fps;
    public int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMovement();
        if (health <= 0)
        {
            playeranim.SetTrigger("Deathtrigger");
        }
    }

    //Movement of Player
    void PlayerMovement()
    {  
        if (fps.activeInHierarchy == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playeranim.SetTrigger("sprintingtrigger");
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                
                playeranim.SetTrigger("idletrigger");
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(0, 40, 0);
            }
            //Rotation of Player
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -5.0f, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 5.0f, 0);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if(_isKneeling == false)
                {
                    playeranim.SetTrigger("Kneelingtrigger");
                    _isKneeling = true;
                }
                else
                {
                    playeranim.SetTrigger("idletrigger");
                    _isKneeling = false;
                }
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                fps.transform.Rotate(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                fps.transform.Rotate(1, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -1.0f, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 1.0f, 0);
            }
        }
    }
    
}
