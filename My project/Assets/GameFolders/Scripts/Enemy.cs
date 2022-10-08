using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _enemyHealth;
    private void OnTriggerEnter(Collider other) {
        
    }
    public void DamageEnemy(){
        if(_enemyHealth <= ArrowsController.Instance.arrows.Count){
            for(int i = 0; i < _enemyHealth; i++){
                ArrowsController.Instance.RemoveArrow();
            }
        }else{
            Debug.Log("oyun kaybedildi");
            //kaybetme durumu yazılacak
        }
    }
}
