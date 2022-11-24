#pragma once

#include <mcsc/command/cmdbase.h>

namespace mcsc::command {

class Builder {
public:
	virtual Command build() = 0;
};

};	 // namespace mcsc::command