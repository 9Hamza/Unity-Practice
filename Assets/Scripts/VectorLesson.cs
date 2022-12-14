using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLesson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current position is: " + this.transform.position);
        Debug.Log("Current rotation is: " + this.transform.rotation);
        Debug.Log("Current scale is: " + this.transform.localScale);
        #region shorthands
        Debug.Log("Vector3.right shorthand for horizontal on the X axis" + Vector3.right);
        Debug.Log("Vector3.left shorthand for horizontal on the X axis" + Vector3.left);
        Debug.Log("Vector3.up shorthand for UP on the Y axis" + Vector3.up);
        Debug.Log("Vector3.own shorthand for DOWN on the Y axis" + Vector3.down);
        Debug.Log("Vector3.forward shorthand for forward on the Z axis" + Vector3.forward);
        Debug.Log("Vector3.back shorthand for backward on the Z axis" + Vector3.back);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime; // moves forward
        transform.Rotate(0, 0, 5.0f * Time.deltaTime);
    }
}
