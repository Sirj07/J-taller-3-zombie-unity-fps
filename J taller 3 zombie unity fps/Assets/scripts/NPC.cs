using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPC               // creacion de los namespace
{
    namespace enemy
    {
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class ZombiesS : MonoBehaviour
        {      
            public CosasZombie datosZombi;          // variable de la estructura delos zombies
            int cambio_movimiento; // variable para el cambio de movimiento
            void Awake()
            {
                datosZombi.colorCaso = (CosasZombie.ColorZombie)Random.Range(0, 3); // random para los colores de los zombies
                int dargusto = Random.Range(0, 5);  //random para el gusto
                datosZombi.sabroso = (CosasZombie.Gustos)dargusto; //asignacion del random de los zombie
            }
            void Start()
            {
                
             datosZombi.condicion = (CosasZombie.Estados)0;     // inicio de la corutina
             StartCoroutine ("Cambioestado");   //iniciando lacorutina
            }


            void Update()       //cambio de los estado de los zombies
            {       
                switch(datosZombi.condicion)
                {
                case CosasZombie.Estados.Idle:
                transform.position += new Vector3(0, 0f, 0);
                break;
                case CosasZombie.Estados.Moving:
                if (cambio_movimiento == 0)
                {
                transform.position += new Vector3(0, 0, 0.03f);
                }
                else if (cambio_movimiento == 1)
                {
                transform.position -= new Vector3(0, 0, 0.03f);
                }
                else if(cambio_movimiento == 2)
                {
                transform.position -= new Vector3(0.03f, 0, 0);
                }
                else if (cambio_movimiento == 3)
                {
                transform.position += new Vector3(0.03f, 0, 0);
                }
                break; 

                case CosasZombie.Estados.Rotating:
                transform.eulerAngles += new Vector3 (0,0.5f,0);
                
                break;

                default:
                break;
                }
            }
            IEnumerator Cambioestado()  // la corutina cambiara el estado del zombi cada 3 sg
            {
                while (true)
                {
                    datosZombi.condicion = (CosasZombie.Estados)Random.Range(0, 3);                   
                    yield return new WaitForSeconds(3);

                    if (datosZombi.condicion == (CosasZombie.Estados)0)
                    {
                        datosZombi.condicion = (CosasZombie.Estados)1;
                        cambio_movimiento = Random.Range(0, 3);
                    }
                    else if (datosZombi.condicion == (CosasZombie.Estados)1)
                    {
                        datosZombi.condicion = (CosasZombie.Estados)2;
                    }
                    
                }   
                   
            }
        }

        public struct CosasZombie       // estructura que contiene los enum de los zombies
        {
            public enum Gustos 
            {
                Brazos,
                Piernas,
                Huesos,
                Ojos,
                corazon
            };
            public Gustos sabroso;

            public enum Estados
            {
                Idle,
                Moving,
                Rotating
            };
            public Estados condicion;

            public enum ColorZombie
            {
                magenta,
                green, 
                cyan
            };
            public ColorZombie colorCaso;
        }

    }

    namespace Ally      // el namespace de los aldeanos
    {
        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class CiudadanosS : MonoBehaviour
        {
            public CosasCiudadanos datoCiudadanos;  //variable de la estructura de los ciudadnos

            void Awake()
            {


                int Radom_nombre = Random.Range(0, 20);    ////random de los nombres de los ciudadanos
                datoCiudadanos.genteNombres = (CosasCiudadanos.Nombres)Radom_nombre;   ///variable que guarda el random de los nombre
                int random_edad = Random.Range(15, 100);//random de las edades
                datoCiudadanos.edadgente = (CosasCiudadanos.Edad)random_edad;//variables que guarda el random de las edades

            }

    
            
        }

        public struct CosasCiudadanos           //estructura de los aldeanos que guarda los enum
        {
            public enum Nombres
            {
                rodrigo,
                robin,
                torre,
                pequeñi,
                don_juan,
                blue,
                saltin,
                sergio,
                estevan,
                tu_tia_en_tanga,
                tu_colega ,
                camilo,
                crespos,
                alexis,
                hay_te_va_sam_pedro,
                fly,
                jason,
                andrey,
                atreus,
                artion,
                alegandra,
                zeus,
                mauricio,
                puto_el_que_lo_lea,
                el_wilson_bolso,
                el_brayan,
                el_benites ,
                carlos,
            }
            public Nombres genteNombres;

            public enum Edad
            {
                edad
            }
            public Edad edadgente;
        }

    }

}


