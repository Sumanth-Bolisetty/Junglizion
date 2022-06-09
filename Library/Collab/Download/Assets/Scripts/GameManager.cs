using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> bullets;
    public GameObject bulletContainer;
    public GameObject bulletPrefab;
    public GameObject gameManager;
    private static GameManager _instance;
    private GameObject bullet;
    public GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The gameManger is null");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        bullets = GenerateBullets(10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            {
            bullet=RequestBullet();
            bullet.SetActive(true);
        }
        
    }
    private  List<GameObject> GenerateBullets(int amountOfBullets)
    {
        int i;
        GameObject bullet; 
        for(i=0;i<amountOfBullets;i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.parent = bulletContainer.transform;
            bullets.Add(bullet);
        }
        return bullets;
    }
    private GameObject RequestBullet()
    { int i;
        GameObject bullet = null;
        for (i=0;i<bullets.Capacity;i++)
        {
            Debug.Log(bullets.Capacity);
            bullet = bullets[0];
        }
       
        return bullet;

    }
}
