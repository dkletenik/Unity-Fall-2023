using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    public const int DEFAULT_POINTS = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void AddPoints(int points)
    {
        score += points;
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }
}
