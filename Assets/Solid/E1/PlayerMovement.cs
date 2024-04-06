using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Solid.E1
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 vector3;
        private void Update()
        {
            transform.position += vector3;
        }

        public void SetInput(Vector3 newInput)
        {
            vector3 = newInput;
        }
    }
}