using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float     _speed = .1f;

    private ParticleSystem            _particle;
    private ParticleSystem.Particle[] _particles;
    private int                       _count;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();

        _particles = new ParticleSystem.Particle[_particle.main.maxParticles];
    }

    private void Update()
    {
        if (_target && _particle && _particle.isPlaying)
        {
            _count = _particle.GetParticles(_particles);
            for (var i = 0; i < _count; i++)
            {
                _particles[i].position = Vector3.MoveTowards(_particles[i].position, _target.position, _speed);
            }

            _particle.SetParticles(_particles, _count);
        }
    }
}