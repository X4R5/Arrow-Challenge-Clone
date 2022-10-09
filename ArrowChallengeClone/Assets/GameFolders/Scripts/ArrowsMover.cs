using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsMover : MonoBehaviour
{
    [SerializeField] float _speed;
    
    void Update()
    {
        transform.position += new Vector3(0,0, _speed * Time.deltaTime);
        CameraFollow.Instance.MoveCamera();
    }

}
