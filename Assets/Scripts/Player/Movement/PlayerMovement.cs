using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo{
    public class PlayerMovement : MonoBehaviour
    {
        private MovementFSM machine;

        void Awake()
        {
            machine = new MovementFSM();
            machine.Init(gameObject);
        }
        void Update()
        {
            machine.Run(Time.deltaTime);
        }
    }
}
