using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControll : MonoBehaviour
{
    private bool isOpened = false;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isOpened", true);
        }
    }
}
