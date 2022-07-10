using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class CameraFollowerPrototype : MonoBehaviour
    {
        [SerializeField] private bool smoothMovement = false;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime = 0.5f;

        private Vector3 initialDistance;
        private Vector3 currentVelocity;

        void Awake()
        {
            initialDistance = transform.position - target.position;
        }

        void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + initialDistance, ref currentVelocity, (smoothMovement ? smoothTime : 0));
        }
    }
}


