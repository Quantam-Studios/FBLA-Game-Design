using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    // Level components
    public GameObject Level;
    public float CurrentRotation;
    public float speedRotate;
    public bool RotateLeft;
    public bool RotateRight;

    private void Start()
    {
        RotateLeft = false;
        RotateRight = false;
    }

    private void Update()
    {
        if (RotateLeft == true)
        {
            Level.transform.Rotate(Vector3.forward * speedRotate * -1 * Time.deltaTime);
        }

        if (RotateRight == true)
        {
            Level.transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        }
    }

    public void RotateObjectLeft()
    {
        RotateLeft = true;
    }

    public void RotateObjectRight()
    {
        RotateRight = true;
    }

}
