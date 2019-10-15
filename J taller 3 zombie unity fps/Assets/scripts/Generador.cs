using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.enemy;
using NPC.Ally;
using System;



public class Generador : MonoBehaviour
{
    readonly int minimo; // variable utilizada para la generacion random junto son random.system  
    GameObject Objeto_zombie;      //variable para la cracion de gameobject de zombie
    GameObject Objeto_Gente;           //variable para la cracion de gameobject de aldeano

    GameObject Hero;            // variable para la cracion de gameobject del hero 
    CosasZombie datoZombi;      // variable de la estructura de los zombies
    CosasCiudadanos datoCiudadanos; //variable de la estructura de los ciudadnos
               
    const int maximo = 25;          //  variable que siempre mantiene su valor
    int cantbody;                   // creacion de variable para guardar el resutado de un rando,
    public Text enemy;              // variable para la creacion de un texto en canvas
    public Text Ally;              //  variable para la creacion de un texto en canvas



    System.Random randomG = new System.Random();     // rando de lalibrerias system 

    public Generador()
    {
        minimo = randomG.Next(5, 15);    //rango de creación

    }
 
 
    //"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
    void Start()
    {                                 // generador de NPC ya tiene su numero minimo y maximo
        cantbody = randomG.Next(minimo, maximo);
        for (int i = 0; i < cantbody; i++)
        {
            if (randomG.Next(0, 2) == 0)
            {                               // generador de zombis
                Objeto_zombie = GameObject.CreatePrimitive(PrimitiveType.Cube);    // creacion de un primityve para los zombies
                Objeto_zombie.AddComponent<ZombiesS>();

                datoZombi = Objeto_zombie.GetComponent<ZombiesS>().datosZombi;
                switch (datoZombi.colorCaso)                                      // cambio de color para los zombie cuando se crean 
                {
                    case CosasZombie.ColorZombie.magenta:
                        Objeto_zombie.GetComponent<Renderer>().material.color = Color.magenta;

                        break;
                    case CosasZombie.ColorZombie.green:
                        Objeto_zombie.GetComponent<Renderer>().material.color = Color.green;

                        break;
                    case CosasZombie.ColorZombie.cyan:
                        Objeto_zombie.GetComponent<Renderer>().material.color = Color.cyan;
                        break;
                }


                Vector3 posicionZO = new Vector3(randomG.Next(-10, 10), 0, randomG.Next(-10, 10));       // posicion de la creacion de los zombie
                Objeto_zombie.transform.position = posicionZO;
                Objeto_zombie.AddComponent<Rigidbody>();
                Objeto_zombie.name = "Zombi";
            }
            else // generador de ciudadanos
            {
                Objeto_Gente = GameObject.CreatePrimitive(PrimitiveType.Cube); // creacion de un primitive para el ciudadano
                Objeto_Gente.AddComponent<CiudadanosS>();
                Vector3 posciAL = new Vector3(randomG.Next(-20, 10), 0, randomG.Next(10, 10)); //posisicon de la creacion de los aldeanos 
                Objeto_Gente.transform.position = posciAL;
                Objeto_Gente.AddComponent<Rigidbody>();
                Objeto_Gente.name = "Gente";
            }
        }

        // generador hero 
        Hero = GameObject.CreatePrimitive(PrimitiveType.Cube);  // creacionde de un primitive para el hero
        Hero.AddComponent<FPSmovimiento>();
        Hero.AddComponent<Hero>();
        Hero.AddComponent<Camera>();
        Hero.AddComponent<Rigidbody>();
        
        Hero.name = "Hero";


        int num_zombie = 0;   // contadotes de los zombies y aldeanos el cual se va suman si encuentra lo que esta buscando
        int num_aldeanos = 0;
        // para se usado en el texto canvas y ser mostrado en la interfaz del a scena

        foreach (ZombiesS enemy in Transform.FindObjectsOfType<ZombiesS>())         // este busca a todos los objeto que tenga el scrit de zombies y los coloca en un enumerado para despues llamaros a canvas
        {
            num_zombie++;
        }

        foreach (CiudadanosS ally in Transform.FindObjectsOfType<CiudadanosS>())// este busca a todos los objeto que tenga el scrit de ciudadanos y los coloca en un enumerado para despues llamaros a canvas
        {
            {
                num_aldeanos++;
            }
            Debug.Log(num_zombie);
            enemy.text = "zombies: " + num_zombie;
            Ally.text = "aldeanos: " + num_aldeanos;
        }




    }
}
