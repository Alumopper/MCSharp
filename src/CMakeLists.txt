aux_source_directory(builtin BUILTIN_SOURCE_FILES)
aux_source_directory(. CORE_SOURCE_FILES)

add_library(mcsc-builtin STATIC ${BUILTIN_SOURCE_FILES})
target_link_libraries(mcsc-builtin PRIVATE glog::glog)

add_library(mcsc-core STATIC ${CORE_SOURCE_FILES})
target_link_libraries(mcsc-core PRIVATE glog::glog)