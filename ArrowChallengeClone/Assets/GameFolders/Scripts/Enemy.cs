using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int _enemyHealth;
    //a holding total of the big numbers in every wall block, and b is the opposite
    int a = 0, b = 0;
    [SerializeField] TMP_Text _enemyHealthText;
    WallsController _wallsController;
    EnemiesController _enemiesController;
    private void Awake() {
        _wallsController = GameObject.Find("Manager").GetComponent<WallsController>();
        _enemiesController = GameObject.Find("Manager").GetComponent<EnemiesController>();
    }
    private void Start() {
        SetMinMaxHealth();
        _enemyHealth = Random.Range(b,a+1);
        SetEnemyHealthText();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            _enemyHealth = Random.Range(b,a+1);
            SetEnemyHealthText();
        }
    }
    private void OnTriggerEnter(Collider other) {
        DamageEnemy();
    }
    public void DamageEnemy(){
        if(_enemyHealth <= ArrowsController.Instance._arrows.Count){
            for(int i = 0; i < _enemyHealth; i++){
                ArrowsController.Instance.RemoveArrow();
                Destroy(this.gameObject);
            }
        }else{
            var arrowAmount = ArrowsController.Instance._arrows.Count;
            ArrowsController.Instance.RemoveArrow(arrowAmount);
            _enemyHealth -= arrowAmount - 1;
            SetEnemyHealthText();
            Debug.Log("oyun kaybedildi");
            //kaybetme durumu yazılacak
        }
    }
    public void SetEnemyHealthText(){
        _enemyHealthText.text = _enemyHealth.ToString();
    }

    void SetMinMaxHealth(){
        foreach(var wall in _wallsController.Walls){
            //Debug.Log(gameObject.name + "'s enemy health is setting");
            if(wall.transform.position.z < this.transform.position.z){
                int value1 = wall.transform.GetChild(0).GetComponent<Wall>().WallWalue;
                int value2 = wall.transform.GetChild(1).GetComponent<Wall>().WallWalue;
                if(value1 > value2){
                    a += value1;
                    b += value2;
                }else{
                    a += value2;
                    b += value1;
                }
            }
        }
        foreach (var enemy in _enemiesController.Enemies)
        {
            var value = 0;
            if(enemy.transform.position.z < this.transform.position.z && enemy.GetComponent<Enemy>() != this) {
                value = enemy.GetComponent<Enemy>()._enemyHealth;
            }
            b -= value;
        }
        if(a < 0) a = 1;
        if(b < 0) b = 1;
    }
}
