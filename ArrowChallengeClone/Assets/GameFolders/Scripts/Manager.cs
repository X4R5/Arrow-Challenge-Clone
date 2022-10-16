using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    UIManager _uiManager;
    private void Start() {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public void ReturnMainMenu(){
        _uiManager.LoadMainMenu();
    }
}
