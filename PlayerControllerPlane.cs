using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlane : MonoBehaviour
{
    //PROPIEDADES
    /* Public: modificable por el editor y todos los scripts (altamente inseguro)
     * [SerializeField] private: modificable por el editor solamente (seguro)
     * Private: Nada lo puede modificar (maxima seguridad)*/
    
    //[HideInInspector] a pesar de que es publica no se muestra en el editor
    [Range(0,100), SerializeField, Tooltip("Velocidad maxima lineal del carro")] 
    private float speed = 10;
    private float dirx, dirz;
    [Range(20,80), SerializeField, Tooltip("Velocidad de giro del carro")]
    private float turnspeed =60;

    public GameObject propeller;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        //Avanzar carro
        // S = s0 + v*t*(direccion)
        dirx = Input.GetAxis("Horizontal");
        dirz = Input.GetAxis("Vertical");
        
        transform.Rotate(turnspeed*Time.deltaTime*dirz*Vector3.right);
        transform.Rotate(turnspeed*Time.deltaTime*-dirx*Vector3.forward);

        if (Input.GetButton("Jump"))
        {
            transform.Translate(speed*Time.deltaTime*Vector3.forward);
            propeller.transform.Rotate(Time.deltaTime*1000*Vector3.forward);
        }
      
    }
}
