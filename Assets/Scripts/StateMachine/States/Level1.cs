using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : BaseState
{
    public Level1(HoleSM stateMachine) : base("Hole 1", stateMachine) { }



    public override void StateEnter()
    {
        base.StateEnter();
        GameObject.Find("GameManager").GetComponent<LevelManager>().SetActiveLevel(1);
    }
    public override void StateEnd()
    {
        base.StateEnd();
    }
}
