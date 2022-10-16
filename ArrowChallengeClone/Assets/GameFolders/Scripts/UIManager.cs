using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake() {
        SingletonThisGameObject();
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu(){
        Debug.Log("ddd");
        SceneManager.LoadScene(0);
    }
    public void QuitGame(){
        Application.Quit();
    }


    void SingletonThisGameObject(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this);
        }else{
            Destroy(this.gameObject);
        }
    }
}
