#include <mcsc/datapack/pathseq.h>

#include <sstream>
#include <iostream>
#include <stdexcept>

namespace mcsc::datapack {

PathSeq::PathSeq(const PathSeq& obj) {
	seq_ = obj.seq_;
}

PathSeq::PathSeq(PathSeq&& obj) {
	seq_.swap(obj.seq_);
}

PathSeq PathSeq::fromString(const std::string& path) {
	PathSeq			   pathseq;
	std::istringstream iss(path);
	std::string		   e;
	while (std::getline(iss, e, '/')) {
		if (e.size() == 0) continue;
		pathseq.seq_.emplace_back(std::move(e));
	}
	return {std::move(pathseq)};
}

std::string PathSeq::toString() const {
	if (getDepth() == 0) return "/";
	std::ostringstream oss;
	for (const auto& e : seq_) {
		oss << "/" << e;
	}
	return oss.str();
}

size_t PathSeq::getDepth() const {
	return seq_.size();
}

const PathSeq::value_type& PathSeq::getSequence() const {
	return seq_;
}

const std::string& PathSeq::operator[](int index) const {
	const int len = getDepth();
	if (index - len >= 0 || index + len < 0)
		throw std::out_of_range("mcsc::datapack::PathSeq: operator[] access exceed range");
	if (index < 0) index += len;
	auto it = seq_.cbegin();
	while (index--) {
		++it;
	}
	return *it;
}

};	 // namespace mcsc::datapack