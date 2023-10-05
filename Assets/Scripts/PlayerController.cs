using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private int totalCoinCount;

    public TMPro.TMP_Text coinCountTXT;

    private Vector3 finalPos;

    private int coinCount = 0;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        finalPos = transform.position;

        totalCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;

        coinCountTXT.text = string.Format("Coins: 0 / {0}", totalCoinCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * speed * Time.fixedDeltaTime;

        finalPos = transform.position + movement;

        if (finalPos.y <= -2f)
            finalPos.y += 10f;

        rb.MovePosition(finalPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coinCount++;
            coinCountTXT.text = string.Format("Coins: {0} / {1}", coinCount, totalCoinCount);

            if(coinCount == totalCoinCount)
            {
                coinCountTXT.text = "You Win!";
            }
        }
    }
}
