//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Turtlebot3Example
{
    [Serializable]
    public class Turtlebot3Feedback : Message
    {
        public const string k_RosMessageName = "turtlebot3_example/Turtlebot3";
        public override string RosMessageName => k_RosMessageName;

        //  Define a feedback message
        public string state;

        public Turtlebot3Feedback()
        {
            this.state = "";
        }

        public Turtlebot3Feedback(string state)
        {
            this.state = state;
        }

        public static Turtlebot3Feedback Deserialize(MessageDeserializer deserializer) => new Turtlebot3Feedback(deserializer);

        private Turtlebot3Feedback(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.state);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.state);
        }

        public override string ToString()
        {
            return "Turtlebot3Feedback: " +
            "\nstate: " + state.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Feedback);
        }
    }
}