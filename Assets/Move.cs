using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class move : MonoBehaviour
    {

        [SerializeField] private float speed = 1000.0f;


        private CharacterController cc;

        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 input = new Vector2(horizontal, vertical);
            Vector3 Move = transform.forward * input.y + transform.right * input.x;
            Vector3 move = new Vector3(Move.x * speed, 0, Move.z * speed);
            cc.Move(move * Time.fixedDeltaTime);
        }
    }