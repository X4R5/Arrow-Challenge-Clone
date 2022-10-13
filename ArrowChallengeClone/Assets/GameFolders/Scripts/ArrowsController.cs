using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowsController : MonoBehaviour
{
    public List<GameObject> _arrows = new List<GameObject>();
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] TMP_Text _arrowCountText;
    [SerializeField] int _startArrowCount;
    public int StartArrowCount => _startArrowCount;
    [SerializeField] float mesafe, _moveSpeed;
    public static ArrowsController Instance;
    // Start is called before the first frame update
    private void Awake() {
        _arrowCountText.text = "";
    }
    void Start()
    {
        CreateArrow(_startArrowCount);
        CreateCircle();
        Instance = this;
    }

    
    void Update()
    {
        if(Input.GetMouseButton(0)){
            transform.position = Vector3.Lerp(transform.position, new Vector3(MouseInput().x, transform.position.y, transform.position.z), _moveSpeed * Time.deltaTime);
        }
        if(_arrows.Count == 0){
            CreateArrow();
            CreateCircle();
        }
    }
    
    public void CreateCircle(){
        if(_arrows.Count != 0){
            var angle = 360 / _arrows.Count;
            for (int i = 0; i < _arrows.Count; i++)
            {
                MoveArrow(_arrows[i].transform, angle * i);
            }
        }
    }
    void MoveArrow(Transform arrow, float degree){
        var pos = Vector3.zero;
        pos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        pos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        arrow.transform.localPosition = pos * mesafe;
    }
    public void CreateArrow(){
        var newArrow = Instantiate(_arrowPrefab, this.transform);
        _arrows.Add(newArrow);
        if(_arrows.Count % 10 == 0) mesafe += 0.1f;
        SetArrowCountText();
    }
    public void CreateArrow(int amount){
        for (int i = 0; i < amount; i++)
        {
            var newArrow = Instantiate(_arrowPrefab, this.transform);
            _arrows.Add(newArrow);
            if(_arrows.Count % 10 == 0) mesafe += 0.1f;
        }
        SetArrowCountText();
    }
    public void RemoveArrow(){
        var arrowToRemove = _arrows[0];
        _arrows.RemoveAt(0);
        CreateCircle();
        Destroy(arrowToRemove);
        if(_arrows.Count % 10 == 0) mesafe -= 0.1f;
        SetArrowCountText();
    }
    public void RemoveArrow(int amount){
        if(amount >= _arrows.Count){
            amount = _arrows.Count - 1;
        }
        for (int i = 0; i < amount; i++)
        {
            var arrowToRemove = _arrows[0];
            _arrows.RemoveAt(0);
            CreateCircle();
            Destroy(arrowToRemove);
            if(_arrows.Count % 10 == 0) mesafe -= 0.1f;
        }
        SetArrowCountText();
    }
    public Vector3 MouseInput(){
        float x = 0;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            x = hit.point.x;
        }
        return new Vector3(x,0,0);
    }
    public void SetArrowCountText(){
        _arrowCountText.text = _arrows.Count.ToString();
    }
}
