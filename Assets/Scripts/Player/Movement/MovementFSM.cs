using System.Collections;
using System.Collections.Generic;
using Leo;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Leo{


    public class MovementFSM : MiniFSM
    {
        private State jumpState = new JumpState();
        private State walkState = new WalkState();
        private State idleState = new IdleState();

        public override void Init(GameObject target)
        {
            AllStates = new State[] { jumpState, walkState, idleState };
            currentState = idleState;
            Debug.Log(currentState.ToString());
            base.Init(target);
        }
    
    }

    public abstract class GameState : State
    {
        Player player;
        PlayerInput playerInput;

        public override void Init(){
            player = target.GetComponent<Player>();
            playerInput = target.GetComponent<PlayerInput>();
        }

    }


    public class JumpState : GameState
    {
        public override State Run(float deltaTime)
        {
            return this;
        }

        public override void Start()
        {
            Debug.Log("JumpState Start");
        }

        public override void End()
        {
            Debug.Log("JumpState End");
        }
    }

    public class WalkState : GameState
    {
        public override State Run(float deltaTime)
        {
            return this;
        }

        public override void Start()
        {
            Debug.Log("WalkState Start");
        }

        public override void End()
        {
            Debug.Log("WalkState End");
        }
    }

    public class IdleState : GameState
    {
        public override State Run(float deltaTime)
        {
            return this;
        }

        public override void Start()
        {
            Debug.Log("IdleState Start");
        }

        public override void End()
        {
            Debug.Log("IdleState End");
        }
    }

}