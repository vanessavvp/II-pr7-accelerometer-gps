using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : MonoBehaviour
{
    Text Instructions;

    void Start()
    {
        Instructions = GameObject.Find("Instructions").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instructions.text = "Mission completed! You have won the game";
        }
    }
}
