using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Debug.Log($"MouseButton 0 down at {Input.mousePosition}");
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetHitObject(Input.mousePosition);
            //Debug.Log($"MouseButton 0 up at {Input.mousePosition}");
        }

        if (Input.GetMouseButton(0))
        {

            //Debug.Log($"MouseButton 0 at {Input.mousePosition}");
        }
    }

    private void GetHitObject(Vector3 mousepos)
    {
        Ray r = Camera.main.ScreenPointToRay(mousepos, Camera.MonoOrStereoscopicEye.Mono);
        Physics.Raycast(r,  out RaycastHit hit, 100);
    }
}
