using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PcInput
{
    public static Vector3 GetInput(Camera camera){
        float x = 0;
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            x = hit.point.x;
        }
        return new Vector3(x,0,0);
    }
}
