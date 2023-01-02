using UnityEngine;
using System;
public class StateMachine : MonoBehaviour
{
    public BaseState currentState;

    public event Action StateChange;
    
    void Start()
    {
        if (currentState == null)
        {
            currentState=GetDefaultState();
        }
            
    }
    void Update()
    {
        if(currentState != null)
            currentState.StateUpdate();
            
    }
    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.StateUpdatePhysics();
    }

    public virtual BaseState GetDefaultState()
    {
        return null;
    }
    public void ChangeState(BaseState state)
    {
        currentState.StateEnd();
        currentState = state;
        currentState.StateEnter();
        StateChange?.Invoke();
    }
}
