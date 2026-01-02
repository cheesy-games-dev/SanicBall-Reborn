using System.Collections;
using UnityEngine;

namespace Sanicball
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleSystemAutoDestroy : EntityBehaviour
    {
        private ParticleSystem ps;

        public void Start()
        {
            ps = GetComponent<ParticleSystem>();
        }

        public override void OnUpdate()
        {
            if (ps)
            {
                if (!ps.IsAlive())
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}