#pragma once

#include <mcsc/command/cmdbase.h>
#include <mcsc/command/builderbase.h>

#include <memory>

namespace mcsc::builtin {

using mcsc::command::Command;
using CommandBuilder = mcsc::command::Builder;

//! 错误转储
class ErrDump : public Command {
private:
	ErrDump();

public:
	virtual std::string apply() override;

	class Builder : public CommandBuilder {
	public:
		virtual Command* build() override;

		Builder();
		Builder* setErrorMsg(const std::string& err) noexcept;
	private:
		std::unique_ptr<ErrDump> cmd_;
	};

private:
	std::string errmsg_;
};

};	 // namespace mcsc::builtin
