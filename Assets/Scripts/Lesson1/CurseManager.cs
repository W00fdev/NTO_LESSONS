using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CurseType { Enemy, Damage };

public class CurseManager : MonoBehaviour
{
    public CanvasManager CanvasScript;
    public EnemyManager EnemyController;
    public Player PlayerScript;
    public CurseField CurseArea;

    public int CurseCooldown;
    public int CurseDamage;
    public int Health;

    public bool IsCurseActive;

    [Header("Стаки")]
    public int StackDamage;
    public bool StackApply;

    public CurseType Type;

    private float _time;
    private int _maxHealth;

    private void Awake()
    {
        _maxHealth = Health;
        _time = 0f;

        if (Type == CurseType.Enemy)
        {
            EnemyController.PowerupEnemies();
        }
    }

    private void Update()
    {
        if (IsCurseActive == true && Type == CurseType.Damage)
        {
            _time += Time.deltaTime;

            if (_time > CurseCooldown)
            {
                _time -= CurseCooldown;
                DealDamage();
            }
        }
        else
        {
            // 
        }
    }

    private void DealDamage()
    {
        Health = Mathf.Clamp(Health - CurseDamage, 0, _maxHealth);
        CanvasScript.ChangeHealth((float)Health / _maxHealth);

        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (StackApply == true)
        {
            CurseDamage += StackDamage;
        }
    }

    public void Enable()
    {
        IsCurseActive = true;
        PlayerScript.DebuffEnable();
    }

    public void Disable()
    {
        IsCurseActive = false;
        PlayerScript.DebuffDisable();


        if (Type == CurseType.Enemy)
        {
            EnemyController.DebuffEnemies();
        }
    }

    public void TryDisableCurse_FromSphere()
    {
        if (Type == CurseType.Damage)
        {
            CurseArea.gameObject.SetActive(false);
            Disable();
        }
    }

    public void TryDisableCurse_FromBoss()
    {
        if (Type == CurseType.Enemy)
        {
            CurseArea.gameObject.SetActive(false);
            Disable();
        }
    }
}
