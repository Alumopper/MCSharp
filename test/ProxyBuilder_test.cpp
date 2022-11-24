#ifdef NDEBUG
#	undef NDEBUG
#endif

#include <mcsc/command/cmdbase.h>
#include <mcsc/command/builderbase.h>
#include <mcsc/command/proxybuilder.h>

#include <gtest/gtest.h>
#include <string>
#include <algorithm>

using namespace mcsc::command;

struct DummyCommand : public Command {
	virtual std::string apply() override { return "Hello World! - DummyCommand"; }

	struct Builder : public CommandBuilder {
		virtual Command* build() override { return new DummyCommand(); }
	};

private:
	DummyCommand() = default;
};

struct ExceptCommand : public Command {
	virtual std::string apply() override { return "Hello World! - ExceptCommand"; }

	struct Builder : public CommandBuilder {
		virtual Command* build() override {
			throw std::runtime_error("ExceptCommand throw an ERROR!");
			return new ExceptCommand();
		}
	};

private:
	ExceptCommand() = default;
};

struct CommonCommand : public Command {
	virtual std::string apply() override { return msg_; }
	struct Builder : public CommandBuilder {
		Builder() { cmd_.reset(new CommonCommand()); }

		virtual Command* build() override {
			if (cmd_->msg_.find("abort") != -1)
				throw std::runtime_error("CommonCommand caught unexpected `abort' string");
			return cmd_.release();
		}

		Builder* appendString(const std::string& s) noexcept {
			cmd_->msg_ += s;
			return this;
		}

	private:
		std::unique_ptr<CommonCommand> cmd_;
	};

private:
	CommonCommand() = default;

private:
	std::string msg_;
};

TEST(ProxyBuilder, TypeCheck) {
	ASSERT_TRUE((std::is_same_v<decltype(ProxyBuilder<DummyCommand>::require()),
								ProxyBuilder<DummyCommand>::Wrapper<DummyCommand::Builder>>));
}

TEST(ProxyBuilder, RetvalCheck) {
	ASSERT_STREQ(ProxyBuilder<DummyCommand>::require().build()->apply().c_str(),
				 "Hello World! - DummyCommand");
	ASSERT_STREQ(ProxyBuilder<ExceptCommand>::require().build()->apply().c_str(),
				 "ExceptCommand throw an ERROR!");
}

TEST(ProxyBuilder, BuildCheck) {
	{
		auto o = ProxyBuilder<CommonCommand>::require();
		ASSERT_STREQ(o.build()->apply().c_str(), "");
	}
	{
		auto o = ProxyBuilder<CommonCommand>::require();
		o->appendString("echo")->appendString(" ")->appendString("\"Hello World!\"");
		ASSERT_STREQ(o.build()->apply().c_str(), "echo \"Hello World!\"");
	}
	{
		auto o = ProxyBuilder<CommonCommand>::require();
		o->appendString("echo")->appendString(" ")->appendString("abort");
		ASSERT_STREQ(o.build()->apply().c_str(), "CommonCommand caught unexpected `abort' string");
	}
}