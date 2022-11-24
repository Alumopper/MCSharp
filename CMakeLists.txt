cmake_minimum_required (VERSION 3.0.0)
project(MCSC CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

option(BUILD_test "build testbench" OFF)
option(BUILD_example "build examples" OFF)

add_subdirectory(share/3rdparty/json)
add_subdirectory(share/3rdparty/glog)
add_subdirectory(src)

if (BUILD_test)
	add_subdirectory(share/3rdparty/gtest)
	add_subdirectory(test)
endif()

if (BUILD_example)
	add_subdirectory(share/example)
endif()