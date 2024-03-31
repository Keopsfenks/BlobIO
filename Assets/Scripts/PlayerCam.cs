using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float offSet = 10f;
    [SerializeField] private float panAngle = 60f;
    [SerializeField] private Transform slimeTrans;
    [SerializeField] private Transform myTrans;

    private void Update()
    {
        Vector3 offSetVect = Vector3.back * offSet;

        Quaternion angleAxis = Quaternion.AngleAxis(panAngle, Vector3.right);

        Vector3 rotatedVect = angleAxis * offSetVect;

        myTrans.position = slimeTrans.position + rotatedVect;
        myTrans.LookAt(slimeTrans);
    }
}
