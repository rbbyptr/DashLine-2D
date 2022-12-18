using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _dashSpeed = 50f;
    [SerializeField] private float _defaultDash = 50f;
    [SerializeField] private bool _dash = true;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (_dash == true && horizontalInput == -1f)
        {
            _rb.velocity = new Vector2((horizontalInput * _dashSpeed), _rb.velocity.y);
            _dash = false;
            StartCoroutine(DashSpeedResetRoutine());
        }
        else if (_dash == true && horizontalInput == 1f)
        {
            _rb.velocity = new Vector2((horizontalInput * _dashSpeed), _rb.velocity.y);
            _dash = false;
            StartCoroutine(DashSpeedResetRoutine());
        }
    }

    IEnumerator DashSpeedResetRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _dashSpeed = 0f;
        yield return new WaitForSeconds(0.4f);
        _dash = true;
        _dashSpeed = _defaultDash;
    }
}
