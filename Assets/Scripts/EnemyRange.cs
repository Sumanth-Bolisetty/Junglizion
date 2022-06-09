using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    private Vector3 _startPos;
    private float radOfCircle = 10;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float X = transform.position.x - _startPos.x;
        float Z = transform.position.z - _startPos.z;
        if (X*X+Z*Z>radOfCircle*radOfCircle)
        {
            transform.Translate(Vector3.back);
            transform.Rotate(0, Random.Range(160,200), 0);
        }
    }
}
