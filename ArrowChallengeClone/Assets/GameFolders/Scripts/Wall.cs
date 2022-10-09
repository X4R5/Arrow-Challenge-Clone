using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField] int _amountToAddOrRemove;
    [SerializeField] TMP_Text _valueText;
    [SerializeField] Material _green, _red;
    private void Start() {
        _amountToAddOrRemove = Random.Range(-10, 11);
        SetValueText();
        SetWallColor();
    }
    private void OnTriggerEnter(Collider other) {
        AddArrows();
        Destroy(transform.parent.gameObject);
    }
    
    public void AddArrows(){
        if(_amountToAddOrRemove < 0){
            for (int i = 0; i < _amountToAddOrRemove * -1; i++)
            {
                ArrowsController.Instance.RemoveArrow();
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
    void SetValueText(){
        if(_amountToAddOrRemove < 0){
            _valueText.text = _amountToAddOrRemove.ToString();
        }else{
            _valueText.text = "+" + _amountToAddOrRemove.ToString();
        }
    }
    void SetWallColor(){
        if(_amountToAddOrRemove > 0){
            GetComponent<Renderer>().material = _green;
        }else{
            GetComponent<Renderer>().material = _red;
        }
    }
}
