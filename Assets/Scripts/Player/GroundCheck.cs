using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded { get { return isGrounded; } set => isGrounded = value; }
    [SerializeField] LayerMask groundCheckLayer;
    private bool isGrounded;

    private void OnTriggerStay2D(Collider2D other) {
        isGrounded = other != null && (((1<< other.gameObject.layer) & groundCheckLayer) != 0);
    }

    private void OnTriggerExit2D(Collider2D other) {
        isGrounded = false;
    }
}
