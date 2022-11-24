#pragma once

#include <mcsc/command/cmdbase.h>
#include <mcsc/command/builderbase.h>
#include <mcsc/builtin/errdump.h>

#include <memory>
#include <exception>
#include <type_traits>

namespace mcsc::builtin {

using CommandBuilder = mcsc::command::Builder;

namespace detail {

using ProxyBuilderFlag = struct {};

template <typename T>
concept CommandBuilderType = std::is_base_of_v<T, CommandBuilder> && !
std::is_base_of_v<T, ProxyBuilderFlag>;

};	 // namespace detail

template <detail::CommandBuilderType T>
class ProxyBuilder final : public CommandBuilder, private detail::ProxyBuilderFlag {
private:
	using BuilderType = typename T::builder;

	ProxyBuilder(BuilderType* ptr)
		: builder_(ptr) {}

	ProxyBuilder(const ProxyBuilder& rhs) = delete;

	ProxyBuilder(ProxyBuilder&& rhs) = delete;

private:
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

		Command build() { return ProxyBuilder(builder_.release()).build(); }

	private:
		std::unique_ptr<G> builder_;
	};

public:
	template <typename... Args> static Wrapper<BuilderType> require(Args... args) {
		return new BuilderType(std::forward<Args>(args)...);
	}

	Command build() override {
		try {
			return builder_->build();
		} catch (const std::exception& e) {
			auto err = ProxyBuilder::require<ErrDump>()->setErrorMsg(e.what());
			return err.build();
		}
	}

private:
	std::unique_ptr<BuilderType> builder_;
};

};	 // namespace mcsc::builtin