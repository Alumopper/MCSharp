#pragma once

#include <mcsc/command/cmdbase.h>
#include <mcsc/command/builderbase.h>
#include <mcsc/builtin/errdump.h>

#include <glog/logging.h>
#include <memory>
#include <exception>
#include <type_traits>

namespace mcsc::command {

using CommandBuilder = Builder;

namespace detail {

using ProxyBuilderFlag = struct {};

template <typename T>
concept CommandBuilderType = std::is_base_of_v<CommandBuilder, typename T::Builder> && !
std::is_base_of_v<ProxyBuilderFlag, T>;

};	 // namespace detail

template <detail::CommandBuilderType T>
class ProxyBuilder final : public CommandBuilder, private detail::ProxyBuilderFlag {
private:
	using BuilderType = typename T::Builder;

	ProxyBuilder(BuilderType* ptr)
		: builder_(ptr) {}

	ProxyBuilder(const ProxyBuilder& rhs) = delete;

	ProxyBuilder(ProxyBuilder&& rhs) = delete;

#ifdef NDEBUG
private:
#else
public:
#endif
	template <typename G>
		requires std::is_same_v<G, BuilderType>
	class Wrapper {
	public:
		Wrapper(G* ptr)
			: builder_(ptr) {}

		Wrapper(const Wrapper<G>& rhs) = delete;

		Wrapper(Wrapper<G>&& rhs)
			: builder_(rhs.builder_.release()) {}

	public:
		G* operator->() { return builder_.get(); }

		Command* build() { return ProxyBuilder(builder_.release()).build(); }

	private:
		std::unique_ptr<G> builder_;
	};

private:
	Command* build() override {
		using builtin::ErrDump;

		try {
			return builder_->build();
		} catch (const std::exception& e) {
			LOG(ERROR) << "mcsc::command::ProxyBuilder: caught exception from `"
					   << typeid(BuilderType).name() << "', with `" << e.what() << "' thrown";
			auto err = ProxyBuilder<ErrDump>::require();
			err->setErrorMsg(e.what());
			return err.build();
		}
	}

public:
	template <typename... Args> static Wrapper<BuilderType> require(Args... args) {
		return new BuilderType(std::forward<Args>(args)...);
	}

private:
	std::unique_ptr<BuilderType> builder_;
};

};	 // namespace mcsc::command