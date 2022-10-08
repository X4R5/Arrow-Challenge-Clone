using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _arrowPrefab;
    public float mesafe, _moveSpeed;
    public static ArrowsController Instance;
    // Start is called before the first frame update
    void Start()
    {
        CreateCircle();
        Instance = this;
    }

    
    void Update()
    {
        CameraFollow.Instance.MoveCamera();
        if(Input.GetMouseButton(0)){
            transform.position = Vector3.Lerp(transform.position, new Vector3(MouseInput().x, transform.position.y, transform.position.z), _moveSpeed * Time.deltaTime);
        }
    }
    
    public void CreateCircle(){
        var angle = 360 / arrows.Count;
        for (int i = 0; i < arrows.Count; i++)
        {
            MoveArrow(arrows[i].transform, angle * i);
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
        arrows.Add(newArrow);
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
}
