using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
    public CurseManager CurseController;
    public LeverSequencer LeverManager;

    public LayerMask LayerRaycast;

    private Color[] _colorsOriginal;
    private Color[] _yellowColors;

    private Color _cursedColor;
    private MeshRenderer _meshRenderer;

    private bool _colorsTaken;
    private bool _colorCursedTaken;

    // Start is called before the first frame update
    void Start()
    {
        _colorsOriginal = new Color[3];
        _yellowColors = new Color[3] { Color.yellow, Color.yellow, Color.yellow };
        _colorsTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerRaycast))
        {
            if (_meshRenderer == null)
            {
                _meshRenderer = hit.collider.GetComponent<MeshRenderer>();
            }
            else if (_meshRenderer.gameObject != hit.collider.gameObject)
            {
                ResetColors();
                _meshRenderer = hit.collider.GetComponent<MeshRenderer>();
            }

            if (_meshRenderer.gameObject.layer.CompareTo(LayerMask.NameToLayer("Cursed")) == 0)
            {
                UpdateMaterialColor_Cursed(Color.yellow);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CurseController.TryDisableCurse_FromSphere();
                }
            }
            else
            {
                UpdateMaterialsColors_Lever(_yellowColors);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LeverManager.UseLever(hit.collider.GetComponent<LeverScript>().LeverIndex);
                }
            }
        }
        else 
        {
            ResetColors();
        }

    }

    private void ResetColors()
    {
        if (_meshRenderer == null)
            return;
        
        if (_colorCursedTaken == true)
            UpdateMaterialColor_Cursed(_cursedColor);

        if (_colorsTaken == true)
            UpdateMaterialsColors_Lever(_colorsOriginal);
    }

    private void UpdateMaterialColor_Cursed(Color color)
    {
        if (_colorCursedTaken == false)
            _cursedColor = _meshRenderer.material.color;

        _meshRenderer.material.color = color;

        _colorCursedTaken = true;
    }

    private void UpdateMaterialsColors_Lever(Color[] colors)
    {
        int index = 0;

        foreach (Material material in _meshRenderer.materials) 
        {
            if (_colorsTaken == false)
            {
                _colorsOriginal[index] = material.color;
            }

            material.color = colors[index];
            index++;
        }

        _colorsTaken = true;
    }
}
