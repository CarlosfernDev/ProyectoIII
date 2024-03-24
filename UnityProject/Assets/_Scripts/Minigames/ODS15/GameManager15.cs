using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager15 : MonoBehaviour
{
    public static GameManager15 Instance { get; private set; }

    //PosObjetosHabitat
    public Transform posComida;
    public Transform posHabitat;
    public Transform posDecoracion;
    //ObjetoAnimal
    public Animal animalActivo = new Animal();

    //ReferenciasHabitat
    public GameObject Habitat1;
    public GameObject Habitat2;
    public GameObject Habitat3;
    //ReferenciasComida
    public GameObject Comida1;
    public GameObject Comida2;
    public GameObject Comida3;
    //ReferenciasDecoracion
    public GameObject Decoracion1;
    public GameObject Decoracion2;
    public GameObject Decoracion3;


    //CosasActivas
    public int DecoracionActiva;
    public int ComidaActiva;
    public int HabitatActivo;


    //ReferenciasMenus
    public GameObject HabitatMenu;
    public GameObject AlimentacionMenu;
    public GameObject DecoracionMenu;


    //CanvasSwap
    public GameObject CanvasDialogo;
    public GameObject CanvasGameplay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        InputManager.Instance.equipableEvent.AddListener(CanvasSwap);
    }


    private void Start()
    {
        animalActivo.Comida = Random.Range(0, 2);
        animalActivo.Habitat = Random.Range(0, 2);
        animalActivo.Decoracion = Random.Range(0, 2);
        //printAnimal(animalActivo);
    }



    private void Update()
    {
        checkConditionsmet(animalActivo);
    }




    public void MenusSwap(int i)
    {
        switch (i)
        {
            case 0:
                HabitatMenu.SetActive(true);
                AlimentacionMenu.SetActive(false);
                DecoracionMenu.SetActive(false);
                break;
            case 1:
                HabitatMenu.SetActive(false);
                AlimentacionMenu.SetActive(true);
                DecoracionMenu.SetActive(false);
                break;
            case 2:
                HabitatMenu.SetActive(false);
                AlimentacionMenu.SetActive(false);
                DecoracionMenu.SetActive(true);
                break;
            default:
                Debug.LogError("Valor No considerado en FuncionMenuSwap");
                break;
        }
    }

    public void SetComidaActiva(int i)
    {
        ComidaActiva = i;

    }

    public void SetHabitatActiva(int i)
    {
        HabitatActivo = i;

    }

    public void SetDecoracionActiva(int i)
    {
        DecoracionActiva = i;

    }



    private void checkConditionsmet(Animal animal)
    {
        if (animal.Comida == ComidaActiva && animal.Habitat == HabitatActivo && animal.Decoracion == DecoracionActiva)
        {
            Debug.Log("win");
        }
        else
        {
            printAnimal(animal);
            Debug.Log("ACTUAL PARAMETERS");
            Debug.Log("HAB " +HabitatActivo);
            Debug.Log("COM " + ComidaActiva);
            Debug.Log("DEC " + DecoracionActiva);


        }
    }

    

    void printAnimal(Animal animal)
    {
        Debug.Log("Comida: "+ animal.Comida);
        Debug.Log("Habitat: " + animal.Habitat);
        Debug.Log("Decoracion: " + animal.Decoracion);
    }

    public void CanvasSwap()
    {
        Debug.Log("CANVAS");
        if (CanvasDialogo.activeInHierarchy)
        {
            CanvasDialogo.SetActive(false);
            CanvasGameplay.SetActive(true);
        }
        else
        {
            CanvasDialogo.SetActive(true);
            CanvasGameplay.SetActive(false);
        }
    }
}

public class Animal
{
    public int Habitat;
    public int Comida;
    public int Decoracion;
}