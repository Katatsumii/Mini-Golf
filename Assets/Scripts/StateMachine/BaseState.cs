using UnityEngine;

public class BaseState
{
    public string nameOfState;
    protected StateMachine stateMachine;
    private Vector3 ballStartPostion = new Vector3(-5.344f, -3.094f, 0f);
    public BaseState(string name,StateMachine stateMachine) 
    { 
        this.nameOfState = name;
        this.stateMachine = stateMachine;
    }
    public virtual void StateEnter() 
    {
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<Shoot>().enabled = true;
        ball.GetComponent<SpriteRenderer>().enabled = true;
        Rigidbody2D ballrb = ball.GetComponent<Rigidbody2D>();
        ballrb.velocity = Vector3.zero;
        ballrb.angularVelocity = 0f;
        ball.transform.position = ballStartPostion;
        GameObject.Find("Hole").GetComponent<SpriteRenderer>().enabled = true;
    }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
    public virtual void StateUpdatePhysics() { }

    public string ReturnNameOfState()
    {
        return nameOfState;
    }
    
}
