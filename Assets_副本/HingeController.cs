using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))] // 确保此脚本附加到的GameObject有HingeJoint2D组件
public class HingeController : MonoBehaviour
{
    private HingeJoint2D hingeJoint2D; // 用于存储HingeJoint2D组件的引用

    void Start()
    {
        // 获取并存储HingeJoint2D组件的引用
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        // 检查玩家是否按下并保持空格键
        if (Input.GetKey(KeyCode.Space))
        {
            SetMotorVelocity(300); // 如果按下空格键，设置motor.targetVelocity为100
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SetMotorVelocity(-300); // 当释放空格键，设置motor.targetVelocity为-100
        }
    }

    void SetMotorVelocity(float velocity)
    {
        // 获取当前的motor设置
        JointMotor2D motor = hingeJoint2D.motor;
        motor.motorSpeed = velocity; // 更新motorSpeed为指定的速度
        hingeJoint2D.motor = motor; // 将更新后的motor赋值回HingeJoint2D组件
        hingeJoint2D.useMotor = true; // 确保motor功能被启用
    }
}