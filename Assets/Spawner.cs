using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int NUM_COINS = 20;
    [SerializeField] GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        int xMin1 = -10;
        int yMin1 = -1;
        int xMax1 = 0;
        int yMax1 = 4;

        int xMin2 = 0;
        int xMax2 = 13;
        int yMin2 = 2;
        int yMax2 = 6;

        for (int i = 0; i < NUM_COINS/2; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin1, xMax1),Random.Range(yMin1,yMax1));
            Instantiate(coin, position, Quaternion.identity);
        }


        for (int i = NUM_COINS/2; i < NUM_COINS; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin2, xMax2),Random.Range(yMin2,yMax2));
            Instantiate(coin, position, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
