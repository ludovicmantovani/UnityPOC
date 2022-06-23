using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAPlayerController : MonoBehaviour
{
    [SerializeField] Transform _fruitGO;
    [SerializeField] Transform _achatGO;
    [SerializeField] Transform _venteGO;
    [SerializeField] Transform _tissuGO;
    [SerializeField] Transform _laineGO;

    private Dictionary<Zone, Transform> _map;

    private Zone _currentZone = Zone.NONE;

    private NavMeshAgent _navMeshAgent;

    public Zone CurrentZone { get => _currentZone; set => _currentZone = value; }

    void Start()
    {
        _map = new Dictionary<Zone, Transform>();
        _map.Add(Zone.FRUTS, _fruitGO);
        _map.Add(Zone.PURCHASE, _achatGO);
        _map.Add(Zone.SALE, _venteGO);
        _map.Add(Zone.TISSUE, _tissuGO);
        _map.Add(Zone.WOOL, _laineGO);

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_navMeshAgent != null && _map != null && _map.ContainsKey(_currentZone))
        {
            _navMeshAgent.SetDestination(_map[_currentZone].position);
        }
    }
}
