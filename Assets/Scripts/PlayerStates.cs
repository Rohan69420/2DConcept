using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public int Health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    Vector3 checkPoint;
    public GameObject GameControllerObject;

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        foreach( Image img in hearts){
            img.sprite =emptyHeart;
        }
        for (int i = 0 ; i < Health; i++){
            hearts[i].sprite = fullHeart; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Enemy"){
        //death logic
            animator.SetTrigger("Death");
            Health -=1;
            rb.bodyType=RigidbodyType2D.Static;
        }
    }
    public void RestartLevel(){
         SceneManager.LoadScene("SampleScene");
    }
    void Respawn(){
    if(Health>0){
        transform.position = checkPoint;
        rb.bodyType=RigidbodyType2D.Dynamic;
        animator.SetTrigger("Respawn");
        }
        else{

        Die();
        }
    }
    void Die(){
        GameControllerObject.GetComponent<UIActions>().GameOver();
    }
}
