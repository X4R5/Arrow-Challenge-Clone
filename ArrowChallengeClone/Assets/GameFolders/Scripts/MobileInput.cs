using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MobileInput
{
    public static Vector3 GetInput(Camera camera){
        float x = 0;
        var ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            x = hit.point.x;
        }
        return new Vector3(x,0,0);
    }
}
