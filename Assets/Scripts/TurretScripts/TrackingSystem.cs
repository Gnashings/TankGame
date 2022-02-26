using UnityEngine;
using System.Collections;
 
public class TrackingSystem : MonoBehaviour {
    [Tooltip("How fast do you want enemy to track onto you")]
    public float spinSpeed = 3.0f;
 
    [Tooltip("What is it tracking")]
    public GameObject target;
    
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;
 
    // Update is called once per frame
    void Update () {
        if(target){
            if(m_lastKnownPosition != target.transform.position){
                m_lastKnownPosition = target.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
            }
 
            if(transform.rotation != m_lookAtRotation){
                transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, spinSpeed * Time.deltaTime);
            }
        }
    }
 
    bool SetTarget(GameObject targetPoint)
    {
        if(target)
            return false;

        target = targetPoint;

        return true;
    }
}