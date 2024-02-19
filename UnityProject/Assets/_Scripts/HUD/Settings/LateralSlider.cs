using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SettingData
{
    public string Name;
    public UnityEvent ValueAction;
}

public class LateralSlider : MonoBehaviour
{
    public List<SettingData> TextSettings;
    [SerializeField] TMP_Text m_text;
    public int IndexState = 0;

    private void Start()
    {
        UpdateText();
    }

    public void NextAction(int i)
    {
        IndexState++;

        if (IndexState > TextSettings.Count - 1)
            IndexState = 0;
        else if(IndexState < 0)
            IndexState = TextSettings.Count - 1;

        UpdateText();

        ApplyChange();
    }

    public void UpdateValue() 
    {
        if (IndexState > TextSettings.Count - 1)
            IndexState = 0;
        else if (IndexState < 0)
            IndexState = TextSettings.Count - 1;

        UpdateText();
    }

    public void ApplyChange()
    {
        if(TextSettings[IndexState].ValueAction == null)
        {
            Debug.LogWarning("Este ajuste no se puede aplicar por que le falta una accion");
            return;
        }

        TextSettings[IndexState].ValueAction.Invoke();
    }

    public void UpdateText()
    {
        m_text.text = TextSettings[IndexState].Name;
    }

}
