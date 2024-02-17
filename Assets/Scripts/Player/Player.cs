using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    //Singelton Design Pattern : 
    public static Player Instance { get; private set; }

    private void Awake() {
        //Initial value assignment for the instance variable :
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }

        //Initial value assignment for player - related variables : 
        Score = 0;
        CurrentHealth = maxHealth;
    }

    //Variables for player - related : 
    [SerializeField] private float maxHealth;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumpCount;

    //Properties : 
    public float CurrentHealth { get; set; }
    public int Score { get; set; }

    //Getters & Setters : 
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float Speed { get { return speed; } set {  speed = value; } }
    public float JumpForce { get {  return jumpForce; } set {  jumpForce = value; } }
    public int MaxJumpCount { get {  return maxJumpCount; } set { maxJumpCount = value; } }

}
