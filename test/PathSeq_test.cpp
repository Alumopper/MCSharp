#include <mcsc/datapack/pathseq.h>

#include <gtest/gtest.h>
#include <stdexcept>
#include <string>

using namespace mcsc::datapack;

TEST(PathSeq, fromString) {
	auto a = PathSeq::fromString("/data/functions/helloworld/1");
	auto b = PathSeq::fromString("data/functions/helloworld/1/2");
	auto c = PathSeq::fromString("///data/functions//helloworld/1/2/3///");

	ASSERT_EQ(a.getDepth(), 4);
	ASSERT_EQ(b.getDepth(), 5);
	ASSERT_EQ(c.getDepth(), 6);
}

TEST(PathSeq, toString) {
	auto a = PathSeq::fromString("/data/functions/helloworld/1");
	auto b = PathSeq::fromString("data/functions/helloworld/1/2");
	auto c = PathSeq::fromString("///data/functions//helloworld/1/2/3///");

	ASSERT_STREQ(a.toString().c_str(), "/data/functions/helloworld/1");
	ASSERT_STREQ(b.toString().c_str(), "/data/functions/helloworld/1/2");
	ASSERT_STREQ(c.toString().c_str(), "/data/functions/helloworld/1/2/3");
}

TEST(PathSeq, RandomAccess) {
	auto a = PathSeq::fromString("/data/functions/helloworld/1");

	ASSERT_STREQ(a[0].c_str(), "data");
	ASSERT_STREQ(a[1].c_str(), "functions");
	ASSERT_STREQ(a[2].c_str(), "helloworld");
	ASSERT_STREQ(a[3].c_str(), "1");

	ASSERT_STREQ(a[-1].c_str(), "1");
	ASSERT_STREQ(a[-2].c_str(), "helloworld");
	ASSERT_STREQ(a[-3].c_str(), "functions");
	ASSERT_STREQ(a[-4].c_str(), "data");

	ASSERT_THROW(a[a.getDepth()], std::out_of_range);
	ASSERT_THROW(a[-(a.getDepth() + 1)], std::out_of_range);
}