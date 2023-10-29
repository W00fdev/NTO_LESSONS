using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    public Animator AnimatorReference;
    public string OpenTriggerName;

    private bool _isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenGate()
    {
        if (_isOpen == true)
            return;

        AnimatorReference.SetTrigger(OpenTriggerName);
        _isOpen = true;
    }

}
