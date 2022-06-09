using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject shooterCamera;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject bulletContainer;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            camera.SetActive(false);
            shooterCamera.SetActive(true);
            shooterCamera.transform.position = bulletContainer.transform.position + offset;
         }
    }
}
