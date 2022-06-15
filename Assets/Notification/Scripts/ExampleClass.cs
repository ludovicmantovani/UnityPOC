using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ExampleClass : MonoBehaviour
{

    [SerializeField] private float _displayTime = 5.0f;
    [SerializeField] private float _lastDisplayTime;

    [SerializeField] private TMP_Text _info;

    private int _nbr = 1;
    private bool _isDisplay = false;

    private Queue<string> _messages;

    UnityEvent m_MyEvent;
    void Start()
    {
        if (m_MyEvent == null)
        {
            m_MyEvent = new UnityEvent();
        }
        m_MyEvent.AddListener(Print);
        if (_info != null)
        {
            _info.text = "";
        }
        _messages = new Queue<string>();
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke();
        }

        if (_messages.Count > 0) // si messages à afficher
        {
            if (!_isDisplay)
            {
                _isDisplay = true;
                if (_info)
                {
                    _info.text = _messages.Dequeue();
                    _lastDisplayTime = Time.time;
                }
            }
        }
        if ((Time.time - _lastDisplayTime) >= _displayTime)
        {
            _info.text = "";
            _isDisplay = false;
        }
    }

    void Print()
    {
        _messages.Enqueue("Test" + _nbr);
        _nbr++;
    }
}
