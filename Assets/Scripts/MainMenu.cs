﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update    
    

    public void PlayGame() {
        SceneManager.LoadScene("GameScene");   
    
    }

}
