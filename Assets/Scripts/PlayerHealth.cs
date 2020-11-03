using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 20;
    Text scoreDisplay;
    private void Start()
    {
        scoreDisplay = FindObjectOfType<HealthDisplay>().GetComponent<Text>();
        scoreDisplay.text = health.ToString();
            }
    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(other.gameObject.GetComponent<EnemyMovement>().GetDamage());
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        scoreDisplay.text = health.ToString();
    }
}
