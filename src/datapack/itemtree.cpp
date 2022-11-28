#include <mcsc/datapack/itemtree.h>

#include <stddef.h>
#include <memory>
#include <variant>

namespace mcsc::datapack {

ItemTree::ItemTree() {
	for (auto& e : roots_) {
		e = nullptr;
	}
}

ItemTree::~ItemTree() {
	for (auto& e : roots_) {
		if (e) {
			delete e;
			e = nullptr;
		}
	}
}

ItemTree::internal_type* ItemTree::operator[](Namespace ns) {
	if (ns == Namespace::NS_Unused) return nullptr;
	const auto index = static_cast<size_t>(ns);
	return roots_[index];
}

bool ItemTree::inited(Namespace ns) const {
	if (ns == Namespace::NS_Unused) return false;
	const auto index = static_cast<size_t>(ns);
	return roots_[index] != nullptr;
}

bool ItemTree::init(Namespace ns) {
	if (!inited(ns)) {
		const auto index = static_cast<size_t>(ns);
		auto	   root	 = std::make_unique<internal_type>();
		root->arc		 = getNamespaceKey(ns);
		root->value		 = std::list<internal_type>();
		roots_[index]	 = root.release();
	}
	return inited(ns);
}

bool ItemTree::add(Namespace ns, const std::string& path, const std::string& data, bool replace) {
	if (!init(ns)) return false;

	auto node = operator[](ns);

	auto		seq		= PathSeq::fromString(path);
	const auto& pathseq = seq.getSequence();

	auto p_succ	 = std::get_if<0>(&node->value);
	auto it_path = pathseq.cbegin();
	while (it_path != pathseq.cend()) {
		auto it_this_arc = it_path++;
		bool is_last	 = it_path == pathseq.cend();
		auto it			 = p_succ->begin();
		while (it != p_succ->end()) {
			auto it_this = it++;
			if (it_this->arc != *it_this_arc) continue;
			bool is_item = std::get_if<0>(&it_this->value) == nullptr;
			if (!is_last && is_item || is_last && !is_item) continue;
			if (is_last && is_item) {
				if (replace) it_this->value = data;
				return replace;
			}
			node   = &*it_this;
			p_succ = std::get_if<0>(&node->value);
			break;
		}
		if (it == p_succ->end()) {
			it_path = it_this_arc;
			break;
		}
	}

	while (true) {
		auto it_this_arc = it_path++;
		if (it_path == pathseq.end()) {
			it_path = it_this_arc;
			break;
		}
		internal_type arc;
		arc.arc	  = *it_this_arc;
		arc.value = std::list<internal_type>();
		node	  = &p_succ->emplace_back(std::move(arc));
		p_succ	  = std::get_if<0>(&node->value);
	}

	internal_type item;
	item.arc   = *it_path;
	item.value = data;
	p_succ->emplace_back(std::move(item));
	return true;
}

bool ItemTree::remove(Namespace ns, const std::string& path) {
	if (!inited(ns)) return false;

	auto node = operator[](ns);

	auto		seq		= PathSeq::fromString(path);
	const auto& pathseq = seq.getSequence();

	auto p_succ	 = std::get_if<0>(&node->value);
	auto it_path = pathseq.cbegin();
	while (it_path != pathseq.cend()) {
		auto it_this_arc = it_path++;
		bool is_last	 = it_path == pathseq.cend();
		auto it			 = p_succ->begin();
		while (it != p_succ->end()) {
			auto it_this = it++;
			if (it_this->arc != *it_this_arc) continue;
			bool is_item = std::get_if<0>(&it_this->value) == nullptr;
			if (!is_last && is_item || is_last && !is_item) continue;
			if (is_last && is_item) {
				p_succ->erase(it_this);
				return true;
			}
			node   = &*it_this;
			p_succ = std::get_if<0>(&node->value);
			break;
		}
		if ((it == p_succ->end())) return false;
	}

	return false;
}

auto ItemTree::get(Namespace ns, const std::string& path)
	-> std::optional<std::reference_wrapper<std::string>> {
	if (!inited(ns)) return std::nullopt;

	auto node = operator[](ns);

	auto		seq		= PathSeq::fromString(path);
	const auto& pathseq = seq.getSequence();

	auto p_succ	 = std::get_if<0>(&node->value);
	auto it_path = pathseq.cbegin();
	while (it_path != pathseq.cend()) {
		auto it_this_arc = it_path++;
		bool is_last	 = it_path == pathseq.cend();
		auto it			 = p_succ->begin();
		while (it != p_succ->end()) {
			auto it_this = it++;
			if (it_this->arc != *it_this_arc) continue;
			bool is_item = std::get_if<0>(&it_this->value) == nullptr;
			if (!is_last && is_item || is_last && !is_item) continue;
			if (is_last && is_item) {
				return {std::get<std::string>(it_this->value)};
			}
			node   = &*it_this;
			p_succ = std::get_if<0>(&node->value);
			break;
		}
		if ((it == p_succ->end())) return std::nullopt;
	}

	return std::nullopt;
}

};	 // namespace mcsc::datapack