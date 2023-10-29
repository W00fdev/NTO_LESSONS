using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseField : MonoBehaviour
{
    public CurseManager CurseController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CurseController.Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CurseController.Disable();
        }
    }
}
