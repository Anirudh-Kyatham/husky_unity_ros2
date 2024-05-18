#include <memory>
#include <string>
#include <rclcpp/rclcpp.hpp>
#include <geometry_msgs/msg/pose.hpp>
#include <tf2_ros/transform_broadcaster.h>
#include <tf2/LinearMath/Quaternion.h>
#include <tf2_geometry_msgs/tf2_geometry_msgs.h>
#include <geometry_msgs/msg/pose_with_covariance_stamped.hpp>

class HuskyTransformBroadcaster : public rclcpp::Node
{
public:
    HuskyTransformBroadcaster() : Node("husky_tf_broadcaster")
    {
        tf_broadcaster_ = std::make_shared<tf2_ros::TransformBroadcaster>(this);
        pose_subscription_ = this->create_subscription<geometry_msgs::msg::Pose>(
            "/husky_pose", 10, std::bind(&HuskyTransformBroadcaster::pose_callback, this, std::placeholders::_1));
    }

private:
    void pose_callback(const geometry_msgs::msg::Pose::SharedPtr msg)
    {
        geometry_msgs::msg::TransformStamped odom_to_map_transform;
        odom_to_map_transform.header.stamp = this->get_clock()->now();
        odom_to_map_transform.header.frame_id = "map";  // This should be just "map" if your system uses "map" as the global frame
        odom_to_map_transform.child_frame_id = "base_link";  // This should be "odom" if your system uses "odom" for the local odometry frame

        // Apply translation directly as provided by Unity
        odom_to_map_transform.transform.translation.x = msg->position.x;
        odom_to_map_transform.transform.translation.y = msg->position.y;
        odom_to_map_transform.transform.translation.z = msg->position.z;

        // Convert Unity quaternion to tf2 quaternion for manipulation
        geometry_msgs::msg::Quaternion unity_quat = msg->orientation;
        tf2::Quaternion tf2_unity_quat;
        tf2::convert(unity_quat, tf2_unity_quat);

        // Corrective rotation to align Unity's Y-axis (up in Unity) to ROS's Z-axis (up in ROS)
        tf2::Quaternion corrective_rotation;
        corrective_rotation.setRPY(0, 0, M_PI_2);  // Adjusted based on your system's requirements

        // Combine the Unity quaternion with the corrective rotation
        tf2::Quaternion corrected_quat = corrective_rotation * tf2_unity_quat;
        corrected_quat.normalize();  // Normalize the quaternion to ensure it's a valid rotation

        // Convert the corrected quaternion back to a ROS message and assign it
        geometry_msgs::msg::Quaternion ros_quat;
        tf2::convert(corrected_quat, ros_quat);
        odom_to_map_transform.transform.rotation = ros_quat;

        // Send the transform
        tf_broadcaster_->sendTransform(odom_to_map_transform);
    }



    rclcpp::Subscription<geometry_msgs::msg::Pose>::SharedPtr pose_subscription_;
    std::shared_ptr<tf2_ros::TransformBroadcaster> tf_broadcaster_;
};

int main(int argc, char **argv)
{
    rclcpp::init(argc, argv);
    auto node = std::make_shared<HuskyTransformBroadcaster>();
    rclcpp::spin(node);
    rclcpp::shutdown();
    return 0;
}
