using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    public class GroundFollowerPrototype : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Vector3 initialPosition;

        void Awake()
        {
            initialPosition = transform.position;
        }

        void LateUpdate()
        {
            transform.position = target.position.z * Vector3.forward;
        }
    }
}
