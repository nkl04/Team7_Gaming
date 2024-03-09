using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelEntrance : MonoBehaviour
{

    public event EventHandler OnTakePlayerToNextLevel;
    public event EventHandler OnOutOfTheMap;
    public bool CanMove {get{return canMove;} set{canMove = value;}}
    [SerializeField] private float speed;
    [SerializeField] private Transform newLevelPosition;

    private bool canMove;

    private HashSet<GameObject> playersOnEntrance = new HashSet<GameObject>();

    private void LiftEntrance()
    {
        transform.position = Vector2.MoveTowards(transform.position,newLevelPosition.position,speed * Time.deltaTime);
    }

    private void Update() {
        if (playersOnEntrance.Count == 2 && canMove)
        {
            OnTakePlayerToNextLevel?.Invoke(this,EventArgs.Empty);
            LiftEntrance();
            if (transform.position == newLevelPosition.position)
            {
                OnOutOfTheMap?.Invoke(this,EventArgs.Empty);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            playersOnEntrance.Add(other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (playersOnEntrance.Contains(other.gameObject))
            {
                playersOnEntrance.Remove(other.gameObject);
            }
        }
    }

    public void Stable()
    {

    }
}