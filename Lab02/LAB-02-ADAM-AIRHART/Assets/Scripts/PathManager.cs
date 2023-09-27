using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public List<waypoints> path;

    public GameObject prefab;
    int CurrentPointIndex = 0;
    public List<GameObject> prefabPoints;

    public List<waypoints> Getpath()
    {
        if (path == null)
            path = new List<waypoints>();

        return path;
    }
    // Update is called once per frame
    public void CreatAddPoint()
    {
        waypoints go = new waypoints();
        path.Add(go);
    }

    public waypoints GetNextTarget()
    {
        int nextPointIndex = (CurrentPointIndex + 1) % (path.Count);
        CurrentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    private void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach (waypoints p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }
    private void Update()
    {
        for (int i = 0; i < path.Count; i++)
        {
            waypoints p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }
}