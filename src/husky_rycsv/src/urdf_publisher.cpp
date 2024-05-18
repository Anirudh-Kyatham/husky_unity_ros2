#include <rclcpp/rclcpp.hpp>
#include <std_msgs/msg/string.hpp>
#include <fstream>
#include <sstream>
#include <string>

class URDFPublisher : public rclcpp::Node {
public:
    URDFPublisher() : Node("urdf_publisher") {
        publisher_ = this->create_publisher<std_msgs::msg::String>("robot_description", 10);
        timer_ = this->create_wall_timer(
            std::chrono::seconds(1),
            std::bind(&URDFPublisher::publish_urdf, this));
    }

private:
    void publish_urdf() {
        std::ifstream file("/home/akyatha/colcon_ws/src/husky_rycsv/urdf/husky.urdf"); // Correct path to your URDF file
        std::string urdf_string((std::istreambuf_iterator<char>(file)), std::istreambuf_iterator<char>());

        if (!urdf_string.empty()) {
            auto message = std_msgs::msg::String();
            message.data = urdf_string;
            RCLCPP_INFO(this->get_logger(), "Publishing URDF");
            publisher_->publish(message);
        } else {
            RCLCPP_ERROR(this->get_logger(), "Failed to load URDF file.");
        }
    }

    rclcpp::TimerBase::SharedPtr timer_;
    rclcpp::Publisher<std_msgs::msg::String>::SharedPtr publisher_;
};


int main(int argc, char **argv)
{
    rclcpp::init(argc, argv);
    auto node = std::make_shared<URDFPublisher>();
    rclcpp::spin(node);
    rclcpp::shutdown();
    return 0;
}

