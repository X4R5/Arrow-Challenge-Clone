using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow;
    [SerializeField] float _followSpeed;
    public static CameraFollow Instance;
    private void Start() {
        Instance = this;
    }
    public void MoveCamera(){
        transform.position = Vector3.Lerp(transform.position, _objectToFollow.position, _followSpeed);
    }
}
