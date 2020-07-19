using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public float minimumDistanceToFollow = 0.1f;
    private float distance = 0;
    public Transform PlayerTransform = null;
    private Vector3 pos;
    public float speed = 10f;
    public void moveTowardsPath(List<Vector3> list,float time)
    {
        StartCoroutine(delayMoveTowardsPath(list, time));
    }
    IEnumerator delayMoveTowardsPath(List<Vector3> list,float time)
    {
        yield return new WaitForSeconds(time);
        for(int i = 0; i < list.Count; i++)
        {
         
            distance = Vector3.Distance(PlayerTransform.transform.position, list[i]);
            while (distance > minimumDistanceToFollow)
            {
               
                pos = Vector3.MoveTowards(PlayerTransform.transform.position, list[i], speed * Time.deltaTime);
                PlayerTransform.transform.LookAt(pos);
                PlayerTransform.transform.position = pos;
                distance = Vector3.Distance(PlayerTransform.transform.position, list[i]);
                yield return null;
                
            }
        }
        float scale_ = 1;
        float s = 1f;
        
        while (scale_ > 0)
        {
            scale_ = scale_ - Time.deltaTime * s;
            PlayerTransform.transform.localScale = Vector3.one * scale_;
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
