cmake_minimum_required(VERSION 3.5)
project(husky_tf_broadcaster)

# Default to C99 for C code
if(NOT CMAKE_C_STANDARD)
  set(CMAKE_C_STANDARD 99)
endif()

# Default to C++14 for C++ code
if(NOT CMAKE_CXX_STANDARD)
  set(CMAKE_CXX_STANDARD 14)
endif()

# Compiler-specific options for GNU and Clang
if(CMAKE_COMPILER_IS_GNUCXX OR CMAKE_CXX_COMPILER_ID MATCHES "Clang")
  add_compile_options(-Wall -Wextra -Wpedantic)
endif()

# find dependencies
find_package(ament_cmake REQUIRED)
find_package(rclcpp REQUIRED)
find_package(geometry_msgs REQUIRED)
find_package(tf2_ros REQUIRED)
find_package(tf2_geometry_msgs REQUIRED)

# Declare a C++ executable
add_executable(husky_tf_broadcaster src/husky_tf_broadcaster.cpp)

# Specify libraries to link a library or executable target against
ament_target_dependencies(husky_tf_broadcaster
  rclcpp
  geometry_msgs
  tf2_ros
  tf2_geometry_msgs
)

# Install the executable
install(TARGETS husky_tf_broadcaster
  DESTINATION lib/${PROJECT_NAME}
)

install(DIRECTORY
    launch
    DESTINATION share/${PROJECT_NAME}
)

if(BUILD_TESTING)
  find_package(ament_lint_auto REQUIRED)
  ament_lint_auto_find_test_dependencies()
endif()

# Macro to finalize the package
ament_package()

