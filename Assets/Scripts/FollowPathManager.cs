using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathManager : MonoBehaviour
{
    public static FollowPathManager instance = null;
    public FollowPath[] Players;
    private Vector3[] pos;
    private Vector3[] rot;
    private void Awake()
    {
        instance = this;
        pos = new Vector3[Players.Length];
        rot = new Vector3[Players.Length];
        savePositions();
    }
    void savePositions()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            pos[i] =Players[i].transform.position;
            rot[i] = Players[i].transform.eulerAngles;
        }
    }
    public void ResetAll()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].transform.localScale = Vector3.one;
            Players[i].transform.position= pos[i];
            Players[i].transform.eulerAngles = rot[i];
        }
    }
    public void makePlayersFollowPath(List<Vector3> list)
    {
        float total = 0;
        float factor = 0.3f;

        for(int i = 0; i < Players.Length; i++)
        {
            Players[i].moveTowardsPath(list, total);
            total = total + factor;
        }

    }

}
