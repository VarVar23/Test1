using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SO", menuName = "Config/SO", order = 0)]
public class SO : ScriptableObject
{
    public Vector3[] Pos2 = new Vector3[12];
    public Quaternion[] Rot2 = new Quaternion[12];
    public Rigidbody[] Bones;
    public Vector3[] Pos1 = new Vector3[12];
    public Quaternion[] Rot1 = new Quaternion[12];

}
