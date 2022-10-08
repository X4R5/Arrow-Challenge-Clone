using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] int _amountToAddOrRemove;
    private void OnTriggerEnter(Collider other) {
        AddArrows();
    }
    
    public void AddArrows(){
        if(_amountToAddOrRemove < 0){
            for (int i = 0; i < _amountToAddOrRemove * -1; i++)
            {
                var arrowToRemove = ArrowsController.Instance.arrows[0];
                ArrowsController.Instance.arrows.RemoveAt(0);
                ArrowsController.Instance.CreateCircle();
                Destroy(arrowToRemove);
                Destroy(this.gameObject);
            }
        }else{
            for(int i = 0; i < _amountToAddOrRemove; i++){
                ArrowsController.Instance.CreateArrow();
                ArrowsController.Instance.CreateCircle();
                Destroy(this.gameObject);
            }
        }
    }
}
