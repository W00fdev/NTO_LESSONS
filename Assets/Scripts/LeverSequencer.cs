using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSequencer : MonoBehaviour
{
    public GateAnimation Gate;
    
    [SerializeField] private int[] _correctSequence;

    private int[] _sequence;
    private int _currentIndex;

    private void Awake()
    {
        //_correctSequence = new int[3] { 0, 1, 2 };
        _currentIndex = 0;

        _sequence = new int[_correctSequence.Length];
    }

    public void UseLever(int leverIndex)
    {
        _sequence[_currentIndex] = leverIndex;
        _currentIndex++;

        if (_currentIndex == _correctSequence.Length)
        {
            _currentIndex = 0;

            for (int i = 0; i < _correctSequence.Length; i++)
            {
                if (_sequence[i] != _correctSequence[i])
                {
                    ResetLevers();
                    return;
                }
            }

            Gate.OpenGate();
        }
    }

    private void ResetLevers()
    {
        Debug.Log("Levers are reseted");
        // foreach lever: animation to close
    }
}
