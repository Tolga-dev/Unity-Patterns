using UnityEngine;

namespace Solid.E1
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Vector3 input;

        private void Update()
        {
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");
        }


        public Vector3 GetInput() => input;
    }
}