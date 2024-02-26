using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ODS10Singleton : MinigameParent
{
    public Camera PancartaCamera;
    public static ODS10Singleton Instance;
    public Material _PancartaMaterial;
    byte[] bytes;

    protected override void personalAwake()
    {
        Instance = this;
        base.personalAwake();
    }

    protected override void personalStart()
    {
        base.personalStart();
        LoadTexture();
    }

    private void Update()
    {

    }

    private IEnumerator CoroutineScreenshot()
    {
        yield return new WaitForEndOfFrame();

        RenderTexture renderTexture = PancartaCamera.targetTexture;

        Texture2D screenshotTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = renderTexture;

        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        byte[] byteArray = screenshotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(SaveManager.SAVE_FOLDER + "Pancarta.png", byteArray);

        RenderTexture.active = null;
        Debug.Log("Foto realizada");
    }

    private void LoadTexture()
    {
        bytes = File.ReadAllBytes(SaveManager.SAVE_FOLDER + "Pancarta.png");



        Texture2D LoadedImage = new Texture2D(PancartaCamera.targetTexture.width, PancartaCamera.targetTexture.height);
        LoadedImage.LoadImage(bytes);
        _PancartaMaterial.mainTexture = LoadedImage;
    }
}
