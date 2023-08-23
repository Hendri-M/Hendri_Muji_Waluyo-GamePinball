using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    public HingeJoint hinge;
    [SerializeField] float targetPressed;
    [SerializeField] float targetReleased;
     // Start is called before the first frame update
     void Start()
    {
          // Set HingeJoint pada saat game dimulai
          hinge = GetComponent<HingeJoint>();
     }

    // Update is called once per frame
    void Update()
    {
        // Read Input
        // Move Paddle

        ReadInput();
        MovePaddle();
        
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring;
        // Mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targetPressed;
        }
        else 
        {
            jointSpring.targetPosition = targetReleased;
        }

        // Mengubah spring pada Hinge Joint denga value yang sudah diubah

        hinge.spring = jointSpring;
    }

    private void MovePaddle()
    {

    }
}
