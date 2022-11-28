#pragma once

#include <mcsc/datapack/namespace.h>
#include <mcsc/datapack/pathseq.h>

#include <nlohmann/json.hpp>
#include <string>
#include <list>
#include <variant>
#include <array>

namespace mcsc::datapack {

class ItemTree {
private:
	struct internal_type {
		using node_type = std::variant<std::list<internal_type>, std::string>;
		node_type	value;
		std::string arc;
	};

	internal_type* operator[](Namespace ns);

public:
	ItemTree();
	~ItemTree();

	bool inited(Namespace ns) const;
	bool init(Namespace ns);

	bool add(Namespace ns, const std::string& path, const std::string& data, bool replace = false);
	bool remove(Namespace ns, const std::string& path);

	auto get(Namespace ns, const std::string& path)
		-> std::optional<std::reference_wrapper<std::string>>;

	nlohmann::json toJson() const;

private:
	static void buildJsonR(nlohmann::json& j, const internal_type* node);

private:
	std::array<internal_type*, NS_Number> roots_;
};

};	 // namespace mcsc::datapack