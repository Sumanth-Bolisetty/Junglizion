using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treaureBox : MonoBehaviour
{
    private Animator boxAnim;
    [SerializeField] private GameObject gem;
    private Vector3 gemPos;
    // Start is called before the first frame update
    void Start()
    {
        boxAnim = GetComponent<Animator>();
        //GemAnim = GetComponent<Animator>();
        gemPos = gem.transform.position;
        SoundsManager.PlaySound("treasuredisplay");
        
    }

    // Update is called once per frame
    void Update()
    {
        gem.transform.position = new Vector3(gemPos.x, gem.transform.position.y, gemPos.z);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpeningTime());
        }
    }
    IEnumerator OpeningTime()
    {
        SoundsManager.PlaySound("treasureopen");
        boxAnim.SetTrigger("open");
        yield return new WaitForSeconds(3);
        gem.transform.position = new Vector3(gem.transform.position.x, 4, gem.transform.position.z);
        SoundsManager.PlaySound("treasureopen"); //Sound for closing treasure box
    }
}
