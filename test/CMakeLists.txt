set(Targets
	ProxyBuilder
	DatapackBuilder)

set(dep-libs
	GTest::gtest
	GTest::gtest_main
	glog::glog)

set(mcsc-libs
	mcsc-builtin
	mcsc-core)


foreach (target ${Targets})
	add_executable(t_${target} ${target}_test.cpp)
	target_link_libraries(t_${target} PRIVATE ${dep-libs} ${mcsc-libs})
endforeach()