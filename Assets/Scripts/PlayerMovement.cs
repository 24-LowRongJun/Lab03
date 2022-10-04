using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody PlayerRigidbody;
    public GameObject CoinCollected;
    private int cointCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
        if (other.gameObject.tag == "Coin")
        {
            cointCount++;
            CoinCollected.GetComponent<Text>().text = "Coins: " + cointCount;
            Destroy(other.gameObject);
        }
        if (cointCount == 4)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }
}
