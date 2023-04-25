using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public ParticleSystem system;
    //variables
    public int number_of_col;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifeTime;
    public float fireRate;
    private float angle;
    public float size;
    public Material material;
    public float spin;
    private float time;

    private void Awake()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time*spin);
    }
    void Shoot()
    {
        angle = 360f / number_of_col;

        for(int i=0;i<number_of_col;i++)
        {
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle*i, 90, 0); 
            go.transform.parent=this.transform;
            go.transform.position=this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 10000;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);

            var form = system.shape;
            form.enabled = true;
            form.shapeType = ParticleSystemShapeType.Sprite;
            form.sprite = null;
        }
        

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, fireRate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system=child.GetComponent<ParticleSystem>();
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifeTime;
            system.Emit(emitParams, 10);
        }
    }
}
