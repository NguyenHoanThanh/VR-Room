using UnityEngine;

/// <summary>
/// Toggles particle system
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ToggleParticle : MonoBehaviour
{
    private ParticleSystem currentParticleSystem = null;
    private MonoBehaviour currentOwner = null;
    private Collider currentCollier = null;

    private bool _isPlay = false;
    private void Awake()
    {
        currentParticleSystem = GetComponent<ParticleSystem>();
        TryGetComponent(out currentCollier);
    }

    public void Play()
    {
        currentParticleSystem.Play();
        if (currentCollier != null)
        {
            currentCollier.enabled = true;
        }
    }

    public void Stop()
    {
        currentParticleSystem.Stop();
        if (currentCollier != null)
        {
            currentCollier.enabled = false;
        }
    }

    public void Toggle()
    {
        _isPlay = !_isPlay;
        if (_isPlay)
        {
            currentParticleSystem.Play();
            if (currentCollier != null)
            {
                currentCollier.enabled = true;
            }
        }
        else 
        {
            currentParticleSystem.Stop();
            if (currentCollier != null)
            {
                currentCollier.enabled = false;
            }                                   
        }
    }

    public void PlayWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == null)
        {
            currentOwner = this;
            Play();
        }
    }

    public void StopWithExclusivity(MonoBehaviour owner)
    {
        if(currentOwner == this)
        {
            currentOwner = null;
            Stop();
        }
    }

    private void OnValidate()
    {
        if(currentParticleSystem)
        {
            ParticleSystem.MainModule main = currentParticleSystem.main;
            main.playOnAwake = false;
        }
    }
}
