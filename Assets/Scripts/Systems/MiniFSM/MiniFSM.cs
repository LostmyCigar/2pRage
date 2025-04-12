using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    public abstract class MiniFSM
    {
        public GameObject Target { get; set; }
        protected State currentState;

        protected State[] AllStates { get; set; }

        public virtual void Init(GameObject target)
        {
            Target = target;
            if (currentState is null && AllStates.Length > 0)
            {
                currentState = AllStates[0];
            }

            foreach (var state in AllStates)
            {
                state.machine = this;
                state.target = target;
                state?.Init();
            }
        }

        public State Run(float deltaTime)
        {
            return currentState?.Run(deltaTime);
        }

        public State ChangeState(State newState)
        {
            currentState.End(); 
            currentState = newState;
            currentState.Start();

            return currentState;
        }
    }

    public abstract class State
    {
        public MiniFSM machine;
        public GameObject target;

        public virtual void Init() { }

        public virtual void Start() { }

        public virtual State Run(float deltaTime)
        {
            return this;
        }

        public virtual void End() { }
    }
}
