using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour
{
    public GameObject GAMEOVER;
    public GameObject YOUWIN;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(){
      GAMEOVER.SetActive(true);
    }
    
    public void YouWin(){
        YOUWIN.SetActive(true);
    }
}

