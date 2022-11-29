#include <mcsc/datapack.h>
#include <mcsc/command/proxybuilder.h>

#include <gtest/gtest.h>

using mcsc::DatapackBuilder;
using mcsc::command::Command;
using CommandBuilder = mcsc::command::Builder;

struct SayCommand : Command {
	//! data field
	std::string msg, receiver;

	//! interface implement
	SayCommand() = default;
	virtual std::string apply() override { return std::move(msg); }

	struct Builder : CommandBuilder {
		//! filed declaration
		MCSC_CMD_BUILDER(SayCommand);

		//! data field
		std::shared_ptr<SayCommand> cmd;

		//! interface implement
		Builder() = default;
		virtual SayCommand* build() override { return cmd.get(); }

		//! configure
		ProxyRef say(const std::string& e) {
			if (!cmd.get()) cmd.reset(new SayCommand);
			cmd->msg = e;
			return proxy();
		}

		ProxyRef sendTo(const std::string& e) {
			if (!cmd.get()) cmd.reset(new SayCommand);
			cmd->receiver = e;
			return proxy();
		}
	};
};

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

TEST(DatapackBuilder, Sample) {
	using mcsc::datapack::Namespace;
	using mcsc::command::ProxyBuilder;
	using namespace mcsc::builtin;

	DatapackBuilder builder("SampleTest", ">=1.12");

	if (builder.begin<Namespace::NS_Func>()) {
		auto SayOnce =
			ProxyBuilder<SayCommand>::require()->say("How old are you?")->sendTo("Maxness").build();
		for (size_t i = 0; i < 114514; ++i) {
			builder.commit(SayOnce);
		}
		builder.commit(ProxyBuilder<ErrDump>::require()->setErrorMsg("FBI open the door!").build());
		builder.end();
	}

	builder.save();
}