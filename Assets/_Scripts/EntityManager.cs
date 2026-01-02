using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;
    public static List<EntityBehaviour> entities = new();
    private void Start() {
        if (instance) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        entities.ToList().ForEach(x => x.OnUpdate());
    }
    private void LateUpdate() {
        entities.ToList().ForEach(x => x.OnLateUpdate());
    }
    private void FixedUpdate() {
        entities.ToList().ForEach(x=>x.OnFixedUpdate());
    }

    [RuntimeInitializeOnLoadMethod]
    public static void OnApplicationStart() {
        new GameObject("EntityManager", typeof(EntityManager));
    }
}
