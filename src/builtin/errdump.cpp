#include <mcsc/builtin/errdump.h>

namespace mcsc::builtin {

ErrDump::ErrDump() {}

std::string ErrDump::apply() {
	return errmsg_;
}

ErrDump::Builder::Builder() {
	cmd_.reset(new ErrDump());
}

Command* ErrDump::Builder::build() {
	return cmd_.release();
}

ErrDump::Builder::ProxyRef ErrDump::Builder::setErrorMsg(const std::string& err) noexcept {
	cmd_->errmsg_ = err;
	return proxy();
}

};	 // namespace mcsc::builtin