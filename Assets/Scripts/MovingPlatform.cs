using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 moveDistance;
    [SerializeField] float speed = 2f;
    Vector2 startPos, EndPos;
    bool towardsEndPos = true;
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    Transform _transform;
    Vector3 lastPos;
    private void Start()
    {
        _transform = transform;
        startPos = _transform.position;
        lastPos = _transform.position;
        EndPos = startPos + moveDistance;
    }
    private void Update()
    {
            float step = speed * Time.deltaTime;
            if (towardsEndPos)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, EndPos, step);
                if (Vector3.Distance(_transform.position, EndPos) < 0.1f)
                {
                    towardsEndPos = false;
                }
            }
            else
            {
                _transform.position = Vector3.MoveTowards(_transform.position, startPos, step);
                if (Vector3.Distance(_transform.position, startPos) < 0.1f)
                {
                    towardsEndPos = true;
                }
            }
            if (rigidbodies.Count > 0)
            {
                for (int i = 0; i < rigidbodies.Count; i++)
                {
                    if (rigidbodies[i] != null)
                    {
                        Rigidbody rb = rigidbodies[i];
                        Vector2 vel = new Vector2((_transform.position.x - lastPos.x) + ((rb.velocity.x * Time.deltaTime) / 2),
                                                  (_transform.position.y - lastPos.y) + ((rb.velocity.y * Time.deltaTime) / 2));
                        rb.transform.Translate(vel, transform);
                    }
                }
            }
            lastPos = _transform.position;       
    }
    #region collision functions
    private void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Add(rb);
        }
    }
    private void OnCollisionStay(Collision col)
    {
        Rigidbody rb = col.collider.GetComponent<Rigidbody>();
        if (rb != null && !rigidbodies.Contains(rb))
        {
            Add(rb);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        Rigidbody rb = col.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Remove(rb);
        }
    }
    void Add(Rigidbody rb)
    {
        if (!rigidbodies.Contains(rb))
            rigidbodies.Add(rb);
    }
    void Remove(Rigidbody rb)
    {
        if (rigidbodies.Contains(rb))
            rigidbodies.Remove(rb);
    }
    #endregion
}
