# Husky Robot Simulation: Integrating Unity and ROS2

This repository contains a Unity project that simulates a Husky robot, integrated with ROS2 for real-time control, data visualization, and sensor simulation. The Unity project includes scripts for robot control, pose and twist publishing, LiDAR data simulation, and more.



## Project Description

This project involves the development of a Husky robot simulation in Unity, integrated with ROS2 for real-time control, data visualization, and sensor simulation. The Unity scripts control the robot's movement, publish its state to ROS2, and simulate LiDAR data.

## Dependencies

### Unity
- Unity 2020.3 or later
- [ROS TCP Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector)
- [Unity Robotics Visualization](https://github.com/Unity-Technologies/Unity-Robotics-Hub/tree/main/robodemo/Assets/Scripts/Visualizations)
- [Unity Sensors](https://github.com/Unity-Technologies/Unity-Robotics-Hub/tree/main/robodemo/Assets/Scripts/Sensors)
- [UnitySensorsROS](https://github.com/Unity-Technologies/Unity-Robotics-Hub/tree/main/robodemo/Assets/Scripts/SensorsROS)

### ROS2
- ROS2 Foxy Fitzroy
- Husky description and control packages:
  ```bash
  sudo apt install ros-foxy-husky-description ros-foxy-husky-control

HuskyController.cs

This script controls the movement of the Husky robot using keyboard inputs.

    Movement Speed: The moveSpeed variable controls how fast the Husky moves forward or backward.
    Turning Speed: The turnSpeed variable controls how fast the Husky turns left or right.
    Keyboard Inputs: The script uses W, S, Up Arrow, Down Arrow for moving forward and backward, and A, D, Left Arrow, Right Arrow for turning.

HuskyPoseTwistPublisher.cs

This script publishes the Husky's pose and twist to ROS topics.

    ROS Connection: Establishes a connection with ROS using the ROSConnection instance.
    Pose and Twist Topics: Publishes the robot's pose (/husky_pose) and twist (/husky_twist) at a defined frequency.
    Rigidbody: Uses the robot's Rigidbody component to get the current linear and angular velocities.

LidarScanner.cs

This script simulates a LiDAR sensor and publishes point cloud data to a ROS topic.

    LiDAR Range: The maxRange variable defines the maximum range of the LiDAR sensor.
    Rays Per Scan: The raysPerScan variable defines the number of rays per scan.
    Update Frequency: The updateFrequency variable controls how often the LiDAR data is published.
    Point Cloud Data: Simulates LiDAR scans and publishes the point cloud data to the ROS topic /scan.

DisplayCoordinates.cs

This script displays the coordinates of the Husky robot on the screen.

    Husky Transform: References the Husky's Transform component to get its position.
    UI Text Element: Updates a TextMeshProUGUI element with the current position of the Husky.

CameraFollow.cs

This script makes the camera follow the Husky robot.

    Target: The target variable is assigned to the Husky GameObject.
    Offset: The offset variable defines the camera's position relative to the Husky.
    Smooth Speed: The smoothSpeed variable controls how smoothly the camera follows the Husky.
    Look At: Ensures the camera always looks at the Husky.
