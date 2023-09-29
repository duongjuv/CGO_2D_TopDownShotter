using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, _rotationSpeed;

    private Rigidbody2D _rigibody2D;
    private Vector2 _movementInput, _smoothMovementInput, _movementInputSmoothVelocity; 

    // Start is called before the first frame update
    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }
    void OnMove(InputValue inputValue)
    {     
        _movementInput = inputValue.Get<Vector2>();
    }
    private void SetPlayerVelocity()
    {
        // di chuyển nhân vật mượt hơn
        _smoothMovementInput = Vector2.SmoothDamp(_smoothMovementInput,
                _movementInput, 
                    ref _movementInputSmoothVelocity, 0.1f);
        _rigibody2D.velocity = _smoothMovementInput * moveSpeed;
    }
    public void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
                        _rotationSpeed * Time.deltaTime);
            _rigibody2D.MoveRotation(rotation);
        }
    }


}
