using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConfine : MonoBehaviour
{

    public CinemachineConfiner CinemachineCam;
    public PolygonCollider2D[] poly;

    //checks if the confiner is inside of player
    //if it is, turn off collider
    //if not, turn on collider



    public void Test(int confiner)
    {
        CinemachineCam.m_BoundingShape2D = poly[confiner];
    }
}
