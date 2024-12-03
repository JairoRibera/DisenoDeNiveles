using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animPalanca;
    public Lever[] palancaDesactivar = new Lever[4];
    public bool isActive;
    public bool canInteract;
    private LeverCodeManager _pCM;
    private void Start()
    {
        _pCM = FindAnyObjectByType<LeverCodeManager>();
        animPalanca = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            isActive = true;
            animPalanca.SetBool("LeverUp", true);
            foreach (var palanquitauwu in palancaDesactivar)
            {
                if(isActive == true)
                {
                    palanquitauwu.desactivar();
                }
                else
                {
                    palanquitauwu.activar();
                }
            }
        }
    }
    public void desactivar()
    {
        isActive = false;
        animPalanca.SetBool("LeverUp", false);
    }
    public void activar()
    {
        isActive = true;
        animPalanca.SetBool("LeverUp", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
