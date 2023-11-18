using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humor : MonoBehaviour
{

    public Animator animPublico;

    [SerializeField]
    private Animator animPrivado;

    void Start()
    {
        animPrivado = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            Debug.Log("Espacio");
            animPrivado.SetTrigger("Cambiar");
            animPrivado.SetTrigger(3);
        }

    }
}
