using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CurseManager CurseController;

    public GameObject DebuffParticle;
    public GameObject Slash;

    public LayerMask LayerEnemy;

    public float CooldownAttack;

    private bool _attackReady;
    private float _time;

    private void Update()
    {
        if (_attackReady == false)
        {
            _time += Time.deltaTime;
            if (_time < CooldownAttack)
            {
                _time -= CooldownAttack;
                _attackReady = true;
            }
        }

        Debug.DrawLine(transform.position + Vector3.forward, transform.position + 3f * Vector3.forward);
        Debug.DrawLine(transform.position + Vector3.forward, transform.position + 3f * Vector3.back);


        if (_attackReady == true && Input.GetMouseButtonDown(0))
        {
            Slash.SetActive(false);
            Slash.SetActive(true);

            Collider[] coliders = Physics.OverlapBox(transform.position + Vector3.forward, Vector3.one * 2f, Quaternion.identity, LayerEnemy);


            if (coliders != null)
            {
                foreach (Collider col in coliders)
                {
                    if (col.GetComponent<Enemy>().IsBoss)
                        CurseController.TryDisableCurse_FromBoss();

                    col.gameObject.SetActive(false);
                }
            }

            _attackReady = false;
        }
    }



    public void DebuffEnable()
    {
        DebuffParticle.SetActive(true);
    }

    public void DebuffDisable()
    {
        DebuffParticle.SetActive(false);
    }
}
