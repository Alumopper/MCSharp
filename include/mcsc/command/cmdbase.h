#pragma once

#include <string>

namespace mcsc::command {

struct Command {
	virtual std::string apply() = 0;
	virtual ~Command() = default;
};

struct Builder {
	virtual Command* build()	= 0;
};

};	 // namespace mcsc::command