using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float rotationSpeed = 100f;

    private Vector3 startingPos;
    
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // rotation
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);

        // movement
        transform.position = startingPos + new Vector3(0, Mathf.Sin(Time.time), 0) * 0.2f;
    }
}
