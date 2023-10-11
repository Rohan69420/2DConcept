using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimatorController : MonoBehaviour
{
    private Animator animator;
    public GameObject WinScreen;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
        animator.SetTrigger("ChestOpened");
    }
    }

     public void YouWin(){
        WinScreen.SetActive(true);
    }
}
