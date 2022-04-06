using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private Rigidbody2D myBody;
    private bool isDestroyed = false;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        AnimateItem();
    }
    private void AnimateItem()
    {
        if (isDestroyed)
        {
            anim.SetBool("Destroyed", true);
        }
        else
        {
            anim.SetBool("Destroyed",false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
