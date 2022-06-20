using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    #region PRIVATE VARIABLE
    [SerializeField]
    private Vector2 _movement = Vector2.zero;
    private bool _clik;
    public Vector2 Movement => _movement;
    public bool Clik => _clik;
    #endregion

    #region BUILTIN METHOD
    void Update()
    {
        _movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _clik = Input.GetButton("Fire1");
    }
    #endregion
}