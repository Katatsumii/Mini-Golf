using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : BaseState
{
    public Level3(HoleSM stateMachine) : base("Hole 3", stateMachine) { }
    public override void StateEnter()
    {
        base.StateEnter();
        GameObject.Find("GameManager").GetComponent<LevelManager>().SetActiveLevel(3);
    }
}
