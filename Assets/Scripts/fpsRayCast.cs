using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsRayCast : MonoBehaviour
{
    public GameObject cam;
    public GameObject fpscam;
    public Camera fps;
    private float weaponRange = 100.0f;
    private bool isfpsActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isfpsActive == false)
        {
            SoundsManager.PlaySound("zoom");
            cam.SetActive(false);
            fpscam.SetActive(true);
            isfpsActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isfpsActive == true)
        {
            SoundsManager.PlaySound("zoom");
            cam.SetActive(true);
            fpscam.SetActive(false);
            isfpsActive = false;
        }
        if (isfpsActive)
        {
            Vector3 lineOrigin = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            Debug.DrawRay(lineOrigin, fps.transform.forward * weaponRange, Color.green);
        }
    }
}
