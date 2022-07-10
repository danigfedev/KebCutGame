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
        private Quaternion rotationPreCollision;
        private Vector3 velocityPreCollision;
        private Vector3 angularVelocityPreCollision;

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

                gunRigidbody.AddTorque(torqueForce * Vector3.right);
                gunRigidbody.AddForce(impulseForce * forceDirection);
            }
        }

        private void FixedUpdate()
        {

            velocityPreCollision = gunRigidbody.velocity;
            angularVelocityPreCollision = gunRigidbody.angularVelocity;
            rotationPreCollision = transform.rotation;
            Debug.DrawRay(transform.position, 5 * angularVelocityPreCollision, Color.green);

        }

        private void OnCollisionEnter(Collision collision)
        {
            //Check collision with ground


            var sliceableItem = collision.gameObject.GetComponent<SliceableItem>();

            if(sliceableItem == null)
            {
                return;
            }

            //Resetting previous values
            transform.rotation = rotationPreCollision;
            gunRigidbody.velocity = velocityPreCollision;
            //gunRigidbody.angularVelocity = angularVelocityPreCollision;
            gunRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
