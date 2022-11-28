#pragma once

#include <mcsc/command/cmdbase.h>

#include <memory>
#include <iostream>

#define MCSC_CMD_BUILDER(type)                          \
private:                                                \
	using ProxyType = ::mcsc::command::ProxyBase<type>; \
	using ProxyRef	= ProxyType&;                       \
	friend ProxyType;                                   \
                                                        \
	ProxyType* proxy_;                                  \
                                                        \
	ProxyRef proxy() { return *proxy_; }                \
	ProxyRef operator->() { return proxy(); }           \
                                                        \
public:                                                 \
	Builder(const Builder&) = delete;                   \
	Builder(Builder&&)		= delete;                   \
                                                        \
	template <typename... Args>                         \
	Builder(ProxyType* proxy, Args&&... args)           \
		: Builder(std::forward<Args&&>(args)...) {      \
		proxy_ = proxy;                                 \
	}

namespace mcsc::command {

template <typename T> class ProxyBase : public Builder {
public:
	using ObjectType  = T;
	using BuilderType = typename ObjectType::Builder;

	ProxyBase(const ProxyBase&) = delete;
	ProxyBase(ProxyBase&&)		= delete;

	template <typename... Args>
	ProxyBase(Args&&... args)
		: builder(std::make_unique<BuilderType>(this, std::forward<Args&&>(args)...)) {}

	BuilderType* operator->() { return builder.get(); }

	BuilderType& unwrap() { return *builder.get(); }

private:
	std::unique_ptr<BuilderType> builder;
};
};	 // namespace mcsc::command