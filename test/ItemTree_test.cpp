#include <mcsc/datapack/itemtree.h>

#include <gtest/gtest.h>
#include <string>
#include <algorithm>

using namespace mcsc::datapack;

TEST(ItemTree, inited) {
	ItemTree tree;

	ASSERT_FALSE(tree.inited(Namespace::NS_Advancement));
	ASSERT_FALSE(tree.inited(Namespace::NS_Dim));
	ASSERT_FALSE(tree.inited(Namespace::NS_DimType));
	ASSERT_FALSE(tree.inited(Namespace::NS_Func));
	ASSERT_FALSE(tree.inited(Namespace::NS_LootTable));
	ASSERT_FALSE(tree.inited(Namespace::NS_Predicate));
	ASSERT_FALSE(tree.inited(Namespace::NS_Recipe));
	ASSERT_FALSE(tree.inited(Namespace::NS_Struct));
	ASSERT_FALSE(tree.inited(Namespace::NS_Tag));
	ASSERT_FALSE(tree.inited(Namespace::NS_Worldgen));

	ASSERT_FALSE(tree.inited(Namespace::NS_Unused));
}

TEST(ItemTree, init) {
	ItemTree tree;

	ASSERT_FALSE(tree.inited(Namespace::NS_Func));
	ASSERT_FALSE(tree.inited(Namespace::NS_Tag));
	ASSERT_FALSE(tree.inited(Namespace::NS_Unused));

	ASSERT_FALSE(tree.init(Namespace::NS_Unused));
	ASSERT_FALSE(tree.inited(Namespace::NS_Func));
	ASSERT_FALSE(tree.inited(Namespace::NS_Tag));
	ASSERT_FALSE(tree.inited(Namespace::NS_Unused));

	ASSERT_TRUE(tree.init(Namespace::NS_Func));
	ASSERT_TRUE(tree.inited(Namespace::NS_Func));
	ASSERT_FALSE(tree.inited(Namespace::NS_Tag));
	ASSERT_FALSE(tree.inited(Namespace::NS_Unused));
}

TEST(ItemTree, add) {
	ItemTree tree;

	ASSERT_FALSE(tree.add(Namespace::NS_Unused, ".minecraft/cpp/echo", R"(say Hello World!)"));

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo", R"(say Hello World!)"));

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo", R"(say Hello World!)", true));
	ASSERT_FALSE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.inited(Namespace::NS_Func));

	ASSERT_TRUE(tree.add(Namespace::NS_Tag, ".minecraft/cpp/echo/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.inited(Namespace::NS_Tag));
}

TEST(ItemTree, remove) {
	ItemTree tree;

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.add(Namespace::NS_Tag, ".minecraft/cpp", R"(say Hello World!)"));

	ASSERT_FALSE(tree.remove(Namespace::NS_Tag, ".minecraft/cpp/echo"));
	ASSERT_TRUE(tree.remove(Namespace::NS_Tag, ".minecraft/cpp"));
	ASSERT_FALSE(tree.remove(Namespace::NS_Tag, ".minecraft/cpp"));

	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/cpp/echo/echo"));
	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/cpp/echo"));

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo", R"(say Hello World!)"));
	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/cpp/echo/echo", R"(say Hello World!)"));

	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/cpp/echo"));
	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/cpp/echo/echo"));
}

TEST(ItemTree, get) {
	ItemTree tree;

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo", R"(say 1)"));
	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo/echo", R"(say 2)"));

	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo").has_value());
	ASSERT_STREQ(tree.get(Namespace::NS_Func, ".minecraft/echo")->get().c_str(), R"(say 1)");

	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo/echo").has_value());
	ASSERT_STREQ(tree.get(Namespace::NS_Func, ".minecraft/echo/echo")->get().c_str(), R"(say 2)");

	tree.get(Namespace::NS_Func, ".minecraft/echo")->get() = R"(say 3)";
	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo").has_value());
	ASSERT_STREQ(tree.get(Namespace::NS_Func, ".minecraft/echo")->get().c_str(), R"(say 3)");

	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/echo"));
	ASSERT_FALSE(tree.get(Namespace::NS_Func, ".minecraft/echo").has_value());
	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo/echo").has_value());

	ASSERT_FALSE(tree.add(Namespace::NS_Func, ".minecraft/echo/echo", R"(say 4)"));
	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo/echo").has_value());
	ASSERT_STREQ(tree.get(Namespace::NS_Func, ".minecraft/echo/echo")->get().c_str(), R"(say 2)");

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo/echo", R"(say 4)", true));
	ASSERT_TRUE(tree.get(Namespace::NS_Func, ".minecraft/echo/echo").has_value());
	ASSERT_STREQ(tree.get(Namespace::NS_Func, ".minecraft/echo/echo")->get().c_str(), R"(say 4)");
}

TEST(ItemTree, toJson) {
	ItemTree tree;

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo", R"(say Hello World!)"));
	ASSERT_STREQ(nlohmann::to_string(tree.toJson()).c_str(),
				 R"({"functions":{".minecraft":{"echo":"say Hello World!"}}})");

	ASSERT_TRUE(tree.add(Namespace::NS_Tag, ".minecraft/newmob", R"({"damage":3})"));
	ASSERT_STREQ(nlohmann::to_string(tree.toJson()).c_str(),
				 R"({"functions":{".minecraft":{"echo":"say Hello World!"}},)"
				 R"("tags":{".minecraft":{"newmob":"{\"damage\":3}"}}})");

	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo/a", R"(say !dlroW olleH)"));
	ASSERT_ANY_THROW(tree.toJson());
	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/echo/a"));

	ASSERT_TRUE(tree.remove(Namespace::NS_Func, ".minecraft/echo"));
	ASSERT_TRUE(tree.add(Namespace::NS_Func, ".minecraft/echo.mcfunction", R"(say Hello World!)"));
	ASSERT_TRUE(
		tree.add(Namespace::NS_Func, ".minecraft/echo/a.mcfunction", R"(say !dlroW olleH)"));

	ASSERT_STREQ(nlohmann::to_string(tree.toJson()).c_str(),
				 R"({"functions":{".minecraft":{"echo":{"a.mcfunction":"say !dlroW olleH"},)"
				 R"("echo.mcfunction":"say Hello World!"}},)"
				 R"("tags":{".minecraft":{"newmob":"{\"damage\":3}"}}})");
}