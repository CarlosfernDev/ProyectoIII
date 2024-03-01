using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ODS10Singleton : MinigameParent
{
    public Camera PancartaCamera;
    public static ODS10Singleton Instance;
    byte[] bytes;

    [SerializeField] PancartaScriptableObject pancartaScriptableObject;

    protected override void personalAwake()
    {
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
        StartCoroutine(CoroutineScreenshot());
    }

    private void Update()
    {

    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        pancartaScriptableObject.SaveTexture();
        pancartaScriptableObject.LoadTexture();
    }
}
