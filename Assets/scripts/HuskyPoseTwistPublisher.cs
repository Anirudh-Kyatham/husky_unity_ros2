using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry; // Ensure correct namespace based on your ROS message types

public class HuskyPoseTwistPublisher : MonoBehaviour
{
    public ROSConnection ros;
    public string poseTopicName = "/husky_pose";
    public string twistTopicName = "/husky_twist";
    private Rigidbody huskyRigidbody;
    public float publishFrequency = 1.2f;
    private float timeElapsed;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PoseMsg>(poseTopicName);
        ros.RegisterPublisher<TwistMsg>(twistTopicName);
        huskyRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= publishFrequency)
        {
            PublishPose();
            PublishTwist();
            timeElapsed = 0;
        }
    }

    void PublishPose()
    {
        PoseMsg poseMsg = new PoseMsg(
            new PointMsg(transform.position.z, -transform.position.x, transform.position.y),
            new QuaternionMsg(transform.rotation.z, transform.rotation.x, -transform.rotation.y, transform.rotation.w)
        );

        ros.Publish(poseTopicName, poseMsg);
    }

    void PublishTwist()
    {
        Vector3 linearVelocity = huskyRigidbody.velocity;
        Vector3 angularVelocity = huskyRigidbody.angularVelocity;

        TwistMsg twistMsg = new TwistMsg(
            new Vector3Msg(linearVelocity.x, linearVelocity.y, linearVelocity.z),
            new Vector3Msg(angularVelocity.x, angularVelocity.y, angularVelocity.z)
        );

        ros.Publish(twistTopicName, twistMsg);
    }
}

