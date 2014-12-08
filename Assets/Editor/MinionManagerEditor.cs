using System;
using UnityEditor;
using UnityEngine;
using System.Collections;

[System.Serializable]
[CustomEditor(typeof (MinionManager))]
public class MinionManagerEditor : Editor
{
    [SerializeField]
    private Vector3 spawnPos = new Vector3(0, 0, 0);

    [SerializeField]
    public GameObject minionPrefab;

    void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Separator();
        EditorGUILayout.LabelField("Utility functions");
        minionPrefab = EditorGUILayout.ObjectField("Minion", minionPrefab, typeof(GameObject), true) as GameObject;
        spawnPos = EditorGUILayout.Vector3Field("SpawnPoint", spawnPos);
        if (GUILayout.Button("Spawn Enemy")) {
            _makeEnemy(minionPrefab, spawnPos);
        }

        // Set dirty if needed

        EditorUtility.SetDirty(target);
        serializedObject.ApplyModifiedProperties();
    }

    private void _makeEnemy(GameObject prefab, Vector3 spawnPosition)
    {
            MinionManager manager = (MinionManager) target;

            manager.SpawnMinion(prefab, spawnPos);
    }
}