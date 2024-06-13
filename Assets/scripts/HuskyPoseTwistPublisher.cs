using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;
using RosMessageTypes.Nav;
using RosMessageTypes.Std;
using RosMessageTypes.BuiltinInterfaces; // Add this for time message types
using System;

public class HuskyPoseTwistPublisher : MonoBehaviour
{
    public ROSConnection ros;
    public string odometryTopicName = "/odom";
    private Rigidbody huskyRigidbody;
    public float publishFrequency = 0.1f; // 10 Hz
    private float timeElapsed;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<OdometryMsg>(odometryTopicName);
        huskyRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        timeElapsed += Time.fixedDeltaTime;
        Debug.Log("Time elapsed: " + timeElapsed); // Debug log for time elapsed

        if (timeElapsed >= publishFrequency)
        {
            Debug.Log("Publishing odometry data at " + Time.time);
            PublishOdometry();
            timeElapsed = 0;
        }
    }

    void PublishOdometry()
    {
        // Get the current time
        DateTimeOffset now = DateTimeOffset.UtcNow;
        int sec = (int)now.ToUnixTimeSeconds();
        uint nanosec = (uint)(now.ToUnixTimeMilliseconds() % 1000 * 1e6);

        // Header
        HeaderMsg header = new HeaderMsg
        {
            frame_id = "odom",
            stamp = new TimeMsg
            {
                sec = sec,
                nanosec = nanosec
            }
        };

        // Pose with Covariance
        PoseWithCovarianceMsg pose = new PoseWithCovarianceMsg
        {
            pose = new PoseMsg(
                new PointMsg(transform.position.z, -transform.position.x, transform.position.y),
                new QuaternionMsg(transform.rotation.z, transform.rotation.x, -transform.rotation.y, transform.rotation.w)
            ),
            covariance = new double[36] // Default zero covariance
        };

        // Twist with Covariance
        Vector3 linearVelocity = huskyRigidbody.velocity;
        Vector3 angularVelocity = huskyRigidbody.angularVelocity;

        TwistWithCovarianceMsg twist = new TwistWithCovarianceMsg
        {
            twist = new TwistMsg(
                new Vector3Msg(linearVelocity.x, linearVelocity.y, linearVelocity.z),
                new Vector3Msg(angularVelocity.x, angularVelocity.y, angularVelocity.z)
            ),
            covariance = new double[36] // Default zero covariance
        };

        // Odometry message
        OdometryMsg odometryMsg = new OdometryMsg
        {
            header = header,
            child_frame_id = "base_link",
            pose = pose,
            twist = twist
        };

        ros.Publish(odometryTopicName, odometryMsg);
    }
}

