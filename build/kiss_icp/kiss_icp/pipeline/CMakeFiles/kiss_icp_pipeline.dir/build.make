# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.16

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/akyatha/colcon_ws/src/kiss-icp/ros

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/akyatha/colcon_ws/build/kiss_icp

# Include any dependencies generated for this target.
include kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/depend.make

# Include the progress variables for this target.
include kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/progress.make

# Include the compile flags for this target's objects.
include kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/flags.make

kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o: kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/flags.make
kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o: /home/akyatha/colcon_ws/src/kiss-icp/cpp/kiss_icp/pipeline/KissICP.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/akyatha/colcon_ws/build/kiss_icp/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o"
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o -c /home/akyatha/colcon_ws/src/kiss-icp/cpp/kiss_icp/pipeline/KissICP.cpp

kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.i"
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/akyatha/colcon_ws/src/kiss-icp/cpp/kiss_icp/pipeline/KissICP.cpp > CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.i

kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.s"
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/akyatha/colcon_ws/src/kiss-icp/cpp/kiss_icp/pipeline/KissICP.cpp -o CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.s

# Object files for target kiss_icp_pipeline
kiss_icp_pipeline_OBJECTS = \
"CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o"

# External object files for target kiss_icp_pipeline
kiss_icp_pipeline_EXTERNAL_OBJECTS =

kiss_icp/pipeline/libkiss_icp_pipeline.a: kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/KissICP.cpp.o
kiss_icp/pipeline/libkiss_icp_pipeline.a: kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/build.make
kiss_icp/pipeline/libkiss_icp_pipeline.a: kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/akyatha/colcon_ws/build/kiss_icp/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX static library libkiss_icp_pipeline.a"
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && $(CMAKE_COMMAND) -P CMakeFiles/kiss_icp_pipeline.dir/cmake_clean_target.cmake
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/kiss_icp_pipeline.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/build: kiss_icp/pipeline/libkiss_icp_pipeline.a

.PHONY : kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/build

kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/clean:
	cd /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline && $(CMAKE_COMMAND) -P CMakeFiles/kiss_icp_pipeline.dir/cmake_clean.cmake
.PHONY : kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/clean

kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/depend:
	cd /home/akyatha/colcon_ws/build/kiss_icp && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/akyatha/colcon_ws/src/kiss-icp/ros /home/akyatha/colcon_ws/src/kiss-icp/cpp/kiss_icp/pipeline /home/akyatha/colcon_ws/build/kiss_icp /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline /home/akyatha/colcon_ws/build/kiss_icp/kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : kiss_icp/pipeline/CMakeFiles/kiss_icp_pipeline.dir/depend

