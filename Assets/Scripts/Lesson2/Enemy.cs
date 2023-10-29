using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject CurseParticle;
    public bool IsBoss;

    // Start is called before the first frame update
    void Start()
    {
        if (IsBoss)
            CurseParticle.SetActive(true);
        else
            CurseParticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
