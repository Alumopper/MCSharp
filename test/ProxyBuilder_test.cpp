#include <mcsc/command/proxybuilder.h>

#include <gtest/gtest.h>
#include <string>
#include <algorithm>

using namespace mcsc::command;
using namespace mcsc::builtin;

TEST(ProxyBuilder, test) {
	ProxyBuilder<ErrDump>::require()->setErrorMsg("Hello World!").build()->apply();
}

struct DummyCommand : public Command {
	virtual std::string apply() override { return "Hello World! - DummyCommand"; }

	struct Builder : public CommandBuilder {
		MCSC_CMD_BUILDER(DummyCommand);
		Builder() = default;
		virtual Command* build() override {
			ptr.reset(new DummyCommand);
			return ptr.get();
		}
		std::unique_ptr<DummyCommand> ptr;
	};
};

struct ExceptCommand : public Command {
	virtual std::string apply() override { return "Hello World! - ExceptCommand"; }

	struct Builder : public CommandBuilder {
		MCSC_CMD_BUILDER(ExceptCommand);
		Builder() = default;
		virtual Command* build() override {
			throw std::runtime_error("ExceptCommand throw an ERROR!");
			ptr.reset(new ExceptCommand);
			return ptr.get();
		}
		std::unique_ptr<ExceptCommand> ptr;
	};
};

struct CommonCommand : public Command {
	virtual std::string apply() override { return msg; }
	std::string			msg;

	struct Builder : public CommandBuilder {
		MCSC_CMD_BUILDER(CommonCommand);
		Builder()
			: ptr(new CommonCommand) {}
		virtual Command* build() override {
			if (ptr->msg.find("abort") != -1)
				throw std::runtime_error("CommonCommand caught unexpected `abort' string");
			return ptr.get();
		}
		ProxyRef appendString(const std::string& s) noexcept {
			ptr->msg += s;
			return proxy();
		}
		std::unique_ptr<CommonCommand> ptr;
	};
};

TEST(ProxyBuilder, RetvalCheck) {
	ASSERT_STREQ(ProxyBuilder<DummyCommand>::require().build()->apply().c_str(),
				 "Hello World! - DummyCommand");
	ASSERT_STREQ(ProxyBuilder<ExceptCommand>::require().build()->apply().c_str(),
				 "ExceptCommand throw an ERROR!");
}

TEST(ProxyBuilder, BuildCheck) {
	ASSERT_STREQ(ProxyBuilder<CommonCommand>::require().build()->apply().c_str(), "");
	ASSERT_STREQ(ProxyBuilder<CommonCommand>::require()
					 ->appendString("echo")
					 ->appendString(" ")
					 ->appendString("\"Hello World!\"")
					 .build()
					 ->apply()
					 .c_str(),
				 "echo \"Hello World!\"");
	ASSERT_STREQ(ProxyBuilder<CommonCommand>::require()
					 ->appendString("echo")
					 ->appendString(" ")
					 ->appendString("abort")
					 .build()
					 ->apply()
					 .c_str(),
				 "CommonCommand caught unexpected `abort' string");
}

TEST(ProxyBuilder, ExceptCheck) {
	ASSERT_ANY_THROW(
		ProxyBuilder<CommonCommand>::require()->appendString("abort").unwrap().build()->apply().c_str());
	ASSERT_ANY_THROW(
		ProxyBuilder<CommonCommand>::require()->appendString("abort")->build()->apply().c_str());
}

TEST(ProxyBuilder, MultiLineCheck) {
	auto e = ProxyBuilder<CommonCommand>::require();
	e->appendString("Hello")->appendString(" ")->appendString("World")->appendString("!");
	ASSERT_STREQ(e.build()->apply().c_str(), "Hello World!");
	e->appendString("(abort)");
	ASSERT_ANY_THROW(e->build());
	ASSERT_ANY_THROW(e.unwrap().build());
	ASSERT_NO_THROW(e.build());
	ASSERT_STREQ(e.build()->apply().c_str(), "CommonCommand caught unexpected `abort' string");
}