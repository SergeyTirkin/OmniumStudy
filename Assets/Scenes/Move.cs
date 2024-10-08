using UnityEngine;
public class Move : MonoBehaviour
{

    public Transform[] MoveObjects = new Transform[3];
    public float LimitTransformX = 5;
    public float LimitTransform_X = -5;
    public float LimitTransformZ = 5;
    public float LimitTransform_Z = -5;
    public float Speed = 0;
    void Update()
    {
        float StateHorizontal = Input.GetAxis("Horizontal");
        float StateVertical = Input.GetAxis("Vertical");
        
        for (int i = 0; i < MoveObjects.Length; i++)
        {
            if(MoveObjects[i] == null) continue;
            MoveObjects[i].Translate(new Vector3(1, 0, 0) * Speed * Time.deltaTime * StateHorizontal);
            MoveObjects[i].Translate(new Vector3(0, 0, 1) * Speed * Time.deltaTime * StateVertical);           
            
            if(MoveObjects[i].transform.position.x > LimitTransformX)
            {
                MoveObjects[i].transform.position = new Vector3(LimitTransformX, MoveObjects[i].transform.position.y, MoveObjects[i].transform.position.z);                
            }            
            else if(MoveObjects[i].transform.position.x < LimitTransform_X)
            {
                MoveObjects[i].transform.position = new Vector3(LimitTransform_X, MoveObjects[i].transform.position.y, MoveObjects[i].transform.position.z);                
            }

            if(MoveObjects[i].transform.position.z > LimitTransformZ)
            {
                MoveObjects[i].transform.position = new Vector3(MoveObjects[i].transform.position.x, MoveObjects[i].transform.position.y, LimitTransformZ);                
            }
            else if(MoveObjects[i].transform.position.z < LimitTransform_Z)
            {
                MoveObjects[i].transform.position = new Vector3(MoveObjects[i].transform.position.x, MoveObjects[i].transform.position.y, LimitTransform_Z);                
            }

            Debug.Log(MoveObjects[i].name + " X: " + MoveObjects[i].transform.position.x + ", Y: " + MoveObjects[i].transform.position.y +
                       ", Z: " + MoveObjects[i].transform.position.z);
        }
    }
}
