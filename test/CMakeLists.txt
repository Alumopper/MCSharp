set(Targets
	ProxyBuilder
	DatapackBuilder
	PathSeq
	ItemTree
	)

set(dep-libs
	GTest::gtest
	GTest::gtest_main
	glog::glog
	nlohmann_json::nlohmann_json)

set(mcsc-libs
	mcsc-builtin
	mcsc-core)

foreach (target ${Targets})
	add_executable(t_${target} ${target}_test.cpp)
	target_link_libraries(t_${target} PRIVATE ${dep-libs} ${mcsc-libs})
	target_compile_options(t_${target} PRIVATE)
endforeach()