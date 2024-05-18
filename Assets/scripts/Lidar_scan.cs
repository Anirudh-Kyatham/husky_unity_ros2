using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;  // Ensure you have the correct namespace for PointCloud2Msg
using System;

public class LidarScanner : MonoBehaviour
{
    public ROSConnection ros;
    public string topicName = "/scan";  // Change to your topic
    public float maxRange = 50.0f; // max range of lidar
    public int raysPerScan = 720; // number of rays per scan
    public float updateFrequency = 10.0f; // in Hz

    private float timeElapsed = 0;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PointCloud2Msg>(topicName);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 1f / updateFrequency)
        {
            timeElapsed = 0;
            SendLidarData();
        }
    }

    private void SendLidarData()
    {
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < raysPerScan; i++)
        {
            float angle = i * Mathf.PI * 2 / raysPerScan;
            Vector3 direction = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, maxRange))
            {
                points.Add(hit.point);
            }
            else
            {
                // If no hit, send max range point
                points.Add(transform.position + direction * maxRange);
            }
        }

        PointCloud2Msg message = CreatePointCloud2Message(points);
        ros.Publish(topicName, message);
    }

    private PointCloud2Msg CreatePointCloud2Message(List<Vector3> points)
    {
        var pointStep = 12; // 3 float32s for x, y, z
        var data = new List<byte>(points.Count * pointStep);

        foreach (var point in points)
        {
            data.AddRange(BitConverter.GetBytes(point.x));
            data.AddRange(BitConverter.GetBytes(point.y));
            data.AddRange(BitConverter.GetBytes(point.z));
        }

        var message = new PointCloud2Msg
        {
            header = new RosMessageTypes.Std.HeaderMsg
            {
                stamp = new RosMessageTypes.BuiltinInterfaces.TimeMsg { sec = (int)Time.timeSinceLevelLoad, nanosec = 0 },
                frame_id = "lidar_frame"
            },
            height = 1,
            width = (uint)points.Count,
            fields = new RosMessageTypes.Sensor.PointFieldMsg[]
            {
                new RosMessageTypes.Sensor.PointFieldMsg { name = "x", offset = 0, datatype = 7, count = 1 },
                new RosMessageTypes.Sensor.PointFieldMsg { name = "y", offset = 4, datatype = 7, count = 1 },
                new RosMessageTypes.Sensor.PointFieldMsg { name = "z", offset = 8, datatype = 7, count = 1 }
            },
            is_bigendian = false,
            point_step = (uint)pointStep,
            row_step = (uint)(points.Count * pointStep),
            data = data.ToArray(),
            is_dense = true  // No invalid points
        };

        return message;
    }
}

