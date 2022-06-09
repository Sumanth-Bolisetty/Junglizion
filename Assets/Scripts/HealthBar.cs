using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Slider slider;
    public Image fillImage;
    private float currentHealth;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.GetComponent<PlayerController>().health;
        slider.value = currentHealth;
        if (slider.value <= 0)
            slider.enabled = false;
    }
}
