using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshLevelData : MonoBehaviour
{
    NavMeshSurface navMeshSurface;

    private void Awake()
    {
        navMeshSurface=GetComponent<NavMeshSurface>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
    }
}
