using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleSystem Part;
    ParticleSystem.Particle[] arrPar;
    int arrCount = 0;
    public Transform target;
    public float Speed = 0.1f;

    private void Awake()
    {
        Part = GetComponent<ParticleSystem>();
        arrPar = new ParticleSystem.Particle[Part.main.maxParticles];
    }

    private void Update()
    {
        if (target && Part && Part.isPlaying)
        {
            arrCount = Part.GetParticles(arrPar);
            Vector3 pos = target.position;
            for (var i = 0; i < arrCount; i++)
            {
                arrPar[i].position = Vector3.MoveTowards(arrPar[i].position, pos, Speed);
            }
            Part.SetParticles(arrPar, arrCount);
        }
    }
}
