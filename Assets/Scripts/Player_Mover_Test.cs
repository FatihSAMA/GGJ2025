using UnityEngine;

public class Player_Mover_Test : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer(){
                float xValue = (Input.GetAxis("Horizontal") * Time.deltaTime) * moveSpeed;
        float yValue = 0f;
        float zValue = (Input.GetAxis("Vertical") * Time.deltaTime) * moveSpeed;
        
        transform.Translate(x:xValue, 
                            y:yValue, 
                            z:zValue);
    }
}