using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayShaderScript : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Player_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    [SerializeField] private Material _WallMaterial;
    [SerializeField] private Camera _Camera;
    [SerializeField] private LayerMask _Mask;
    void Update()
    {
        var dir = _Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, _Mask))
            _WallMaterial.SetFloat(SizeID, 1);
        else
            _WallMaterial.SetFloat(SizeID, 0);

        var view = _Camera.WorldToViewportPoint(transform.position);
        _WallMaterial.SetVector(PosID, view);
    }
}
