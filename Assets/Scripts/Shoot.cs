using UnityEngine;
using System;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float power;
    [SerializeField] private Vector2 minPower;
    [SerializeField] private Vector2 maxPower;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineScript line;

    private Camera mainCamera;
    private Vector2 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    public static event Action ShootAction;

    private void Start()
    {
        mainCamera = Camera.main;
        HoleScript.BallInTheHole += () => { this.gameObject.GetComponent<SpriteRenderer>().enabled = false; this.enabled = false; };
    }
    private void Update()
    {
        CheckIfBallIsMoving();


        if (Input.GetMouseButtonDown(0) && CheckIfBallIsMoving() == false)
        {
            startPoint=mainCamera.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }
        if(Input.GetMouseButton(0) && CheckIfBallIsMoving() == false)
        {
            Vector3 currentPoint= mainCamera.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            line.RenderLine(startPoint, currentPoint);

        }    
        if(Input.GetMouseButtonUp(0) && CheckIfBallIsMoving() == false)
        {
            endPoint=mainCamera.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            line.EndLine();
            ShootAction?.Invoke();

        }
        
    }
    private bool CheckIfBallIsMoving()
    {
        if (rb.velocity.x > -1 && rb.velocity.x < 1 && rb.velocity.y > -1 && rb.velocity.y < 1)
            return false;
        else
            return true;
    }
}
