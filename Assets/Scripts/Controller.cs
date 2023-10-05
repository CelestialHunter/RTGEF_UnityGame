using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField]
    private float speed = 15f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 10 || transform.position.y <= -10)
        {
            speed *= -1;
        }
    }
}
