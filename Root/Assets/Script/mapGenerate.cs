using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class mapGenerate : MonoBehaviour
{
    [SerializeField] GameObject[] Bridge;
    [SerializeField] public GameObject[] Room;
    [SerializeField] Vector3[] Pos_Bridge;
    [SerializeField] Vector3[] Rot_Bridge;
    [SerializeField] public Vector3[] Pos_Room;
    [SerializeField] Vector3[] Rot_Room;


    const int X_Size = 20;
    const int Y_Size = 20;

    Vector3[,] coordinate = new Vector3[X_Size, Y_Size];
    GameObject[,] spawned = new GameObject[X_Size, Y_Size];

    [SerializeField] GameObject RoomPrefab;
    [SerializeField] GameObject BridgePrefab;
    [SerializeField] Transform Parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegenerateRegisteredMap()
    {
        int i = 0;
        foreach (Vector3 item in Pos_Bridge)
        {
            GameObject spawn = Instantiate(BridgePrefab, Pos_Bridge[i], Quaternion.Euler(Rot_Bridge[i]), Parent);
            i++;
        }

        i = 0;

        foreach (Vector3 item in Pos_Room)
        {
            GameObject spawn = Instantiate(RoomPrefab, Pos_Room[i], Quaternion.Euler(Rot_Room[i]), Parent);
            i++;
        }

    }

    public void GenerateMap()
    {
        for (int i = 0; i < coordinate.GetLength(0); i++)
        {
            for (int j = 0; j < coordinate.GetLength(1); j++)
            {
                coordinate[i, j] = new Vector3(2 * i, 0, 2 * j);
            }
        }

        for (int i = 0; i < coordinate.GetLength(0); i++)
        {
            for (int j = 0; j < coordinate.GetLength(1); j++)
            {
                int v = Random.Range(0, 10);
                if (v < 2)
                {
                    GameObject spawn = Instantiate(BridgePrefab, new Vector3(0,0,0),Quaternion.Euler(-90,v%2==0?90:0,0), Parent);
                    spawned[i, j] = spawn;
                    spawned[i, j].transform.position = coordinate[i, j];
                }
                else if(v > 5)
                {
                    GameObject spawn = Instantiate(RoomPrefab, Parent);
                    spawned[i, j] = spawn;
                    spawned[i, j].transform.position = coordinate[i, j];
                }
            }
        }
    }

    public void ClearMap()
    {
        foreach (Transform child in Parent)
        {
            DestroyImmediate(child.gameObject);
        }
        spawned = new GameObject[X_Size, Y_Size];
    }

    public void LocationAllocation()
    {
        Pos_Bridge = new Vector3[Bridge.Length];
        Rot_Bridge = new Vector3[Bridge.Length];

        Pos_Room = new Vector3[Room.Length];
        Rot_Room = new Vector3[Room.Length];

        int i = 0;
        foreach (GameObject item in Bridge)
        {
            Pos_Bridge[i] = item.transform.position;
            Rot_Bridge[i] = item.transform.rotation.eulerAngles;
            i++;
        }

        i = 0;

        foreach (GameObject item in Room)
        {
            Pos_Room[i] = item.transform.position;
            Rot_Room[i] = item.transform.rotation.eulerAngles;
            i++;
        }
    }
}

[CustomEditor(typeof(mapGenerate))]
public class mapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        mapGenerate mapGen = (mapGenerate)target;

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }

        if (GUILayout.Button("Clear"))
        {
            mapGen.ClearMap();
        }

        if (GUILayout.Button("AllocateLoc"))
        {
            mapGen.LocationAllocation();
        }

        if (GUILayout.Button("Regenerate Registered Map"))
        {
            mapGen.RegenerateRegisteredMap();
        }
    }
}