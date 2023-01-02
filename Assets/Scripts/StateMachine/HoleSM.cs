using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSM : StateMachine
{
    [HideInInspector] public Level1 level1;
    [HideInInspector] public Level2 level2;
    [HideInInspector] public Level3 level3;
    private void Awake()
    {
        level1 = new Level1(this);
        level2 = new Level2(this);
        level3 = new Level3(this);
    }
    public override BaseState GetDefaultState()
    {
        return level1;
    }
    public BaseState IterateThroughStates(BaseState currentState)
    {
        switch (currentState)
        {
            case Level1: return level2;
            case Level2: return level3;
            case Level3: return level1;
                
           

        }
        return null;
    }

}
