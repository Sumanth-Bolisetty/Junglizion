using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> bulletPool;
    [SerializeField] private GameObject bulletContainer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject poolManager;
    private GameObject bullet;
    private static PoolManager _instance;
    public static PoolManager Instance
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
        bulletPool = GenerateBullets(10);
    }

    // Update is called once per frame
    void Update()
    {


    }
    private List<GameObject> GenerateBullets(int amountOfBullets)
    {
        int i;
        GameObject bullet;
        for (i = 0; i < amountOfBullets; i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullet.transform.parent = bulletContainer.transform;
            bulletPool.Add(bullet);
        }
        return bulletPool;
    }
    public GameObject RequestBullet()
    {
        foreach(var bullet in bulletPool)
        {
            if(bullet.activeInHierarchy==false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.parent = bulletContainer.transform;
        newBullet.SetActive(true);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
