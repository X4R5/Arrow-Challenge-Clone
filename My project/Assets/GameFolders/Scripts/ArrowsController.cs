using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    [SerializeField] GameObject _arrowPrefab;
    public float mesafe;
    public static ArrowsController Instance;
    // Start is called before the first frame update
    void Start()
    {
        CreateCircle();
        Instance = this;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            CreateCircle();
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
}
