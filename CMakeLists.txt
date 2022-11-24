cmake_minimum_required (VERSION 3.0.0)
project(MCSC VERSION 0.1.0 LANGUAGES C CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

option(BUILD_test "build testbench" OFF)
option(BUILD_example "build examples" OFF)

include_directories(include)

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