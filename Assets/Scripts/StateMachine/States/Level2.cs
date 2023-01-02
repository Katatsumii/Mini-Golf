using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : BaseState
{
    
    public Level2(HoleSM stateMachine) : base("Hole 2", stateMachine) { }
    public override void StateEnter()
    {
        base.StateEnter();
        GameObject.Find("GameManager").GetComponent<LevelManager>().SetActiveLevel(2);
    }
}
