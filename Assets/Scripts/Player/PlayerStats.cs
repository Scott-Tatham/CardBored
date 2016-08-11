using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    #region LifeStats
    [SerializeField]
    private float health;
    #endregion

    #region MoveStats
    [SerializeField]
    private float moveSpeed;
    private Vector3 directionVelocity;
    #endregion

    #region JumpStats
    [SerializeField]
    private float jumpSpeed;
    private Vector3 jumpVelocity;
    private bool appSurface;
    #endregion

    #endregion

    #region Getters

    #region LifeStats
    public float GetHealth() { return health; }
    #endregion

    #region MoveStats
    public float GetMoveSpeed() { return moveSpeed; }
    public Vector3 GetDirectionalVelocity() { return directionVelocity; }
    #endregion

    #region JumpStats
    public float GetJumpSpeed() { return jumpSpeed; }
    public Vector3 GetJumpVelocity() { return jumpVelocity; }
    public bool GetAppSurface() { return appSurface; }
    #endregion

    #endregion

    #region Setters

    #region LifeStats
    public void SetHealth(float _health) { health = _health; }
    #endregion

    #region MoveStats
    public void SetMoveSpeed(float _moveSpeed) { moveSpeed = _moveSpeed; }
    public void SetDirectionalVelocity(Vector3 _directionalVelocity) { directionVelocity = _directionalVelocity; }
    #endregion

    #region JumpStats
    public void SetJumpSpeed(float _jumpSpeed) { jumpSpeed = _jumpSpeed; }
    public void SetJumpVelocity(Vector3 _jumpVelocity) { jumpVelocity = _jumpVelocity; }
    public void SetAppSurface(bool _appSurface) { appSurface = _appSurface; }
    #endregion

    #endregion

    void Awake()
    {
        SetDirectionalVelocity(Vector3.zero);
        
        SetAppSurface(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log(GetHealth());
        }
    }
}