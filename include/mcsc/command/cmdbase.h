#pragma once

#include <string>

namespace mcsc::command {

class Command {
public:
	virtual std::string apply() = 0;
};

};	 // namespace mcsc::command