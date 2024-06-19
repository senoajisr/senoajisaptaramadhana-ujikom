using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public CharacterController controller;

    public float Speed = 20f;
    public float Lifetime = 3f;
    public int Hunger = 25;

    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    void Update()
    {
        controller.Move(Vector3.forward * Speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Animal otherAnimal = other.gameObject.GetComponent<Animal>();
        otherAnimal.Hunger -= Hunger;
        Destroy(gameObject);
    }
}
