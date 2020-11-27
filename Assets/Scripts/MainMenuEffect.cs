using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEffect : MonoBehaviour
{
    public Transform[] Points;
    public GameObject[] Shapes;
    public float SpawnInterval;
    private float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnInterval)
        {
            for (int i = 0; Points.Length > i; i++)
            {
                int RandShape = Random.Range(0, Shapes.Length - 1);
                Instantiate(Shapes[RandShape], new Vector3(Points[i].position.x, Points[i].position.y), Quaternion.identity);
            }
            Timer = 0;
        }
    }
}
