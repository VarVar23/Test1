using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "Config/SO", order = 0)]
public class BonesSO : ScriptableObject
{
    public Vector3[] BonesPosition = new Vector3[11];
    public Quaternion[] BonesRotation = new Quaternion[11];
    public Rigidbody[] Bones;
}
