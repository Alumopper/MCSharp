#include <mcsc/datapack.h>

#include <gtest/gtest.h>

using mcsc::DatapackBuilder;

TEST(DatapackBuilder, VersionRequirement) {
	ASSERT_EQ(8, DatapackBuilder("test.pack", ">=1.17.3").getPackFormat());
	ASSERT_EQ(4, DatapackBuilder("test.pack", "=1.14.5").getPackFormat());
	ASSERT_EQ(4, DatapackBuilder("test.pack", "dummy").getPackFormat());
	ASSERT_EQ(8, DatapackBuilder("test.pack", ">1.17").getPackFormat());
}

TEST(DatapackBuilder, DefaultDescription) {
	ASSERT_STREQ("Minecraft datapack developed for 1.18.0-1.18.1",
				 DatapackBuilder("test.pack", ">=1.17.3").getDescription().c_str());
}