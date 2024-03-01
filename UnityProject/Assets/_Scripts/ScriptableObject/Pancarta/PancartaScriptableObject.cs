using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[CreateAssetMenu(fileName = "PancartaData", menuName = "ScriptableObjects/Pancarta", order = 1)]
public class PancartaScriptableObject : ScriptableObject
{
    public Material _PancartaMaterial;
    public RenderTexture _PacartaRenderTexture;


    public void LoadTexture()
    {
        if (!File.Exists(SaveManager.SAVE_FOLDER + "Pancarta.png")) return;
        byte[] bytes = File.ReadAllBytes(SaveManager.SAVE_FOLDER + "Pancarta.png");

        Texture2D LoadedImage = new Texture2D(_PacartaRenderTexture.width, _PacartaRenderTexture.height);
        LoadedImage.LoadImage(bytes);
        _PancartaMaterial.mainTexture = LoadedImage;
    }

    public void SaveTexture()
    {
        Texture2D screenshotTexture = new Texture2D(_PacartaRenderTexture.width, _PacartaRenderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = _PacartaRenderTexture;

        Rect rect = new Rect(0, 0, _PacartaRenderTexture.width, _PacartaRenderTexture.height);
        screenshotTexture.ReadPixels(rect, 0, 0);
        screenshotTexture.Apply();

        byte[] byteArray = screenshotTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(SaveManager.SAVE_FOLDER + "Pancarta.png", byteArray);

        RenderTexture.active = null;
        Debug.Log("Foto realizada");
    }
}
