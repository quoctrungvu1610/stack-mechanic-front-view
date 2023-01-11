using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour, IBreakable
{
    Rigidbody wallRb;
    GameObject wall;
    Vector3 currentPosition;
    Vector3 firstPosition;

    private void Start() 
    {
        wall = this.gameObject;
        firstPosition = wall.transform.position;
        wallRb = wall.GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        currentPosition = wall.transform.position;
        CheckPosition();
    }

    private void MoveAwayFromPlayer(Vector3 moveDirection)
    {
        wallRb.AddForce(moveDirection);
    }

    private void UseWallGravity()
    {
        wallRb.useGravity = true;
    }
    
    private void CheckPosition()
    {
        if(currentPosition != firstPosition){
            wall.GetComponent<Renderer>().material.color = Color.red;
            UseWallGravity();
            Destroy(wall,1f);
        }
    }

    public void BreakBehaviors(Vector3 awayFromPlayerDirection)
    {
        MoveAwayFromPlayer(awayFromPlayerDirection);
    }
}
