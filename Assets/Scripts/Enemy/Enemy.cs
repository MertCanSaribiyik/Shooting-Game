using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private Color color;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private int score;
    [SerializeField] private float emergenceTime;
    [SerializeField] private GameObject deathEffectPrefab;

    //Getters and setters : 
    public float Speed { get { return speed; } set { speed = value; } }
    public float Damage { get { return damage; } set {  damage = value; } }
    public float EmergenceTime { get {  return emergenceTime; } private set {  emergenceTime = value; } }

    private void Awake() {
        GetComponent<MeshRenderer>().material.color = color;
    }

    //Enemy movement : 
    private void Update() {
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
    }

    //Enemy and bullet destroyed : 
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            Player.Instance.Score += score;
            DestroyEnemy();
            Destroy(collision.gameObject);
        }
    }

    private void DestroyEnemy() {
        GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
}
