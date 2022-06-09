using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator playeranim;
    public static bool _isKneeling = false;
    public GameObject fps;
    public int health = 100;
    public static bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public GameObject cam;
    public GameObject Hero;
    [SerializeField] GameObject mainEnemy;
    [SerializeField] GameObject treasureBox;
    private Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = cam.transform;
        playeranim = GetComponent<Animator>();
        mainEnemy.SetActive(false);
        treasureBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AdjustCam());
        scoreText.text = "Score: " + score;
        PlayerMovement();
        if (health <= 0)
        {
            playeranim.SetTrigger("Deathtrigger");
            Destroy(gameObject, 4f);
            SceneManager.LoadScene(2);
            gameOver = true;
            SoundsManager.PlaySound("gameOver");
        }
        if(score ==7)
        {
            mainEnemy.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            SoundsManager.PlaySound("shootHero");
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
                SoundsManager.PlaySound("stepsHero");
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playeranim.SetTrigger("BacksprintTrigger");
                SoundsManager.PlaySound("stepsHero");

            }
            else if(Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.DownArrow))
            {
                playeranim.SetTrigger("idletrigger");
                cam.transform.localPosition = new Vector3(1.32f, 2.14f, -1.45f);
            }

            //Rotation of Player
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -1f, 0);
               
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 1f, 0);
         
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
                fps.transform.Rotate(-0.3f, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                fps.transform.Rotate(0.3f, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -0.3f, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0.3f, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {
            Destroy(other.gameObject);
            SoundsManager.PlaySound("collect");
            score += 1;
        }

    }
    private IEnumerator AdjustCam()
    {
        yield return 1.0f;
        cam.transform.position = camera.position;
        cam.transform.rotation = camera.rotation;
    }

   
   

}
