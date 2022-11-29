#pragma once

#include <array>
#include <string_view>

namespace mcsc::datapack {

enum class Namespace {
	NS_Advancement = 0,	  //! "data/$name/advancements"
	NS_Dim,				  //! "data/$name/dimension"
	NS_DimType,			  //! "data/$name/dimension_type"
	NS_Func,			  //! "data/$name/functions"
	NS_LootTable,		  //! "data/$name/loot_tables"
	NS_Predicate,		  //! "data/$name/predicates"
	NS_Recipe,			  //! "data/$name/recipes"
	NS_Struct,			  //! "data/$name/structures"
	NS_Tag,				  //! "data/$name/tags"
	NS_Worldgen,		  //! "data/$name/worldgen"
	NS_Unused,
};

constexpr size_t NS_Number = static_cast<size_t>(Namespace::NS_Unused);

constexpr std::array<std::string_view, NS_Number> NamespaceKeys{
	"advancements",		//! Namespace::NS_Advancement
	"dimension",		//! Namespace::NS_Dim
	"dimension_type",	//! Namespace::NS_DimType
	"functions",		//! Namespace::NS_Func
	"loot_tables",		//! Namespace::NS_LootTable
	"predicates",		//! Namespace::NS_Predicate
	"recipes",			//! Namespace::NS_Recipe
	"structures",		//! Namespace::NS_Struct
	"tags",				//! Namespace::NS_Tag
	"worldgen",			//! Namespace::NS_Worldgen
};

inline std::string_view getNamespaceKey(Namespace ns) {
	if (ns == Namespace::NS_Unused) return "";
	const size_t index = static_cast<size_t>(ns);
	return NamespaceKeys[index];
}

};	 // namespace mcsc::datapack
