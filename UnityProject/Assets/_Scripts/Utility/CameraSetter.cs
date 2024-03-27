using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main != null && _camera != Camera.main)
            Destroy(Camera.main.gameObject);

        _camera.tag = "MainCamera";
        DontDestroyOnLoad(Camera.main);
        GameManager.Instance.SetCamera(Camera.main);   
    }
}
