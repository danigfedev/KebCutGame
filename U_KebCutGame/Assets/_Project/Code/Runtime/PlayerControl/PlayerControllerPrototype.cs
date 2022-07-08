using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControllerPrototype : MonoBehaviour
    {
        [SerializeField] private float torqueForce;
        [SerializeField] private float impulseForce;
        [Tooltip("The angle of the impulse direction, in degrees, measured from the item's horizontal axis on its initial state (transform.forward)")]
        [SerializeField] private float impulseOrientation = 45;

        private Rigidbody gunRigidbody;
        private Vector3 forceDirection;

        void Awake()
        {
            gunRigidbody = GetComponent<Rigidbody>();
            forceDirection = Quaternion.Euler(impulseOrientation, 0, 0) * transform.forward;
        }

        void Update()
        {
            Debug.DrawRay(transform.position, 5 * forceDirection, Color.red);

            if (Input.GetMouseButtonDown(0))
            {
                gunRigidbody.angularVelocity = Vector3.zero;
                gunRigidbody.velocity = Vector3.zero;

                //Vector3 torqueDirection = Vector3.Dot(transform.forward, Vector3.forward) > 0 ? Vector3.right : -Vector3.right;
                gunRigidbody.AddTorque(torqueForce * Vector3.right);
                
                gunRigidbody.AddForce(impulseForce * forceDirection);
            }
        }
    }
}
