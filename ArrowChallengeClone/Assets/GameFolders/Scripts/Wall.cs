using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wall : MonoBehaviour
{
    int _amountToAddOrRemove = 0;
    public int WallWalue { get{return _amountToAddOrRemove;} private set{_amountToAddOrRemove = value;} }
    [SerializeField] TMP_Text _valueText;
    [SerializeField] Image _image;
    private void Awake() {
        _amountToAddOrRemove = Random.Range(-10, 11);
        while(_amountToAddOrRemove == 0){
            _amountToAddOrRemove = Random.Range(-10, 11);
        }
    }
    private void Start() {
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
            var img = _image.GetComponent<Image>();
            var tempColor = Color.green;
            tempColor.a = 0.275f;
            img.color = tempColor;
        }else{
            var img = _image.GetComponent<Image>();
            var tempColor = Color.red;
            tempColor.a = 0.275f;
            img.color = tempColor;
        }
    }
}
