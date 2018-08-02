using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour
{
    public static RotateAround Instance;
    public int i = 1;
    public int speed = 20;
    public GameObject coinPrefab;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        //
        if (GameController.Instance.inGame)
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.anyKeyDown )
            {
                i *= -1;
            }
            transform.RotateAround(Vector3.zero, Vector3.up * i, speed * Time.deltaTime);


            //Check coin in field
            if (GameObject.FindGameObjectsWithTag("Apple").Length == 0)
            {
                Coin();
            }
        }
        else
        {
            i = 1;
        }
    }
    
    public int numObjects = 12;

    void Coin()
    {
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 36;
            Vector3 pos = RandomCircle(Vector3.zero, 7f, a);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, Vector3.zero - pos);
            Instantiate(coinPrefab, pos, rot);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        Debug.Log(a);
        float ang = a;
        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}