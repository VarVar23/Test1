using System.Collections.Generic;
using UnityEngine;

public class BounPositionGetter : MonoBehaviour
{
    public Vector3[] BonePositions;
    public Quaternion[] BoneRotations;
    [SerializeField] private SO So;

#if UNITY_EDITOR

    private void OnValidate()
    {
        var gameObjects = GetComponentsInChildren<Rigidbody>();
        So.Bones = gameObjects;
        BonePositions = new Vector3[gameObjects.Length];
        BoneRotations = new Quaternion[gameObjects.Length];

     
        for (int i = 0; i < gameObjects.Length; i++)
        {
            BonePositions[i] = gameObjects[i].transform.localPosition;
            BoneRotations[i] = gameObjects[i].transform.localRotation;
        }

        So.Pos2 = BonePositions;
        So.Rot2 = BoneRotations;
    }



#endif
}
