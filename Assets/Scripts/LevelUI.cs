using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{

    //Level attributes
    public GameObject Level;

    //Rotation
    private Quaternion CurrentRotation = new Quaternion(0f, 0f, 0f, 1f);
    public float speedRotate;
    private Quaternion target = new Quaternion(0f, 0f, 0f, 1f);

    private Quaternion left = new Quaternion(0f, 0f, -0.7071068f, 0.7071068f);
    private Quaternion right = new Quaternion(0f, 0f, 0.7071068f, 0.7071068f);
    public Button LeftButton;
    public Button RightButton;

    //Player attributes
    public GameObject Player;
    private Rigidbody2D rb;

    //Counters
    public Text MovesText;
    public float Moves;
    public Text ItemsText;
    public static float Items;
    public float TotalItems;

    //End level
    public GameObject EndLevelMenu;
    public Text TotalMovesText;

    private void Start()
    {
        Items = 0;
        Moves = 0;
        rb = Player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        MovesText.text = "Moves: 0";
        ItemsText.text = "0 / " + TotalItems;
        EndLevelMenu.SetActive(false);
    }

    IEnumerator RotateObjectLeft()
    {
        bool ltarget = false;
        target = CurrentRotation * left;
        Moves += 1;
        //Start rotating
        while (ltarget == false)
        {
            RightButton.interactable = false;
            LeftButton.interactable = false;
            rb.gravityScale = 0;
            Level.transform.rotation = Quaternion.RotateTowards(CurrentRotation, target, speedRotate * Time.deltaTime);
            if (CurrentRotation == target)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                ltarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            yield return null;
        }
    }

    IEnumerator RotateObjectRight()
    {
        bool rtarget = false;
        target = CurrentRotation * right;
        Moves += 1;
        //Start rotating
        while (rtarget == false)
        {
            RightButton.interactable = false;
            LeftButton.interactable = false;
            rb.gravityScale = 0;
            Level.transform.rotation = Quaternion.RotateTowards(CurrentRotation, target, speedRotate * Time.deltaTime);
            if (CurrentRotation == target)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                rtarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            yield return null;
        }

    }

    void Update()
    {
        CurrentRotation = Level.transform.rotation;
        MovesText.text = "Moves: " + Moves;
        ItemsText.text = Items + " / " + TotalItems;

        if (Items == TotalItems)
        {
            EndLevelMenu.SetActive(true);
            TotalMovesText.text = "Total Moves: " + Moves;
        }
    }

    //Functions called onClick()
    public void RotateLeft()
    {
        StartCoroutine(RotateObjectLeft());
    }

    public void RotateRight()
    {
        StartCoroutine(RotateObjectRight());
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
