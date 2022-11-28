macro(GetSourceFiles target)
	set(_SOURCE_FILES)
	set(${target})
	foreach(dir ${ARGN})
		aux_source_directory(${dir} _SOURCE_FILES)
		list(APPEND ${target} ${_SOURCE_FILES})
	endforeach()
endmacro()

GetSourceFiles(BUILTIN_SOURCE_FILES builtin)

GetSourceFiles(CORE_SOURCE_FILES . datapack)

add_library(mcsc-builtin STATIC ${BUILTIN_SOURCE_FILES})
target_link_libraries(mcsc-builtin PRIVATE glog::glog)

add_library(mcsc-core STATIC ${CORE_SOURCE_FILES})
target_link_libraries(mcsc-core PRIVATE glog::glog)