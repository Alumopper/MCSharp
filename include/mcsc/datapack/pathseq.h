#pragma once

#include <stddef.h>
#include <string>
#include <list>

namespace mcsc::datapack {

class PathSeq {
private:
	using value_type = std::list<std::string>;
	PathSeq()		 = default;

public:
	PathSeq(const PathSeq& obj);
	PathSeq(PathSeq&& obj);

	static PathSeq fromString(const std::string& path);
	std::string	   toString() const;

	size_t			   getDepth() const;
	const value_type&  getSequence() const;
	const std::string& operator[](int index) const;

private:
	value_type seq_;
};

};	 // namespace mcsc::datapack