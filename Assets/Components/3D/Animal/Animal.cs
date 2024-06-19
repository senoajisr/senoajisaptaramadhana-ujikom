using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Animal : MonoBehaviour
{
    public CharacterController controller;

    public float Lifetime = 60f;
    public int AddScore;
    public int Speed;
    public int hunger;
    public int Hunger
    {
        get { return hunger; }
        set {
            hunger = value;

            if (hunger <= 0)
            {
                GameManager.Instance.GameScore += AddScore;
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    void Update()
    {
        controller.Move(Vector3.back * Speed * Time.deltaTime);
    }
}
