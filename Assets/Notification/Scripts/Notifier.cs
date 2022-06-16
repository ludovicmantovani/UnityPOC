using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Notifier : MonoBehaviour
{
    [SerializeField] private float _displayTime = 5.0f;
    [SerializeField] private float _lastDisplayTime;

    private TMP_Text _info;
    private bool _isDisplay = false;
    private Queue<string> _messages;

    void Start()
    {
        _messages = new Queue<string>();
        if (TryGetComponent<TMP_Text>(out _info))
        {
            _info.text = "";
        }
    }

    void Update()
    {
        if (_messages.Count > 0)
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

    public void NotifyReproduce(GameObject gameObject)
    {
        _messages.Enqueue(gameObject.name + " peut se reproduire");
    }
}
