#pragma once

#include <mcsc/command/cmdbase.h>
#include <mcsc/command/proxybase.h>
#include <mcsc/builtin/errdump.h>

#include <glog/logging.h>
#include <memory>
#include <string>

namespace mcsc::command {

template <typename T> class ProxyBuilder final : public ProxyBase<T> {
private:
	using BuilderType = typename ProxyBase<T>::BuilderType;

	ProxyBuilder(const ProxyBuilder&) = delete;

	template <typename... Args>
	ProxyBuilder(Args&&... args)
		: ProxyBase<T>(std::forward<Args&&>(args)...) {}

public:
	template <typename... Args> static ProxyBuilder<T> require(Args&&... args) {
		return ProxyBuilder<T>(std::forward<Args&&>(args)...);
	}

	virtual Command* build() override {
		using ::mcsc::builtin::ErrDump;
		try {
			return ProxyBase<T>::unwrap().build();
		} catch (const std::exception& e) {
			LOG(ERROR) << "mcsc::command::ProxyBuilder: caught exception from `"
					   << typeid(BuilderType).name() << "', with `" << e.what() << "' thrown";
			return ProxyBuilder<ErrDump>::require()->setErrorMsg(e.what()).build();
		}
	}
};

};	 // namespace mcsc::command