using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int _enemyHealth;
    [SerializeField] TMP_Text _enemyHealthText;
    private void Start() {
        SetEnemyHealthText();
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
}
