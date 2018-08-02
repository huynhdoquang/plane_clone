using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pick coin");
            GameController.Instance.score += 1;
            Destroy(gameObject);
        }
    }
}
