using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour {

    public float FireTime = 0f;
    public float BulletTime = 1f;
    public float thrust;
    public GameObject bulletPrefab;
    public Transform spaceShip;
    public Transform spaceShipTemp;
    public Transform spaceShipTemp2;

    public int i = 0;


    // Use this for initialization
    void Start () {
		
	}

    Vector3 relativePos;

    // Update is called once per frame
    void Update () {
        if (GameController.Instance.inGame)
        {
            
            FireTime += Time.deltaTime;
            //Sometime we shoot two bullet
       
            if ((FireTime > BulletTime))
            {
                FireTime = 0;
                Fire();
                i++;
                if( i >= Random.RandomRange(2, 4))
                {
                    StartCoroutine(Example());
                    i = 0;
                }
            }
        }
        
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.15f);
         transform.LookAt(spaceShip);
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,

            transform);

        bullet.transform.parent = null;
        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = (spaceShip.transform.position - transform.position).normalized * thrust;
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    Vector3 temp;

    void Fire()
    {

        if (RotateAround.Instance.i == 1) relativePos = spaceShipTemp.position - transform.position;
        if (RotateAround.Instance.i == -1) relativePos = spaceShipTemp2.position - transform.position;


        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;

        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,

            transform);

        bullet.transform.parent = null;

        //TODO: Adding AI
        if (RotateAround.Instance.i == 1)  temp = spaceShipTemp.position;
        if (RotateAround.Instance.i == -1) temp = spaceShipTemp2.position;





        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = (temp - transform.position).normalized * thrust;
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
