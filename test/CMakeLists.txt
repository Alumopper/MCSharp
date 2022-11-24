set(Targets
	ProxyBuilder)

set(mcsc-libs
	mcsc-builtin)

foreach (target ${Targets})
	add_executable(t_${target} ${target}_test.cpp)
	target_link_libraries(t_${target} PRIVATE GTest::gtest GTest::gtest_main ${mcsc-libs})
endforeach()