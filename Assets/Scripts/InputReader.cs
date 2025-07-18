using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    
    private bool _isJump;

    public float Direction { get; private set; }
    [SerializeField] private string _verticalAxis = "Vertical";

    public float VerticalDirection => Input.GetAxis(_verticalAxis);
    private void Update()
    {
        Direction = Input.GetAxis(ConstantsData.InputData.HORIZONTAL_AXIS);

        if (Input.GetKeyDown(KeyCode.W))
            _isJump = true;
    }

    public bool GetIsJump()
    {
        bool isJump = _isJump;
        _isJump = false;
        return isJump;
    }
}
