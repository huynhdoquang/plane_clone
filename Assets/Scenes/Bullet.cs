using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            GameController.Instance.GameOver();
        }
    }
    public void Update()
    {
        if (!GameController.Instance.inGame)
        {
            Destroy(gameObject);
        }
    }
}
