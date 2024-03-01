using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PancartaComponentData", menuName = "ScriptableObjects/ODS10/ListaComponentes", order = 3)]
public class ScriptableListaComponentes : ScriptableObject
{
    public List<ScriptableObjectComponente> ListaComponentes;
}
