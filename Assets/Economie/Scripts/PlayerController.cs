using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField] private float _moveSpeed = 10;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private Camera _cam;
    //[SerializeField] private CharacterLife _enemyLife;
    //[SerializeField] private float _minEnemyDistanceToAttack = 1f;


    private float _horizontal;
    private float _vertical;
    private float _turnSmoothVelocity;
    private Vector3 _movement;
    private Vector3 _direction = Vector3.zero;
    private CharacterController _cc;
    private PlayerInputs _playerInputs;
    //private bool _onAttack = false;

    //private Animator _animator;

    #endregion

    #region Properties
    #endregion

    #region Built in Methods
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        _playerInputs = GetComponent<PlayerInputs>();
        //_animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Mise à jour des déplacements
        Locomotion();
        // Gestion de l'attaque du joueur
        // Attack();
        // Mise à jour des animations
        UpdateAnimation();
    }
    #endregion

    #region Custom Methods

    /// <summary>
    /// Mise à jour des animations
    /// </summary>
    void UpdateAnimation()
    {
        // _animator.SetBool("walk", _playerInputs);
    }


    /// <summary>
    /// Déplacements du player
    /// </summary>
    void Locomotion()
    {
        if (!_playerInputs) return;
        
        //Calcul du deplacement sur le plan x z avec les inputs x et y du clavier
        _horizontal = _playerInputs.Movement.x;
        _vertical = _playerInputs.Movement.y;

        _direction.Set(_horizontal, 0, _vertical);

        //Calcul l'angle à appliquer au player
        if (_direction.normalized.magnitude >= 0.1f)
        {
            //_animator.SetBool("walk", true);
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + _cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                _turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        else
        {
            //_animator.SetBool("walk", false);
        }

        _movement = _direction.normalized * (_moveSpeed * Time.deltaTime);
        _cc.Move(_movement);
    }
    #endregion


}